using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSupportTool.Infrastructure.BuiltWithApi.Models
{
    public class Technology
    {
        public List<string> Categories { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Tag { get; set; }
        public long FirstDetected { get; set; }
        public long LastDetected { get; set; }
        public string IsPremium { get; set; }
        public string Parent { get; set; }
    }
}
