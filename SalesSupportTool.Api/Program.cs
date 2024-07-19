
using AutoMapper;

using Microsoft.Extensions.DependencyInjection;

using SalesSupportTool.Domain.Interfaces;
using SalesSupportTool.Infrastructure.WebApi.Providers;
using SalesSupportTool.Infrastructure.WebApi.Services;
using SalesSupportTool.Infrastructure.WebApi.Extensions;

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
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly.GetTypes()).Where(t => t.IsSubclassOf(typeof(Profile))).ToArray());
            services.AddJwtSwaggerGen(configuration);
            services.AddSingleton<AADTokenProvider>();
            services.AddHttpClient(configuration, environment, "ApolloIOClient");

            // authentication
            services.AddSingleton<IJwtAuthService, JwtAuthService>();
            services.AddJwtAuthentication(configuration);
        }
    }
}
