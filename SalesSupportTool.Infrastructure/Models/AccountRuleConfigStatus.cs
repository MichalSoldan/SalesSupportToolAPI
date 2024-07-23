using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSupportTool.Infrastructure.ApolloApi.Models
{
    public class AccountRuleConfigStatus
    {
        public string _id { get; set; }
        public object created_at { get; set; }
        public string rule_action_config_id { get; set; }
        public string rule_config_id { get; set; }
        public string status_cd { get; set; }
        public object updated_at { get; set; }
        public string id { get; set; }
        public string key { get; set; }
    }
}
