namespace SalesSupportTool.Domain.Models.BuiltWithApi
{
    public class DomainResult
    {
        public Result Result { get; set; }
        public Meta Meta { get; set; }
        public Attributes Attributes { get; set; }
        public DateTime FirstIndexed { get; set; }
        public DateTime LastIndexed { get; set; }
        public string Lookup { get; set; }
        public int SalesRevenue { get; set; }
    }
}
