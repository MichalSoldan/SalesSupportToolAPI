using SalesSupportTool.Domain.Models.BuiltWithApi;

namespace SalesSupportTool.Domain.Interfaces
{
    public interface IBuiltWithApiProvider
    {
        Task<DomainResponse> GetDomain(string domain, bool liveOnly = true);

        Task<List<SimpleDomainInfo>> GetDomainSimple(string domain);
    }
}
