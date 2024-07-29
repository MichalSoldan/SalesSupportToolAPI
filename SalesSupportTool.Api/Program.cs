
using AutoMapper;

using Microsoft.Extensions.Options;

using SalesSupportTool.Api;
using SalesSupportTool.Api.Controllers;
using SalesSupportTool.Common;
using SalesSupportTool.Common.Models;
using SalesSupportTool.Domain;
using SalesSupportTool.Infrastructure.WebApi.Middlewares;

namespace SalesSupportTool
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            ConfigureServices(builder.Services, builder.Configuration, builder.Environment);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();

                var oauth2Options = app.Services.GetRequiredService<IOptions<OAuth2Options>>().Value;
                app.UseSwaggerUI(c =>
                {
                    c.OAuthClientId(oauth2Options.ClientAppId);
                    c.OAuthUsePkce();
                });
            }

            //app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.Run();
        }

        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly.GetTypes()).Where(t => t.IsSubclassOf(typeof(Profile))).ToArray());

            var modules = new IApplicationModule[]
            {
                new ApiModule(),
                new DomainModule(),
                new ApolloApiModule(),
                new ChatGptApiModule(),
            };

            Array.ForEach(modules, m => m.RegisterServices(services, configuration, environment));

            // authentication

            // business specific services
        }
    }
}
