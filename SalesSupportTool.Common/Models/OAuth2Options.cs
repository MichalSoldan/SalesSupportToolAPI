namespace SalesSupportTool.Common.Models
{
    public class OAuth2Options
    {
        public const string SettingsName = "OAuth2";

        public string BackendAppId { get; set; }

        public string ClientAppId { get; set; }

        public string ClientAppSecret { get; set; }

        public string Instance { get; set; }

        public string Scope { get; set; }

        public string TenantId { get; set; }
    }
}