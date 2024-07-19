using SalesSupportTool.Common;

namespace SalesSupportTool.Api
{
    public class ApiModule : IApplicationModule
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
