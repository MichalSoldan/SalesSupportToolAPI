namespace SalesSupportTool.Infrastructure.WebApi.Models
{
    public class ErrorResponseModel
    {
        public ErrorResponseModel? InnerException { get; set; }

        public string? Message { get; set; }

        public string? StackTrace { get; set; }
    }
}