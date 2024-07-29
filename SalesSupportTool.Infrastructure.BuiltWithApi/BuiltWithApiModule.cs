using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using SalesSupportTool.Common;
using SalesSupportTool.Domain.Interfaces;
using SalesSupportTool.Infrastructure.WebApi.Extensions;

namespace SalesSupportTool.Infrastructure.BuiltWithApi
{
    public class BuiltWithApiModule : IApplicationModule
    {
        public void RegisterServices(IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            services.AddHttpClient(configuration, environment, BuiltWithApiProvider.CLIENT_NAME);

            services.AddScoped<IBuiltWithApiProvider, BuiltWithApiProvider>();
        }

        public void StartServices(IServiceProvider provider)
        {
            throw new NotImplementedException();
        }
    }
}
