using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using SalesSupportTool.Common.Models;

using SalesSupportTool.Domain.Interfaces;

using SalesSupportTool.Infrastructure.WebApi.Controllers;

namespace SalesSupportTool.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/apolloio")]
    public class HomeController : BaseHomeController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IJwtAuthService jwtAuthService, IOptions<JwtAuthOptions> jwtAuthOptions, IConfiguration configuration)
            : base(jwtAuthService, jwtAuthOptions, configuration)
        {
            this._logger = logger;
        }
    }
}
