using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSupportTool.Infrastructure.ApolloApi.Models
{
    public class Breadcrumb
    {
        public string label { get; set; }
        public string signal_field_name { get; set; }
        public string value { get; set; }
        public string display_name { get; set; }
    }
}
