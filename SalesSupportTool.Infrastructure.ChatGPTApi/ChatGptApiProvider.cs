using AutoMapper;
using SalesSupportTool.Domain.Interfaces;
using SalesSupportTool.Infrastructure.WebApi.Providers;
using DomainChatGpt = SalesSupportTool.Domain.Models.ChatGptApi;
using System.Net.Http;
using SalesSupportTool.Infrastructure.ChatGPTApi.Models;

namespace SalesSupportTool.Infrastructure.ChatGPTApi
{
    public class ChatGptApiProvider : BaseProvider, IChatGptApiProvider
    {
        public const string CLIENT_NAME = "ChatGptApiClient";

        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;

        public ChatGptApiProvider(IMapper mapper, IHttpClientFactory httpClientFactory)
        {
            _mapper = mapper;
            _httpClient = httpClientFactory.CreateClient(CLIENT_NAME);
        }

        public async Task<DomainChatGpt.CompletionsResponse> Completions(string prompt, string model = "gpt-4-turbo")
        {
            Dictionary<string, string> headerParams = new();

            string postBody = $@"
            {{
                ""model"": ""gpt-4-turbo"",
                ""messages"": [
                    {{
                        ""role"": ""system"",
                        ""content"": ""{prompt}""
                    }}
                ]
            }}";

            HttpResponseMessage response = await CallApiAsync(_httpClient, $"/chat/completions", HttpMethod.Post, postBody, null, headerParams);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var data = System.Text.Json.JsonSerializer.Deserialize<CompletionsResponse>(content);

            var mappedData = _mapper.Map<DomainChatGpt.CompletionsResponse>(data);

            return mappedData;
        }

        public class ChatGptApiMappingProfile : Profile
        {
            public ChatGptApiMappingProfile()
            {
                this.CreateMap<CompletionsResponse, DomainChatGpt.CompletionsResponse>();
                this.CreateMap<Choice, DomainChatGpt.Choice>();
                this.CreateMap<Message, DomainChatGpt.Message>();
                this.CreateMap<Usage, DomainChatGpt.Usage>();
            }
        }
    }
}
