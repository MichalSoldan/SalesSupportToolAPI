using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSupportTool.Domain.Models.ApolloApi
{
    public class Account
    {
        public string id { get; set; }
        public string name { get; set; }
        public string website_url { get; set; }
        public object blog_url { get; set; }
        public object angellist_url { get; set; }
        public string linkedin_url { get; set; }
        public string twitter_url { get; set; }
        public string facebook_url { get; set; }
        public Phone primary_phone { get; set; }
        public List<string> languages { get; set; }
        public int alexa_ranking { get; set; }
        public string phone { get; set; }
        public string linkedin_uid { get; set; }
        public int founded_year { get; set; }
        public object publicly_traded_symbol { get; set; }
        public object publicly_traded_exchange { get; set; }
        public string logo_url { get; set; }
        public object crunchbase_url { get; set; }
        public string primary_domain { get; set; }
        public string sanitized_phone { get; set; }
        public string owned_by_organization_id { get; set; }
        public OrganizationBase owned_by_organization { get; set; }
        public string organization_raw_address { get; set; }
        public string organization_city { get; set; }
        public string organization_street_address { get; set; }
        public string organization_state { get; set; }
        public string organization_country { get; set; }
        public string organization_postal_code { get; set; }
        public bool suggest_location_enrichment { get; set; }
        public string domain { get; set; }
        public string team_id { get; set; }
        public string organization_id { get; set; }
        public string account_stage_id { get; set; }
        public string source { get; set; }
        public string original_source { get; set; }
        public object creator_id { get; set; }
        public string owner_id { get; set; }
        public DateTime created_at { get; set; }
        public string phone_status { get; set; }
        public object hubspot_id { get; set; }
        public object salesforce_id { get; set; }
        public object crm_owner_id { get; set; }
        public object parent_account_id { get; set; }
        public List<object> account_playbook_statuses { get; set; }
        public string existence_level { get; set; }
        public List<string> label_ids { get; set; }
        public object typed_custom_fields { get; set; }
        public string modality { get; set; }
        public string source_display_name { get; set; }
        public object crm_record_url { get; set; }
        public List<object> contact_emailer_campaign_ids { get; set; }
        public object contact_campaign_status_tally { get; set; }
        public int num_contacts { get; set; }
        public object last_activity_date { get; set; }
        public object intent_strength { get; set; }
        public bool show_intent { get; set; }
        public bool has_intent_signal_account { get; set; }
        public object intent_signal_account { get; set; }
    }
}
