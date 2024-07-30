using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSupportTool.Infrastructure.BuiltWithApi.Models
{
    public class Meta
    {
        public int Majestic { get; set; }
        public int Umbrella { get; set; }
        public string Vertical { get; set; }
        public string[] Social { get; set; }
        public string CompanyName { get; set; }
        public object[] Telephones { get; set; }
        public string[] Emails { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
        public object Names { get; set; }
        public int ARank { get; set; }
        public int QRank { get; set; }
    }
}
