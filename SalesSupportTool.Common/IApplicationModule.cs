using Microsoft.Extensions.DependencyInjection;

namespace SalesSupportTool.Common
{
    public interface IApplicationModule
    {
        /// <summary>
        /// Registers the services.
        /// </summary>
        /// <param name="services">The service collection.</param>
        void RegisterServices(IServiceCollection services);

        /// <summary>
        /// Gets the automapper profiles.
        /// </summary>
        IEnumerable<Type> GetAutomapperProfiles();

        /// <summary>
        /// Starts the services.
        /// </summary>
        /// <param name="provider">The provider.</param>
        void StartServices(IServiceProvider provider);
    }
}
