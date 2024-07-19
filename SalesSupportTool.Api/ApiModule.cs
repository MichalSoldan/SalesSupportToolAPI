using SalesSupportTool.Common;
using SalesSupportTool.Infrastructure.WebApi.Services;

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
            services.AddScoped<SalesSupportTool.Domain.Interfaces.IJwtAuthService, JwtAuthService>();
        }

        /// <inheritdoc />
        public void StartServices(IServiceProvider provider)
        {
        }
    }
}
