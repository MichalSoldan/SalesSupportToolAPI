using SalesSupportTool.Domain.Interfaces;
using SalesSupportTool.Domain.Models.ChatGptApi;

namespace SalesSupportTool.Domain.Services
{
    public class ChatGptApiService(IChatGptApiProvider chatGptApiProvider) : IChatGptApiService
    {
        private readonly IChatGptApiProvider _chatGptApiProvider = chatGptApiProvider;

        public Task<CompletionsResponse> Completion(string prompt, string model = "gpt-4-turbo")
        {
            return chatGptApiProvider.Completions(prompt, model);
        }
    }
}
