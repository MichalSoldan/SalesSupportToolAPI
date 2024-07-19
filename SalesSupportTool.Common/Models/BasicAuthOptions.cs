namespace SalesSupportTool.Common.Models
{
    public class BasicAuthOptions
    {
        public const string SettingsName = "BasicAuth";

        public bool Enabled { get; set; }

        public string Password { get; set; }

        public string UserName { get; set; }
    }
}