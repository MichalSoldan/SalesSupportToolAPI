namespace SalesSupportTool.Domain.Models.BuiltWithApi
{
    public class Result
    {
        public List<SpendHistory> SpendHistory { get; set; }
        public bool IsDB { get; set; }
        public int Spend { get; set; }
        public List<DomainPath> Paths { get; set; }
    }
}
