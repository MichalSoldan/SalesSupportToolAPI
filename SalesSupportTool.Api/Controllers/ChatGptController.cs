using Microsoft.AspNetCore.Mvc;

using SalesSupportTool.Domain.Interfaces;
using SalesSupportTool.Domain.Models.ChatGptApi;

namespace SalesSupportTool.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ChatGptController(IChatGptApiService chatGptApiService, ILogger<ApolloApiController> logger) : Controller
    {
        private readonly IChatGptApiService _chatGptApiService = chatGptApiService;
        private readonly ILogger<ApolloApiController> _logger = logger;


        [HttpPost("Completions")]
        public async Task<CompletionsResponse> Completions(string prompt, string model = "gpt-4o")
        {
            var data = await _chatGptApiService.Completion(prompt, model);

            return data;
        }
        [HttpPost("CompanyReview")]
        public async Task<object> CompanyReview(string companyName, string model = "gpt-4o")
        {
            var data = await _chatGptApiService.CompanyReview(companyName, model);

            return data;
        }
    }
}
