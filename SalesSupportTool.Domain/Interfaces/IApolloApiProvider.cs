using SalesSupportTool.Domain.Models.ApolloApi;

namespace SalesSupportTool.Domain.Interfaces
{
    public interface IApolloApiProvider
    {
        Task<CompanyResponse> SearchCompanyAsync(string searchKey, byte maxResults = 10);
        Task<PeopleResponse> SearchPeopleAsync(string searchKey, byte maxResults = 10);
    }
}
