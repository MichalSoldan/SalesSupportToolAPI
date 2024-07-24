using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using SalesSupportTool.Common;
using SalesSupportTool.Domain.Interfaces;
using SalesSupportTool.Infrastructure.ChatGPTApi;
using SalesSupportTool.Infrastructure.WebApi.Extensions;

namespace SalesSupportTool.Domain
{
    public class ChatGptApiModule : IApplicationModule
    {
        public void RegisterServices(IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            services.AddHttpClient(configuration, environment, ChatGptApiProvider.CLIENT_NAME);

            services.AddScoped<IChatGptApiProvider, ChatGptApiProvider>();
        }

        public void StartServices(IServiceProvider provider)
        {
            throw new NotImplementedException();
        }
    }
}
