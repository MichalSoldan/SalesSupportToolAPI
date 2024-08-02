using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using SalesSupportTool.Common;
using SalesSupportTool.Domain.Interfaces;
using SalesSupportTool.Domain.Services;

namespace SalesSupportTool.Domain
{
    public class DomainModule : IApplicationModule
    {
        public void RegisterServices(IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            services.AddScoped<IApolloApiService, ApolloApiService>();
            services.AddScoped<IChatGptApiService, ChatGptApiService>();
            services.AddScoped<IBuiltWithApiService, BuiltWithApiService>();
        }
    }
}
