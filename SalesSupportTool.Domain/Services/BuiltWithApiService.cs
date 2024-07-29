using SalesSupportTool.Domain.Interfaces;

namespace SalesSupportTool.Domain.Services
{
    public class BuiltWithApiService(IBuiltWithApiProvider builtWithApiProvider) : IBuiltWithApiService
    {
        private readonly IBuiltWithApiProvider _builtWithApiProvider = builtWithApiProvider;

        public async Task<object> GetDomain(string domain)
        {
            return await _builtWithApiProvider.GetDomain(domain);
        }
    }
}
