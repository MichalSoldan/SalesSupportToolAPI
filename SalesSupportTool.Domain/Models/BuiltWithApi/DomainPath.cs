namespace SalesSupportTool.Domain.Models.BuiltWithApi
{
    public class DomainPath
    {
        public List<Technology> Technologies { get; set; }
        public DateTime FirstIndexed { get; set; }
        public DateTime LastIndexed { get; set; }
        public string Domain { get; set; }
        public string Url { get; set; }
        public string SubDomain { get; set; }
    }
}
