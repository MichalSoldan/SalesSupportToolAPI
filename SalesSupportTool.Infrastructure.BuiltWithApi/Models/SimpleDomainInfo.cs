using System.Text.Json.Serialization;

namespace SalesSupportTool.Infrastructure.BuiltWithApi.Models
{
    public class SimpleDomainInfo
    {
        [JsonPropertyName("postcode")]
        public string Postcode { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("techspend")]
        public int TechSpend { get; set; }

        [JsonPropertyName("revenue")]
        public string Revenue { get; set; }

        [JsonPropertyName("followers")]
        public int Followers { get; set; }

        [JsonPropertyName("companyname")]
        public string CompanyName { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("sku")]
        public int Sku { get; set; }

        [JsonPropertyName("root-ads")]
        public List<string> RootAds { get; set; }

        [JsonPropertyName("root-widgets")]
        public List<string> RootWidgets { get; set; }

        [JsonPropertyName("root-analytics")]
        public List<string> RootAnalytics { get; set; }

        [JsonPropertyName("root-docinfo")]
        public List<string> RootDocInfo { get; set; }

        [JsonPropertyName("root-shop")]
        public List<string> RootShop { get; set; }

        [JsonPropertyName("root-feeds")]
        public List<string> RootFeeds { get; set; }

        [JsonPropertyName("root-javascript")]
        public List<string> RootJavascript { get; set; }

        [JsonPropertyName("root-cms")]
        public List<string> RootCms { get; set; }

        [JsonPropertyName("root-WebMaster")]
        public List<string> RootWebMaster { get; set; }

        [JsonPropertyName("root-cdn")]
        public List<string> RootCdn { get; set; }

        [JsonPropertyName("root-media")]
        public List<string> RootMedia { get; set; }

        [JsonPropertyName("root-seo_headers")]
        public List<string> RootSeoHeaders { get; set; }

        [JsonPropertyName("root-cdns")]
        public List<string> RootCdns { get; set; }

        [JsonPropertyName("root-framework")]
        public List<string> RootFramework { get; set; }

        [JsonPropertyName("root-payment")]
        public List<string> RootPayment { get; set; }

        [JsonPropertyName("root-parked")]
        public List<string> RootParked { get; set; }

        [JsonPropertyName("root-encoding")]
        public List<string> RootEncoding { get; set; }

        [JsonPropertyName("root-WebServer")]
        public List<string> RootWebServer { get; set; }

        [JsonPropertyName("root-mobile")]
        public List<string> RootMobile { get; set; }

        [JsonPropertyName("root-mapping")]
        public List<string> RootMapping { get; set; }

        [JsonPropertyName("root-Server")]
        public List<string> RootServer { get; set; }

        [JsonPropertyName("root-mx")]
        public List<string> RootMx { get; set; }

        [JsonPropertyName("root-ssl")]
        public List<string> RootSsl { get; set; }

        [JsonPropertyName("root-link")]
        public List<string> RootLink { get; set; }

        [JsonPropertyName("root-hosting")]
        public List<string> RootHosting { get; set; }

        [JsonPropertyName("root-seo_title")]
        public List<string> RootSeoTitle { get; set; }

        [JsonPropertyName("root-seo_meta")]
        public List<string> RootSeoMeta { get; set; }

        [JsonPropertyName("root-agency")]
        public List<string> RootAgency { get; set; }

        [JsonPropertyName("root-ns")]
        public List<string> RootNs { get; set; }

        [JsonPropertyName("root-shipping")]
        public List<string> RootShipping { get; set; }

        [JsonPropertyName("root-language")]
        public List<string> RootLanguage { get; set; }

        [JsonPropertyName("root-copyright")]
        public List<string> RootCopyright { get; set; }

        [JsonPropertyName("root-robots")]
        public List<string> RootRobots { get; set; }

        [JsonPropertyName("root-registrar")]
        public List<string> RootRegistrar { get; set; }

        [JsonPropertyName("all-ads")]
        public List<string> AllAds { get; set; }

        [JsonPropertyName("all-widgets")]
        public List<string> AllWidgets { get; set; }

        [JsonPropertyName("all-analytics")]
        public List<string> AllAnalytics { get; set; }

        [JsonPropertyName("all-docinfo")]
        public List<string> AllDocInfo { get; set; }

        [JsonPropertyName("all-shop")]
        public List<string> AllShop { get; set; }

        [JsonPropertyName("all-feeds")]
        public List<string> AllFeeds { get; set; }

        [JsonPropertyName("all-javascript")]
        public List<string> AllJavascript { get; set; }

        [JsonPropertyName("all-cms")]
        public List<string> AllCms { get; set; }

        [JsonPropertyName("all-WebMaster")]
        public List<string> AllWebMaster { get; set; }

        [JsonPropertyName("all-cdn")]
        public List<string> AllCdn { get; set; }

        [JsonPropertyName("all-media")]
        public List<string> AllMedia { get; set; }

        [JsonPropertyName("all-seo_headers")]
        public List<string> AllSeoHeaders { get; set; }

        [JsonPropertyName("all-cdns")]
        public List<string> AllCdns { get; set; }

        [JsonPropertyName("all-framework")]
        public List<string> AllFramework { get; set; }

        [JsonPropertyName("all-payment")]
        public List<string> AllPayment { get; set; }

        [JsonPropertyName("all-parked")]
        public List<string> AllParked { get; set; }

        [JsonPropertyName("all-encoding")]
        public List<string> AllEncoding { get; set; }

        [JsonPropertyName("all-WebServer")]
        public List<string> AllWebServer { get; set; }

