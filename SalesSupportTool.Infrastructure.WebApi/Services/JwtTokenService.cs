using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using SalesSupportTool.Domain.Interfaces;
using SalesSupportTool.Common.Models;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SalesSupportTool.Infrastructure.WebApi.Services
{
    public class JwtAuthService : IJwtAuthService
    {
        private readonly JwtAuthOptions _jwtTokenOptions;

        public JwtAuthService(IOptions<JwtAuthOptions> jwtAuthOptions)
        {
            this._jwtTokenOptions = jwtAuthOptions.Value;
        }

        public string IssueJwtToken(string login)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._jwtTokenOptions.Secret));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256, SecurityAlgorithms.HmacSha256);
            Claim[] claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, login),
            };
            JwtSecurityToken token = new JwtSecurityToken(this._jwtTokenOptions.Issuer,
                this._jwtTokenOptions.Audience, claims,
                expires: DateTime.Now.AddYears(10),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}