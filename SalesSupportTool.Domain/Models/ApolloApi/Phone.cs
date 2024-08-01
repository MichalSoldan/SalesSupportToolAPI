using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSupportTool.Domain.Models.ApolloApi
{
    public class Phone
    {
        public string Number { get; set; }
        public string Source { get; set; }
        public string Sanitized_number { get; set; }
    }

    public class DetailedPhoneNumber
    {
        public string Raw_number { get; set; }
        public string Sanitized_number { get; set; }
        public string Type { get; set; }
        public int? Position { get; set; }
        public string Status { get; set; }
        public object Dnc_status { get; set; }
        public object Dnc_other_info { get; set; }
        public object Dialer_flags { get; set; }
    }
}