        [JsonPropertyName("all-mobile")]
        public List<string> AllMobile { get; set; }

        [JsonPropertyName("all-mapping")]
        public List<string> AllMapping { get; set; }

        [JsonPropertyName("all-Server")]
        public List<string> AllServer { get; set; }

        [JsonPropertyName("all-mx")]
        public List<string> AllMx { get; set; }

        [JsonPropertyName("all-ssl")]
        public List<string> AllSsl { get; set; }

        [JsonPropertyName("all-link")]
        public List<string> AllLink { get; set; }

        [JsonPropertyName("all-hosting")]
        public List<string> AllHosting { get; set; }

        [JsonPropertyName("all-seo_title")]
        public List<string> AllSeoTitle { get; set; }

        [JsonPropertyName("all-seo_meta")]
        public List<string> AllSeoMeta { get; set; }

        [JsonPropertyName("all-agency")]
        public List<string> AllAgency { get; set; }

        [JsonPropertyName("all-ns")]
        public List<string> AllNs { get; set; }

        [JsonPropertyName("all-shipping")]
        public List<string> AllShipping { get; set; }

        [JsonPropertyName("all-language")]
        public List<string> AllLanguage { get; set; }

        [JsonPropertyName("all-copyright")]
        public List<string> AllCopyright { get; set; }

        [JsonPropertyName("all-robots")]
        public List<string> AllRobots { get; set; }

        [JsonPropertyName("all-registrar")]
        public List<string> AllRegistrar { get; set; }

        [JsonPropertyName("nonroot-ads")]
        public List<string> NonRootAds { get; set; }

        [JsonPropertyName("nonroot-widgets")]
        public List<string> NonRootWidgets { get; set; }

        [JsonPropertyName("nonroot-analytics")]
        public List<string> NonRootAnalytics { get; set; }

        [JsonPropertyName("nonroot-docinfo")]
        public List<string> NonRootDocInfo { get; set; }

        [JsonPropertyName("nonroot-shop")]
        public List<string> NonRootShop { get; set; }

        [JsonPropertyName("nonroot-feeds")]
        public List<string> NonRootFeeds { get; set; }

        [JsonPropertyName("nonroot-javascript")]
        public List<string> NonRootJavascript { get; set; }

        [JsonPropertyName("nonroot-cms")]
        public List<string> NonRootCms { get; set; }

        [JsonPropertyName("nonroot-WebMaster")]
        public List<string> NonRootWebMaster { get; set; }

        [JsonPropertyName("nonroot-cdn")]
        public List<string> NonRootCdn { get; set; }

        [JsonPropertyName("nonroot-media")]
        public List<string> NonRootMedia { get; set; }

        [JsonPropertyName("nonroot-seo_headers")]
        public List<string> NonRootSeoHeaders { get; set; }

        [JsonPropertyName("nonroot-cdns")]
        public List<string> NonRootCdns { get; set; }

        [JsonPropertyName("nonroot-framework")]
        public List<string> NonRootFramework { get; set; }

        [JsonPropertyName("nonroot-payment")]
        public List<string> NonRootPayment { get; set; }

        [JsonPropertyName("nonroot-parked")]
        public List<string> NonRootParked { get; set; }

        [JsonPropertyName("nonroot-encoding")]
        public List<string> NonRootEncoding { get; set; }

        [JsonPropertyName("nonroot-WebServer")]
        public List<string> NonRootWebServer { get; set; }

        [JsonPropertyName("nonroot-mobile")]
        public List<string> NonRootMobile { get; set; }

        [JsonPropertyName("nonroot-mapping")]
        public List<string> NonRootMapping { get; set; }

        [JsonPropertyName("nonroot-Server")]
        public List<string> NonRootServer { get; set; }

        [JsonPropertyName("nonroot-mx")]
        public List<string> NonRootMx { get; set; }

        [JsonPropertyName("nonroot-ssl")]
        public List<string> NonRootSsl { get; set; }

        [JsonPropertyName("nonroot-link")]
        public List<string> NonRootLink { get; set; }

        [JsonPropertyName("nonroot-hosting")]
        public List<string> NonRootHosting { get; set; }

        [JsonPropertyName("nonroot-seo_title")]
        public List<string> NonRootSeoTitle { get; set; }

        [JsonPropertyName("nonroot-seo_meta")]
        public List<string> NonRootSeoMeta { get; set; }

        [JsonPropertyName("nonroot-agency")]
        public List<string> NonRootAgency { get; set; }

        [JsonPropertyName("nonroot-ns")]
        public List<string> NonRootNs { get; set; }

        [JsonPropertyName("nonroot-shipping")]
        public List<string> NonRootShipping { get; set; }

        [JsonPropertyName("nonroot-language")]
        public List<string> NonRootLanguage { get; set; }

        [JsonPropertyName("nonroot-copyright")]
        public List<string> NonRootCopyright { get; set; }

        [JsonPropertyName("nonroot-robots")]
        public List<string> NonRootRobots { get; set; }

        [JsonPropertyName("nonroot-registrar")]
        public List<string> NonRootRegistrar { get; set; }

        [JsonPropertyName("twitter")]
        public string Twitter { get; set; }

        [JsonPropertyName("facebook")]
        public string Facebook { get; set; }

        [JsonPropertyName("linkedin")]
        public string LinkedIn { get; set; }

        [JsonPropertyName("youtube")]
        public string YouTube { get; set; }

        [JsonPropertyName("instagram")]
        public string Instagram { get; set; }

        [JsonPropertyName("vimeo")]
        public string Vimeo { get; set; }
    }
}
