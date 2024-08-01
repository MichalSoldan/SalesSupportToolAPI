using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSupportTool.Infrastructure.ApolloApi.Models
{
    public class Person
    {
        public string id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string name { get; set; }
        public string linkedin_url { get; set; }
        public string title { get; set; }
        public string email_status { get; set; }
        public string photo_url { get; set; }
        public string twitter_url { get; set; }
        public string github_url { get; set; }
        public string facebook_url { get; set; }
        public object extrapolated_email_confidence { get; set; }
        public string headline { get; set; }
        public object email { get; set; }
        public string organization_id { get; set; }
        public List<EmploymentHistory> employment_history { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public Organization organization { get; set; }
        public bool? is_likely_to_engage { get; set; }
        public string account_id { get; set; }
        public Account account { get; set; }
        public List<string> departments { get; set; }
        public List<string> subdepartments { get; set; }
        public string seniority { get; set; }
        public List<object> functions { get; set; }
        public List<DetailedPhoneNumber> phone_numbers { get; set; }
        public object intent_strength { get; set; }
        public bool? show_intent { get; set; }
        public bool? revealed_for_current_team { get; set; }
    }
}
