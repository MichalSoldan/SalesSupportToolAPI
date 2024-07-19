using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using SalesSupportTool.Common.Models;

namespace SalesSupportTool.Infrastructure.WebApi.Providers
{
    
    public class AADTokenProvider
    {
        private readonly ILogger<AADTokenProvider> _logger;
        private readonly OAuth2Options _options = new();
        private readonly IConfidentialClientApplication _app;

        public AADTokenProvider(IConfiguration configuration, ILogger<AADTokenProvider> logger)
        {
            _logger = logger;
            configuration.GetSection(OAuth2Options.SettingsName).Bind(_options);
            var authority = $"{_options.Instance}{_options.TenantId}";
            _app = ConfidentialClientApplicationBuilder.Create(_options.ClientAppId)
                .WithClientSecret(_options.ClientAppSecret)
                .WithAuthority(new Uri(authority))
                .Build();
        }

        public async Task<string> GetTokenAsync()
        {
            try
            {
                string[] scopes = new string[] { _options.Scope };
                var result = await _app.AcquireTokenForClient( scopes )
                    .ExecuteAsync();
                return result.AccessToken;
            }
            catch (MsalServiceException ex)
            {
                _logger.LogError(ex,ex.Message);
                throw;
            }
        }
    }
}
