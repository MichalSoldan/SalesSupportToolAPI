
using AutoMapper;

using Microsoft.Extensions.DependencyInjection;

using SalesSupportTool.Domain.Interfaces;
using SalesSupportTool.Infrastructure.WebApi.Services;
using SalesSupportTool.Infrastructure.WebApi.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using SalesSupportTool.Common.Models;
using Microsoft.Extensions.Options;
using SalesSupportTool.Infrastructure.WebApi.Middlewares;
using Microsoft.Graph.Models.ExternalConnectors;
using Microsoft.AspNetCore.Cors.Infrastructure;

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
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();

                var oauth2Options = app.Services.GetRequiredService<IOptions<OAuth2Options>>().Value;
                app.UseSwaggerUI(c =>
                {
                    c.OAuthClientId(oauth2Options.ClientAppId);
                    c.OAuthUsePkce();
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.Run();
        }

        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            services.Configure<JwtAuthOptions>(configuration.GetSection(JwtAuthOptions.SettingsName));
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly.GetTypes()).Where(t => t.IsSubclassOf(typeof(Profile))).ToArray());
            services.AddJwtSwaggerGen(configuration);

            services.AddHttpClient(configuration, environment, "IndexClient");
            services.AddHttpClient(configuration, environment, "ApolloIOClient");

            // authentication
            services.AddSingleton<IJwtAuthService, JwtAuthService>();
            services.AddJwtAuthentication(configuration);

            // business specific services
        }
    }
}
