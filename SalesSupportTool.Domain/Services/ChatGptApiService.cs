using SalesSupportTool.Domain.Interfaces;
using SalesSupportTool.Domain.Models.ChatGptApi;

namespace SalesSupportTool.Domain.Services
{
    public class ChatGptApiService(IChatGptApiProvider chatGptApiProvider) : IChatGptApiService
    {
        private readonly IChatGptApiProvider _chatGptApiProvider = chatGptApiProvider;

        public Task<object> CompanyReview(string companyName, string model = "gpt-4o")
        {
            return chatGptApiProvider.CompanyReview(companyName, model);
        }

        public Task<CompletionsResponse> Completion(string prompt, string model = "gpt-4o")
        {
            return chatGptApiProvider.Completions(prompt, model);
        }
    }
}
