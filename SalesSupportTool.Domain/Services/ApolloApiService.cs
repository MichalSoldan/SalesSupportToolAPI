using SalesSupportTool.Domain.Interfaces;
using SalesSupportTool.Domain.Models.ApolloApi;

namespace SalesSupportTool.Domain.Services
{
    public class ApolloApiService(IApolloApiProvider apolloApiProvider) : IApolloApiService
    {
        private readonly IApolloApiProvider _apolloApiProvider = apolloApiProvider;

        public async Task<CompanyResponse> SearchCompanyAsync(string searchKey)
        {
            return await _apolloApiProvider.SearchCompanyAsync(searchKey);
        }

        public async Task<PeopleResponse> SearchPeopleAsync(string searchKey)
        {
            return await _apolloApiProvider.SearchPeopleAsync(searchKey);
        }
    }
}
