using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using SalesSupportTool.Api.ViewModels;
using SalesSupportTool.Api.ViewModels.ApolloApi;
using SalesSupportTool.Domain.Interfaces;

using DomainApollo = SalesSupportTool.Domain.Models.ApolloApi;

namespace SalesSupportTool.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApolloApiController(IApolloApiService apolloApiService, ILogger<ApolloApiController> logger, IMapper mapper) : Controller
    {
        private readonly IApolloApiService _apolloApiService = apolloApiService;
        private readonly ILogger<ApolloApiController> _logger = logger;
        private readonly IMapper _mapper = mapper;


        [HttpGet("SearchCompanies")]
        public async Task<object> SearchCompanies(string searchText)
        {
            var data = await _apolloApiService.SearchCompanyAsync(searchText);

            var mappedData = _mapper.Map<DomainApollo.CompanyResponse, CompanyInfo>(data);

            return mappedData;
        }

        [HttpGet("SearchPeople")]
        public async Task<object> SearchPeople(string searchText)
        {
            var data = await _apolloApiService.SearchPeopleAsync(searchText);

            var mappedData = _mapper.Map<DomainApollo.PeopleResponse, PeopleInfo>(data);

            return mappedData;
        }

        public class ApolloApiControllerMappingProfile : Profile
        {
            public ApolloApiControllerMappingProfile()
            {

                this.CreateMap<DomainApollo.CompanyResponse, BaseModel>()
                    .ForMember(d => d.Metadata, o => o.MapFrom(s => s))
                    ;

                this.CreateMap<DomainApollo.CompanyResponse, CompanyInfo>()
                    .IncludeBase<DomainApollo.CompanyResponse, BaseModel>()
                    .ForMember(d => d.Accounts, o => o.MapFrom(s => s.Accounts))
                    .ForMember(d => d.Organizations, o => o.MapFrom(s => s.Organizations))
                    .ForMember(d => d.Metadata, o => o.MapFrom(s => s))
                    ;

                this.CreateMap<DomainApollo.Account, Account>()
                    .ForMember(d => d.AccountStageId, o => o.MapFrom(s => s.account_stage_id))
                    .ForMember(d => d.City, o => o.MapFrom(s => s.organization_city))
                    .ForMember(d => d.Country, o => o.MapFrom(s => s.organization_country))
                    .ForMember(d => d.Domain, o => o.MapFrom(s => s.domain))
                    .ForMember(d => d.FullAddress, o => o.MapFrom((s, d, i, c) => { return $"{s.organization_street_address}, {s.organization_city}, {s.organization_postal_code}, {s.organization_state},  {s.organization_country}"; }))
                    .ForMember(d => d.LastActivityDate, o => o.MapFrom((s, d, i, c) => 
                    {
                        DateTime? dt = string.IsNullOrWhiteSpace(s.last_activity_date) ? null : DateTime.Parse(s.last_activity_date);
                        return dt; 
                    }))
                    .ForMember(d => d.LinkedInUrl, o => o.MapFrom(s => s.linkedin_url))
                    .ForMember(d => d.Name, o => o.MapFrom((s, d, i, c) => { return s.name; }))
                    .ForMember(d => d.OwnedByOrganizationName, o => o.MapFrom((s, d, i, c) => { return s.owned_by_organization?.name ?? string.Empty; }))
                    .ForMember(d => d.OwnedByOrganizationWebsiteUrl, o => o.MapFrom((s, d, i, c) => { return s.owned_by_organization?.website_url ?? string.Empty; }))
                    .ForMember(d => d.PhoneNumber, o => o.MapFrom((s, d, i, c) => { return s.primary_phone?.Sanitized_number ?? string.Empty; }))
                    .ForMember(d => d.PhoneStatus, o => o.MapFrom(s => s.phone_status))
                    .ForMember(d => d.TwitterUrl, o => o.MapFrom(s => s.twitter_url))
                    .ForMember(d => d.WebsiteUrl, o => o.MapFrom(s => s.website_url))
                    ;

                this.CreateMap<DomainApollo.OrganizationBase, OrganizationBase>()
                    .ForMember(d => d.Id, o => o.MapFrom(s => s.id))
                    .ForMember(d => d.Name, o => o.MapFrom(s => s.name))
                    .ForMember(d => d.WebsiteUrl, o => o.MapFrom(s => s.website_url))
                    ;

                this.CreateMap<DomainApollo.Organization, Organization>()
                    .IncludeBase<DomainApollo.OrganizationBase, OrganizationBase>()
                    .ForMember(d => d.Id, o => o.MapFrom(s => s.id))
                    .ForMember(d => d.AngellistUrl, o => o.MapFrom(s => s.angellist_url))
                    .ForMember(d => d.BlogUrl, o => o.MapFrom(s => s.blog_url))
                    .ForMember(d => d.CrunchbaseUrl, o => o.MapFrom(s => s.crunchbase_url))
                    .ForMember(d => d.FacebookUrl, o => o.MapFrom(s => s.facebook_url))
                    .ForMember(d => d.FoundedYear, o => o.MapFrom(s => s.founded_year))
                    .ForMember(d => d.Languages, o => o.MapFrom(s => s.languages))
                    .ForMember(d => d.LinkedinUrl, o => o.MapFrom(s => s.linkedin_url))
                    .ForMember(d => d.LogoUrl, o => o.MapFrom(s => s.logo_url))
                    .ForMember(d => d.Phone, o => o.MapFrom(s => s.primary_phone))
                    .ForMember(d => d.PrimaryDomain, o => o.MapFrom(s => s.primary_domain))
                    .ForMember(d => d.TwitterUrl, o => o.MapFrom(s => s.twitter_url))
                    .ForMember(d => d.WebsiteUrl, o => o.MapFrom(s => s.website_url))
                    ;

                this.CreateMap<DomainApollo.Phone, Account>()
                    .ForMember(d => d.PhoneNumber, o => o.MapFrom(s => s.Sanitized_number))
                    .ForAllMembers(o => o.Ignore())
                    ;

                this.CreateMap<DomainApollo.PeopleResponse, BaseModel>()
                    .ForMember(d => d.Metadata, o => o.MapFrom(s => s))
                    ;

                this.CreateMap<DomainApollo.PeopleResponse, PeopleInfo>()
                    .IncludeBase<DomainApollo.PeopleResponse, BaseModel>()
                    .ForMember(d => d.People, o => o.MapFrom(s => s.People))
                    .ForMember(d => d.Metadata, o => o.MapFrom(s => s))
                    ;
                this.CreateMap<DomainApollo.EmploymentHistory, EmploymentHistory>()
                    .ForMember(d => d.Description, o => o.MapFrom(s => s.description))
                    .ForMember(d => d.EndDate, o => o.MapFrom(s => s.end_date))
                    .ForMember(d => d.IsCurrent, o => o.MapFrom(s => s.current))
                    .ForMember(d => d.OrganizationName, o => o.MapFrom(s => s.organization_name))
                    .ForMember(d => d.StartDate, o => o.MapFrom(s => s.start_date))
                    .ForMember(d => d.Title, o => o.MapFrom(s => s.title))
                    ;
                this.CreateMap<DomainApollo.Person, Person>()
                    .ForMember(d => d.City, o => o.MapFrom(s => s.city))
                    .ForMember(d => d.Country, o => o.MapFrom(s => s.country))
                    .ForMember(d => d.Departments, o => o.MapFrom(s => s.departments))
                    .ForMember(d => d.Email, o => o.MapFrom(s => s.email))
                    .ForMember(d => d.EmploymentHistory, o => o.MapFrom(s => s.employment_history))
                    .ForMember(d => d.FacebookUrl, o => o.MapFrom(s => s.facebook_url))
                    .ForMember(d => d.FirstName, o => o.MapFrom(s => s.first_name))
                    .ForMember(d => d.Functions, o => o.MapFrom(s => s.functions))
                    .ForMember(d => d.GithubUrl, o => o.MapFrom(s => s.github_url))
                    .ForMember(d => d.Headline, o => o.MapFrom(s => s.headline))
                    .ForMember(d => d.Id, o => o.MapFrom(s => s.id))
                    .ForMember(d => d.LastName, o => o.MapFrom(s => s.last_name))
                    .ForMember(d => d.LinkedinUrl, o => o.MapFrom(s => s.linkedin_url))
                    .ForMember(d => d.PhotoUrl, o => o.MapFrom(s => s.photo_url))
                    .ForMember(d => d.Seniority, o => o.MapFrom(s => s.seniority))
                    .ForMember(d => d.State, o => o.MapFrom(s => s.state))
                    .ForMember(d => d.SubDepartments, o => o.MapFrom(s => s.subdepartments))
                    .ForMember(d => d.Title, o => o.MapFrom(s => s.title))
                    .ForMember(d => d.TwitterUrl, o => o.MapFrom(s => s.twitter_url))
                    ;
            }
        }
    }
}
