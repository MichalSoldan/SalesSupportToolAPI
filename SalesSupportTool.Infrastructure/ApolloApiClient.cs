using SalesSupportTool.Domain.Interfaces;

using System.Text;
using System.Web;

namespace SalesSupportTool.Infrastructure.ApolloIO
{
    public class ApolloApiClient : IApolloApiClient
    {
        private readonly HttpClient _apiClient;

        public ApolloApiClient(IHttpClientFactory httpClientFactory)
        {
            _apiClient = httpClientFactory.CreateClient("ApolloIOClient");
        }

        private Dictionary<string, string> DefaultHeaderParameters { get; set; } = [];

        public async Task<HttpResponseMessage> CallApiAsync(
            HttpClient httpClient,
            string path,
            HttpMethod method,
            string? postBody = null,
            Dictionary<string, string>? queryParameters = null,
            Dictionary<string, string>? headerParameters = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            HttpRequestMessage request = new(method, httpClient.BaseAddress + path);

            // Add header parameter, if any.
            headerParameters = headerParameters?.Count > 0 ? DefaultHeaderParameters.Concat(headerParameters).ToDictionary(kp => kp.Key, kp => kp.Value) : DefaultHeaderParameters;

            foreach (KeyValuePair<string, string> parameter in headerParameters)
            {
                request.Headers.Add(parameter.Key, parameter.Value);
            }

            // Add query parameter, if any.
            if (queryParameters != null && queryParameters.Any())
            {
                // Retrieve the existing query parameters from the request
                var queryParams = HttpUtility.ParseQueryString(request.RequestUri?.Query ?? string.Empty);
                foreach (var kvp in queryParameters)
                {
                    queryParams[kvp.Key] = kvp.Value;
                }
                var uriBuilder = new UriBuilder(request.RequestUri)
                {
                    Query = string.Join("&", queryParams.AllKeys.Select(key => $"{key}={queryParams[key]}"))
                };
                request.RequestUri = uriBuilder.Uri;
            }

            // HTTP body(model) parameter.
            if (postBody != null)
            {
                StringContent content = new(postBody, Encoding.UTF8, "application/json");
                request.Content = content;
            }

            return await httpClient.SendAsync(request, cancellationToken);
        }


        public async Task<string> SearchCompanyAsync(string searchKey, int candidateMaximumQuantity = 10)
        {
            Dictionary<string, string> headerParams = new();
            HttpResponseMessage response = await CallApiAsync(_apiClient, $"/mixed_companies/search", HttpMethod.Post, $"{{\"page\": 1, \"per_page\": 10, \"q_organization_name\": \"{searchKey}\", \"person_titles\": [\"ceo\", \"cto\"]}}", null, headerParams);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<string> SearchPeopleAsync(string searchKey, int candidateMaximumQuantity = 10)
        {
            Dictionary<string, string> headerParams = new();
            HttpResponseMessage response = await CallApiAsync(_apiClient, $"/mixed_people/search", HttpMethod.Post, $"{{\"page\": 1, \"per_page\": 10, \"q_organization_name\": \"{searchKey}\", \"person_titles\": [\"ceo\", \"cto\"]}}", null, headerParams);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
    }
}
