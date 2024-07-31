using SalesSupportTool.Domain.Models.BuiltWithApi;

namespace SalesSupportTool.Domain.Interfaces
{
    public interface IBuiltWithApiService
    {
        Task<DomainResponse> GetDomain(string domain, int daysToLookBehind = 92, List<string>? allowedTags = null);

        Task<List<SimpleDomainInfo>> GetDomainSimple(string domain);
    }
}
