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
        private readonly JwtAuthOptions _jwtTokenOptions;
        private readonly IJwtAuthService _jwtTokenService;

        public BaseHomeController(IJwtAuthService jwtAuthService, IOptions<JwtAuthOptions> jwtAuthOptions)
        {
            this._jwtTokenService = jwtAuthService;
            this._jwtTokenOptions = jwtAuthOptions.Value;
        }

        [AllowAnonymous]
        [Route("IssueJwtToken")]
        [HttpPost]
        public IActionResult IssueJwtToken(string login, string password)
        {
            if (login != this._jwtTokenOptions.Login || 
                password != this._jwtTokenOptions.Password)
            {
                return this.NotFound("User not found!");
            }

            string jwtToken = this._jwtTokenService.IssueJwtToken(login);
            return this.Content(jwtToken);
        }
    }
}