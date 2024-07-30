namespace SalesSupportTool.Infrastructure.BuiltWithApi.Models
{
    public class DomainResult
    {
        public Result Result { get; set; }
        public Meta Meta { get; set; }
        public Attributes Attributes { get; set; }
        public long FirstIndexed { get; set; }
        public long LastIndexed { get; set; }
        public string Lookup { get; set; }
        public int SalesRevenue { get; set; }
    }
}
