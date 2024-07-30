using AutoMapper;

using Microsoft.Extensions.Configuration;

using SalesSupportTool.Domain.Interfaces;
using SalesSupportTool.Infrastructure.BuiltWithApi.Models;
using SalesSupportTool.Infrastructure.WebApi.Providers;

using DomainBuiltWith = SalesSupportTool.Domain.Models.BuiltWithApi;


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

        public async Task<DomainBuiltWith.DomainResponse> GetDomain(string domain)
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

            var mappedData = _mapper.Map<DomainBuiltWith.DomainResponse>(data);

            return mappedData;
        }

        public class BuiltWithApiMappingProfile : Profile
        {
            public BuiltWithApiMappingProfile()
            {
                this.CreateMap<Response, DomainBuiltWith.DomainResponse>()
                    ;

                this.CreateMap<Error, DomainBuiltWith.Error>()
                    ;

                this.CreateMap<DomainResult, DomainBuiltWith.DomainResult>()
                    .ForMember(d => d.FirstIndexed, o => o.MapFrom(s => DateTimeOffset.FromUnixTimeMilliseconds(s.FirstIndexed).DateTime))
                    .ForMember(d => d.LastIndexed, o => o.MapFrom(s => DateTimeOffset.FromUnixTimeMilliseconds(s.LastIndexed).DateTime))
                    ;

                this.CreateMap<Result, DomainBuiltWith.Result>()
                    ;

                this.CreateMap<Meta, DomainBuiltWith.Meta>()
                    ;

                this.CreateMap<Attributes, DomainBuiltWith.Attributes>()
                    ;

                this.CreateMap<SpendHistory, DomainBuiltWith.SpendHistory>()
                    .ForMember(d => d.D, o => o.MapFrom(s => DateTimeOffset.FromUnixTimeMilliseconds(s.D).DateTime))
                    ;

                this.CreateMap<DomainPath, DomainBuiltWith.DomainPath>()
                    .ForMember(d => d.FirstIndexed, o => o.MapFrom(s => DateTimeOffset.FromUnixTimeMilliseconds(s.FirstIndexed).DateTime))
                    .ForMember(d => d.LastIndexed, o => o.MapFrom(s => DateTimeOffset.FromUnixTimeMilliseconds(s.LastIndexed).DateTime))
                    ;

                this.CreateMap<Technology, DomainBuiltWith.Technology>()
                    .ForMember(d => d.FirstDetected, o => o.MapFrom(s => DateTimeOffset.FromUnixTimeMilliseconds(s.FirstDetected).DateTime))
                    .ForMember(d => d.LastDetected, o => o.MapFrom(s => DateTimeOffset.FromUnixTimeMilliseconds(s.LastDetected).DateTime))
                    .ForMember(d => d.IsPremium, o => o.MapFrom(s => s.IsPremium.Equals("yes", StringComparison.OrdinalIgnoreCase)))
                    ;

            }
        }
    }
}