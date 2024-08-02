using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using SalesSupportTool.Common;
using SalesSupportTool.Domain.Interfaces;
using SalesSupportTool.Infrastructure.ApolloApi;
using SalesSupportTool.Infrastructure.WebApi.Extensions;

namespace SalesSupportTool.Domain
{
    public class ApolloApiModule : IApplicationModule
    {
        public void RegisterServices(IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            services.AddHttpClient(configuration, environment, ApolloApiProvider.CLIENT_NAME);

            services.AddScoped<IApolloApiProvider, ApolloApiProvider>();
        }
    }
}
