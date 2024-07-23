using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSupportTool.Infrastructure.ApolloApi.Models
{
    public class Pagination
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total_entries { get; set; }
        public int total_pages { get; set; }
    }
}
