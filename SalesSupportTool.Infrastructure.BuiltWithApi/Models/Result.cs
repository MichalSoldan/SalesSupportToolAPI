using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSupportTool.Infrastructure.BuiltWithApi.Models
{
    public class Result
    {
        public SpendHistory[] SpendHistory { get; set; }
        public string IsDB { get; set; }
        public int Spend { get; set; }
        public Path[] Paths { get; set; }
    }
}
