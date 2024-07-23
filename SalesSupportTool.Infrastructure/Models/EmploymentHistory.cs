using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSupportTool.Infrastructure.ApolloApi.Models
{    public class EmploymentHistory
    {
        public string _id { get; set; }
        public object created_at { get; set; }
        public bool current { get; set; }
        public object degree { get; set; }
        public object description { get; set; }
        public object emails { get; set; }
        public string end_date { get; set; }
        public object grade_level { get; set; }
        public object kind { get; set; }
        public object major { get; set; }
        public string organization_id { get; set; }
        public string organization_name { get; set; }
        public object raw_address { get; set; }
        public string start_date { get; set; }
        public string title { get; set; }
        public object updated_at { get; set; }
        public string id { get; set; }
        public string key { get; set; }
    }
}
