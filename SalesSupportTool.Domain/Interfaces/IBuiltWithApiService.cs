using SalesSupportTool.Domain.Models.BuiltWithApi;

namespace SalesSupportTool.Domain.Interfaces
{
    public interface IBuiltWithApiService
    {
        Task<DomainResponse> GetDomain(string domain);
    }
}
