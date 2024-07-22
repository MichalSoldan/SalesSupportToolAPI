using SalesSupportTool.Domain.Interfaces;
using SalesSupportTool.Infrastructure.WebApi.Providers;

namespace SalesSupportTool.Infrastructure.ApolloApi
{
    public class ApolloApiProvider : BaseProvider, IApolloApiProvider
    {
        public const string CLIENT_NAME = "ApolloApiClient";
        private readonly HttpClient _httpClient;

        public ApolloApiProvider(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient(CLIENT_NAME);
        }

        public async Task<string> SearchCompanyAsync(string searchKey, int candidateMaximumQuantity = 10)
        {
            Dictionary<string, string> headerParams = new();
            HttpResponseMessage response = await CallApiAsync(_httpClient, $"/mixed_companies/search", HttpMethod.Post, $"{{\"page\": 1, \"per_page\": 10, \"q_organization_name\": \"{searchKey}\", \"person_titles\": [\"ceo\", \"cto\"]}}", null, headerParams);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<string> SearchPeopleAsync(string searchKey, int candidateMaximumQuantity = 10)
        {
            Dictionary<string, string> headerParams = new();
            HttpResponseMessage response = await CallApiAsync(_httpClient, $"/mixed_people/search", HttpMethod.Post, $"{{\"page\": 1, \"per_page\": 10, \"q_organization_name\": \"{searchKey}\", \"person_titles\": [\"ceo\", \"cto\"]}}", null, headerParams);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
    }
}
