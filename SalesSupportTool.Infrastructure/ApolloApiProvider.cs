using AutoMapper;
using DomainApollo = SalesSupportTool.Domain.Models.ApolloApi;
using SalesSupportTool.Domain.Interfaces;
using SalesSupportTool.Infrastructure.ApolloApi.Models;
using SalesSupportTool.Infrastructure.WebApi.Providers;

namespace SalesSupportTool.Infrastructure.ApolloApi
{
    public class ApolloApiProvider : BaseProvider, IApolloApiProvider
    {
        public const string CLIENT_NAME = "ApolloApiClient";

        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;

        public ApolloApiProvider(IMapper mapper, IHttpClientFactory httpClientFactory)
        {
            _mapper = mapper;
            _httpClient = httpClientFactory.CreateClient(CLIENT_NAME);
        }

        public async Task<DomainApollo.CompanyResponse> SearchCompanyAsync(string searchKey, byte maxResults = 10)
        {
            Dictionary<string, string> headerParams = new();

            string postBody = $@"{{
                ""page"": 1, 
                ""per_page"": {maxResults}, 
                ""q_organization_name"": ""{searchKey}""
            }}";

            HttpResponseMessage response = await CallApiAsync(_httpClient, $"/mixed_companies/search", HttpMethod.Post, postBody, null, headerParams);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var data = System.Text.Json.JsonSerializer.Deserialize<MixedCompanyResponse>(content);

            var mappedData = _mapper.Map< DomainApollo.CompanyResponse >(data);

            return mappedData;
        }

        public async Task<DomainApollo.PeopleResponse> SearchPeopleAsync(string searchKey, byte maxResults = 10)
        {
            Dictionary<string, string> headerParams = new();

            string postBody = $@"{{
                ""page"": 1, 
                ""per_page"": {maxResults}, 
                ""q_organization_name"": ""{searchKey}"",
                ""person_titles"": [""ceo"", ""cto""]
            }}";

            HttpResponseMessage response = await CallApiAsync(_httpClient, $"/mixed_people/search", HttpMethod.Post, postBody, null, headerParams);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var data = System.Text.Json.JsonSerializer.Deserialize<MixedPeopleResponse>(content);

            var mappedData = _mapper.Map<DomainApollo.PeopleResponse>(data);

            return mappedData;
        }

        public class ApolloApiMappingProfile : Profile
        {
            public ApolloApiMappingProfile()
            {
                this.CreateMap<MixedCompanyResponse, DomainApollo.CompanyResponse>();
                this.CreateMap<MixedPeopleResponse, DomainApollo.PeopleResponse>();
                this.CreateMap<Account, DomainApollo.Account>();
                this.CreateMap<Breadcrumb, DomainApollo.Breadcrumb>();
                this.CreateMap<EmploymentHistory, DomainApollo.EmploymentHistory>();
                this.CreateMap<OrganizationBase, DomainApollo.OrganizationBase>();
                this.CreateMap<Organization, DomainApollo.Organization>()
                    .IncludeBase<OrganizationBase, DomainApollo.OrganizationBase>();
                this.CreateMap<Person, DomainApollo.Person>();
                this.CreateMap<Phone, DomainApollo.Phone>();
                this.CreateMap<DetailedPhoneNumber, DomainApollo.DetailedPhoneNumber>();
            }
        }
    }
}
