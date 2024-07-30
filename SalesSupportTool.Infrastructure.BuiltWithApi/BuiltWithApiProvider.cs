using AutoMapper;

using BuiltWith.Objects.v14;

using Microsoft.Extensions.Configuration;

using SalesSupportTool.Domain.Interfaces;
using SalesSupportTool.Infrastructure.BuiltWithApi.Models;
using SalesSupportTool.Infrastructure.WebApi.Providers;

namespace SalesSupportTool.Infrastructure.BuiltWithApi
{
    public class BuiltWithApiProvider : BaseProvider, IBuiltWithApiProvider
    {
        public const string CLIENT_NAME = "BuiltWithApiClient";

        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;
        private readonly string _key;

        public BuiltWithApiProvider(IMapper mapper, IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _mapper = mapper;

            _key = configuration.GetSection(CLIENT_NAME).GetValue<string>("Key") ?? string.Empty;

            _httpClient = httpClientFactory.CreateClient(CLIENT_NAME);
        }

        public async Task<object> GetDomain(string domain)
        {
            var utlParams = new Dictionary<string, string>
            {
                { "KEY", _key },
                { "LOOKUP", domain }
            };

            HttpResponseMessage response = await CallApiAsync(_httpClient, "/api.json", HttpMethod.Get, null, utlParams, null);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var data = System.Text.Json.JsonSerializer.Deserialize<Response>(content);

            //var data = DomainAPI.FromJson(content);

            //var mappedData = _mapper.Map<DomainApollo.CompanyResponse>(data);

            return data;
        }

        public class BuiltWithApiMappingProfile : Profile
        {
            public BuiltWithApiMappingProfile()
            {
                //this.CreateMap<MixedCompanyResponse, DomainApollo.CompanyResponse>();
            }
        }
    }
}