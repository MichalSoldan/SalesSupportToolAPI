using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

using SalesSupportTool.Common.Models;

using System.Text;

namespace SFFilter.Infrastructure.WebApi.Middlewares
{
    public class BasicAuthMiddleware
    {
        private readonly IConfiguration _configuration;

        private readonly RequestDelegate next;

        private readonly string relm;

        public BasicAuthMiddleware(RequestDelegate next, string relm, IConfiguration configuration)
        {
            this.next = next;
            this.relm = relm;
            this._configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            BasicAuthOptions basicAuthOptions = new BasicAuthOptions();
            _configuration.GetSection(BasicAuthOptions.SettingsName).Bind(basicAuthOptions);

            if (basicAuthOptions.Enabled != true)
            {
                await next(context);
                return;
            }

            if (!context.Request.Headers.ContainsKey("Authorization"))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized");
                return;
            }



            // Basic userid:password
            var header = context.Request.Headers["Authorization"].ToString();
            var encodedCreds = header.Substring(6);
            var creds = Encoding.UTF8.GetString(Convert.FromBase64String(encodedCreds));
            string[] usernamePassword = creds.Split(':');
            var username = usernamePassword[0];
            var password = usernamePassword[1];

            if ((username != basicAuthOptions.UserName || password != basicAuthOptions.Password) && basicAuthOptions.Enabled != true)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized");
                return;
            }

            await next(context);
        }
    }
}