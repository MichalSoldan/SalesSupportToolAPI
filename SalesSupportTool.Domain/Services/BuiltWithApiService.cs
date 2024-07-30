using SalesSupportTool.Domain.Interfaces;
using SalesSupportTool.Domain.Models.BuiltWithApi;

namespace SalesSupportTool.Domain.Services
{
    public class BuiltWithApiService(IBuiltWithApiProvider builtWithApiProvider) : IBuiltWithApiService
    {
        private readonly IBuiltWithApiProvider _builtWithApiProvider = builtWithApiProvider;

        public async Task<DomainResponse> GetDomain(string domain)
        {
            var data = await _builtWithApiProvider.GetDomain(domain);

            foreach (var result in data.Results)
            {
                result.Result.Paths = result.Result.Paths.Where(p => p.SubDomain.Equals("www", StringComparison.OrdinalIgnoreCase) || string.IsNullOrWhiteSpace(p.SubDomain)).ToList();

                foreach (var path in result.Result.Paths)
                {
                    path.Technologies = path.Technologies.OrderByDescending(x => x.LastDetected).ToList(); //.Where(t => t.Categories.Any(c => c.Equals("web-server", StringComparison.OrdinalIgnoreCase))).ToList();
                }
            };

            return data;
        }
    }
}
