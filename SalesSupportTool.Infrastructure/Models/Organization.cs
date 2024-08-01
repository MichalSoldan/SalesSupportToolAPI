using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSupportTool.Infrastructure.ApolloApi.Models
{
    public class OrganizationBase 
    {
        public string id { get; set; }
        public string name { get; set; }
        public string website_url { get; set; }
    }
    
    public class Organization : OrganizationBase
    {
        public object blog_url { get; set; }
        public object angellist_url { get; set; }
        public string linkedin_url { get; set; }
        public string twitter_url { get; set; }
        public string facebook_url { get; set; }
        public Phone primary_phone { get; set; }
        public List<string> languages { get; set; }
        public object alexa_ranking { get; set; }
        public string phone { get; set; }
        public string linkedin_uid { get; set; }
        public int? founded_year { get; set; }
        public object publicly_traded_symbol { get; set; }
        public object publicly_traded_exchange { get; set; }
        public string logo_url { get; set; }
        public object crunchbase_url { get; set; }
        public string primary_domain { get; set; }
        public object owned_by_organization_id { get; set; }
        public object intent_strength { get; set; }
        public bool? show_intent { get; set; }
        public bool? has_intent_signal_account { get; set; }
        public object intent_signal_account { get; set; }
        public string sanitized_phone { get; set; }
    }
}
