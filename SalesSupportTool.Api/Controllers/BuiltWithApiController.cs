using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using SalesSupportTool.Domain.Interfaces;

namespace SalesSupportTool.Api.Controllers
{
    public class BuiltWithApiController(IBuiltWithApiService builtWithApiService, ILogger<BuiltWithApiController> logger, IMapper mapper) : Controller
    {
        private readonly IBuiltWithApiService _builtWithApiService = builtWithApiService;
        private readonly ILogger<BuiltWithApiController> _logger = logger;
        private readonly IMapper _mapper = mapper;

        [HttpGet("GetDomain")]
        public async Task<object> GetDomain(string domain)
        {
            var data = await _builtWithApiService.GetDomain(domain);

            return data;
            //var mappedData = _mapper.Map<DomainApollo.CompanyResponse, CompanyInfo>(data);

            //return mappedData;
        }

        [HttpGet("GetDomainSimple")]
        public async Task<object> GetDomainSimple(string domain)
        {
            var data = await _builtWithApiService.GetDomainSimple(domain);

            return data;
        }
    }
}
