using SalesSupportTool.Domain.Models.ChatGptApi;

namespace SalesSupportTool.Domain.Interfaces
{
    public interface IChatGptApiService
    {
        Task<CompletionsResponse> Completion(string prompt, string model = "gpt-4o");
        Task<object> CompanyReview(string companyName, string model = "gpt-4o");
    }
}
