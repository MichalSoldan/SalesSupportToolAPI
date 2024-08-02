using SalesSupportTool.Domain.Models.ChatGptApi;

namespace SalesSupportTool.Domain.Interfaces
{
    public interface IChatGptApiProvider
    {
        Task<CompletionsResponse> Completions(string prompt, string model = "gpt-4o");
        Task<object> CompanyReview(string companyName, string model = "gpt-4o");
    }
}
