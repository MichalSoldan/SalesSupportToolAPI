using SalesSupportTool.Common;
using SalesSupportTool.Common.Models;

namespace SalesSupportTool.Api
{
    public class ApiModule : IApplicationModule
    {
        public void RegisterServices(IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            services.Configure<JwtAuthOptions>(configuration.GetSection(JwtAuthOptions.SettingsName));
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void StartServices(IServiceProvider provider)
        {
            throw new NotImplementedException();
        }
    }
}
