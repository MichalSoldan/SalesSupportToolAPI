using SalesSupportTool.Domain.Interfaces;
using SalesSupportTool.Domain.Models.BuiltWithApi;

namespace SalesSupportTool.Domain.Services
{
    public class BuiltWithApiService(IBuiltWithApiProvider builtWithApiProvider) : IBuiltWithApiService
    {
        private readonly IBuiltWithApiProvider _builtWithApiProvider = builtWithApiProvider;

        public async Task<DomainResponse> GetDomain(string domain, int daysToLookBehind = 92, List<string>? allowedTags = null)
        {
            var data = await _builtWithApiProvider.GetDomain(domain);

            // allowed tags/categories to display. Complete list can be found at https://api.builtwith.com/categoriesV4.json
            allowedTags ??=
            [
                "javascript",
                "analytics",
                "web server",
                "server",
                "framework",
                "cdn",
            ];

            foreach (var result in data.Results)
            {
                result.Result.Paths = result.Result.Paths
                    .Where(p => p.SubDomain.Equals("www", StringComparison.OrdinalIgnoreCase) || string.IsNullOrWhiteSpace(p.SubDomain))
                    .ToList();

                foreach (var path in result.Result.Paths)
                {
                    path.Technologies = path.Technologies
                        .Where(i => (i.LastDetected.AddDays(daysToLookBehind) >= DateTime.Now && allowedTags.Contains(i.Tag.ToLower())))
                        .OrderByDescending(x => x.LastDetected)
                        .ToList();
                }
            };

            return data;
        }

        public async Task<List<SimpleDomainInfo>> GetDomainSimple(string domain)
        {
            return await _builtWithApiProvider.GetDomainSimple(domain);
        }
    }
}
