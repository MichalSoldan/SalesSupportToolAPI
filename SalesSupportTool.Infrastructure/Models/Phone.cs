using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSupportTool.Infrastructure.ApolloApi.Models
{
    public class Phone
    {
        public string number { get; set; }
        public string source { get; set; }
        public string sanitized_number { get; set; }
    }

    public class DetailedPhoneNumber
    {
        public string raw_number { get; set; }
        public string sanitized_number { get; set; }
        public string type { get; set; }
        public int? position { get; set; }
        public string status { get; set; }
        public object dnc_status { get; set; }
        public object dnc_other_info { get; set; }
        public object dialer_flags { get; set; }
    }
}
