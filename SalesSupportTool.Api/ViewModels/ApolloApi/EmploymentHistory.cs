using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSupportTool.Api.ViewModels.ApolloApi
{
    public class EmploymentHistory
    {
        public bool IsCurrent { get; set; }
        public string Description { get; set; }
        public DateTime? EndDate { get; set; }
        public string OrganizationName { get; set; }
        public DateTime? StartDate { get; set; }
        public string Title { get; set; }
    }
}
