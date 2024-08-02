using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSupportTool.Common
{
    public interface IApplicationModule
    {
        /// <summary>
        /// Registers the services.
        /// </summary>
        /// <param name="services">The service collection.</param>
        void RegisterServices(IServiceCollection services, IConfiguration configuration, IHostEnvironment environment);
    }
}
