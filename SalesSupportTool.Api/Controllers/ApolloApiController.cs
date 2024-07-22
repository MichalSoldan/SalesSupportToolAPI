using Microsoft.AspNetCore.Mvc;

using SalesSupportTool.Domain.Interfaces;
using SalesSupportTool.Infrastructure.ApolloApi;

namespace SalesSupportTool.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApolloApiController(IApolloApiService apolloApiService, ILogger<ApolloApiController> logger) : Controller
    {
        private readonly IApolloApiService _apolloApiService = apolloApiService;
        private readonly ILogger<ApolloApiController> _logger = logger;


        [HttpGet("SearchCompanies")]
        public async Task<object> SearchCompanies(string searchText)
        {
            string data = await _apolloApiService.SearchCompanyAsync(searchText);

            return data;
        }

        [HttpGet("SearchPeople")]
        public async Task<object> SearchPeople(string searchText)
        {
            string data = await _apolloApiService.SearchPeopleAsync(searchText);

            return data;
        }
    }
}
