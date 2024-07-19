using System.Globalization;
using System.Reflection;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

using SalesSupportTool.Domain.Interfaces;
using SalesSupportTool.Common.Models;
using SalesSupportTool.Common.Helpers;

namespace SalesSupportTool.Infrastructure.WebApi.Controllers
{
    public abstract class BaseHomeController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        private readonly JwtAuthOptions _jwtTokenOptions;

        private readonly IJwtAuthService _jwtTokenService;

        public BaseHomeController(IJwtAuthService jwtAuthService, IOptions<JwtAuthOptions> jwtAuthOptions, IConfiguration configuration)
        {
            this._jwtTokenService = jwtAuthService;
            this._configuration = configuration;
            this._jwtTokenOptions = jwtAuthOptions.Value;
        }

        /// <summary>
        /// Get current appSettings and environment configuration of the service.
        /// </summary>
        /// <returns>Configuration values list.</returns>
        [HttpGet]
        [Route("Configuration")]
        public string Configuration()
        {
            string content = "";
            foreach (KeyValuePair<string, string?> item in this._configuration.AsEnumerable())
            {
                content += $"{item.Key} : {item.Value}\n";
            }
            return content;
        }

        /// <summary>
        /// Gets service name and build time.
        /// </summary>
        /// <returns>Service name and build time.</returns>
        [AllowAnonymous]
        [Route("/")]
        [HttpGet]
        public string Get()
        {
            Type? serviceHostType = LoggingHelper.GetBackgroundServiceType();
            if (serviceHostType != null)
            {
                return $"{serviceHostType.Name}: {GetBuildDateTime(serviceHostType.Assembly)} UTC";
            }
            else
            {
                return "OK";
            }
        }

        [AllowAnonymous]
        [Route("IssueJwtToken")]
        [HttpPost]
        public IActionResult IssueJwtToken(string login, string password)
        {
            if (login != this._jwtTokenOptions.Login || password != this._jwtTokenOptions.Password)
            {
                return this.NotFound("User not found!");
            }

            string jwtToken = this._jwtTokenService.IssueJwtToken(login);
            return this.Content(jwtToken);
        }

        [Route("Liveness")]
        [HttpGet]
        public virtual string Liveness()
        {
            return "OK";
        }

        [AllowAnonymous]
        [Route("SimulateError")]
        [HttpPost]
        public void SimulateError([FromBody] string param1 = "123")
        {
            throw new Exception("Testing error");
        }

        [Authorize]
        [Route("TestJwtToken")]
        [HttpGet]
        public async Task<string> TestJwtToken()
        {
            return await Task.Run(() => "Valid token");
        }

        private static DateTime GetBuildDateTime(Assembly assembly)
        {
            const string BuildVersionMetadataPrefix = "+build";

            AssemblyInformationalVersionAttribute? attribute = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            if (attribute?.InformationalVersion != null)
            {
                string value = attribute.InformationalVersion;
                int index = value.IndexOf(BuildVersionMetadataPrefix);
                if (index > 0)
                {
                    value = value.Substring(index + BuildVersionMetadataPrefix.Length);
                    if (DateTime.TryParseExact(value, "yyyyMMddHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                    {
                        return result;
                    }
                }
            }

            return default;
        }
    }
}