using Microsoft.Extensions.DependencyInjection;

using SalesSupportTool.Common;

namespace SalesSupportTool.Services
{
    public class DomainModule : IApplicationModule
    {
        /// <inheritdoc />
        public IEnumerable<Type> GetAutomapperProfiles()
        {
            return Enumerable.Empty<Type>();
        }

        /// <inheritdoc />
        public void RegisterServices(IServiceCollection services)
        {
            //services.AddScoped<SiteService>();
        }

        /// <inheritdoc />
        public void StartServices(IServiceProvider provider)
        {
        }
    }
}
