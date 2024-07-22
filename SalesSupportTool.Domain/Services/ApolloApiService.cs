using SalesSupportTool.Domain.Interfaces;

namespace SalesSupportTool.Domain.Services
{
    public class ApolloApiService(IApolloApiProvider apolloApiProvider) : IApolloApiService
    {
        private readonly IApolloApiProvider _apolloApiProvider = apolloApiProvider;

        public async Task<string> SearchCompanyAsync(string searchKey)
        {
            return await _apolloApiProvider.SearchCompanyAsync(searchKey);
        }

        public async Task<string> SearchPeopleAsync(string searchKey)
        {
            return await _apolloApiProvider.SearchPeopleAsync(searchKey);
        }
    }
}
