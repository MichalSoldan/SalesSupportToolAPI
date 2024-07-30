namespace SalesSupportTool.Domain.Models.BuiltWithApi
{
    public class Technology
    {
        public List<string> Categories { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Tag { get; set; }
        public DateTime FirstDetected { get; set; }
        public DateTime LastDetected { get; set; }
        public bool IsPremium { get; set; }
        public string Parent { get; set; }
    }
}
