using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSupportTool.Infrastructure.ApolloApi.Models
{
    public class BaseListingResponse
    {
        public List<Breadcrumb> breadcrumbs { get; set; }
        public bool partial_results_only { get; set; }
        public bool has_join { get; set; }
        public bool disable_eu_prospecting { get; set; }
        public int partial_results_limit { get; set; }
        public Pagination pagination { get; set; }
        public List<string> model_ids { get; set; }
        public int? num_fetch_result { get; set; }
        public DerivedParams derived_params { get; set; }
    }
}
