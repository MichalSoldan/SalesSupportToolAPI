using Microsoft.IdentityModel.Tokens;

using System.Text;

namespace SalesSupportTool.Infrastructure.WebApi.Helpers
{
    public static class JwtTokenHelper
    {
        public static SecurityKey CreateSigningKey(string secret)
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
        }
    }
}