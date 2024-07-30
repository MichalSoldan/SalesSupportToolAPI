namespace SalesSupportTool.Infrastructure.BuiltWithApi.Models
{
    public class Response
    {
        public DomainResult[] Results { get; set; }
        public object[] Errors { get; set; }
        public object Trust { get; set; }
    }
}
