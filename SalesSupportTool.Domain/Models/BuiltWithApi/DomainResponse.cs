namespace SalesSupportTool.Domain.Models.BuiltWithApi
{
    public class DomainResponse
    {
        public List<DomainResult> Results { get; set; }
        public List<Error> Errors { get; set; }
        public object Trust { get; set; }
    }
}
