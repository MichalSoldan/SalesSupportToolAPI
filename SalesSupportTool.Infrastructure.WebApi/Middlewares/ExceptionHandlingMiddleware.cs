using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Microsoft.Graph.Models.ODataErrors;

using SalesSupportTool.Domain.Exceptions;
using SalesSupportTool.Infrastructure.WebApi.Models;

namespace SalesSupportTool.Infrastructure.WebApi.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        public RequestDelegate requestDelegate;

        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate requestDelegate, ILogger<ExceptionHandlingMiddleware> logger)
        {
            this.requestDelegate = requestDelegate;
            this._logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var originalResponse = context.Response.Body;
            using (var newResponse = new MemoryStream())
            {
                try
                {
                    context.Response.Body = newResponse;

                    await this.requestDelegate(context);
                }
                catch (Exception ex)
                {
                    context.Response.Body = originalResponse;
                    await this.HandleException(context, ex);
                }
                finally
                {
                    if (context.Response.Body == newResponse)
                    {
                        // Only copy the new response stream back if no exception was thrown,
                        // or if the HandleException method has successfully handled the exception.
                        newResponse.Seek(0, SeekOrigin.Begin);
                        await newResponse.CopyToAsync(originalResponse, context.RequestAborted);
                        context.Response.Body = originalResponse;
                    }
                }
            }
        }

        private async Task HandleException(HttpContext context, Exception ex)
        {
            try
            {
                string? action = context.GetRouteValue("action")?.ToString();
                string message = $"Exception in action '{action}': {ex.Message}.";

                // handle OData exception
                var oDataEx = ex as ODataError;
                if (oDataEx != null)
                {
                    if (oDataEx.Error != null)
                    {
                        message += $"\r\nError: {oDataEx.Error.Message}";
                        if (oDataEx.Error.Details != null)
                        {
                            oDataEx.Error.Details.ForEach(d => message += $"\r\n{d.Code}: {d.Message}");
                        }
                        ex = new Exception(message, oDataEx);
                    }
                }

                string requestBody = null;

                this._logger.LogError(ex, message, new Dictionary<string, object> { { "RequestBody", requestBody } });
                string errorMessage = JsonSerializer.Serialize(new ErrorResponseModel
                {
                    Message = ex.Message,
                    StackTrace = ex.StackTrace,
                    InnerException = new ErrorResponseModel { Message = ex.InnerException?.Message, StackTrace = ex.InnerException?.StackTrace }
                });

                int statusCode;
                if (ex is ArgumentNullException || ex is ValidationException)
                {
                    statusCode = (int)HttpStatusCode.BadRequest;
                }
                else if (ex is NotFoundException || ex.Message.Contains("Status: 404 (Not Found)")
                    || ((ex as ODataError)?.Error?.Message?.Contains("NotFound") == true)
                    || ((ex as ODataError)?.Error?.Message?.Contains("does not exist") == true))
                {
                    statusCode = (int)HttpStatusCode.NotFound;
                }
                else
                {
                    statusCode = (int)HttpStatusCode.InternalServerError;
                }

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = statusCode;

                await context.Response.WriteAsync(errorMessage);
            }
            catch (Exception internalException)
            {
                _logger.LogError(internalException, "An error occurred while handling another exception.");

                // Send a generic error response to avoid leaking details
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                string errorMessage = JsonSerializer.Serialize(new ErrorResponseModel
                {
                    Message = internalException.Message,
                });
                await context.Response.WriteAsync(errorMessage);
            }
        }
    }
}