using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSupportTool.Infrastructure.BuiltWithApi.Models
{    public class DomainPath
    {
        public List<Technology> Technologies { get; set; }
        public long FirstIndexed { get; set; }
        public long LastIndexed { get; set; }
        public string Domain { get; set; }
        public string Url { get; set; }
        public string SubDomain { get; set; }
    }
}
