using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSupportTool.Api.ViewModels.ApolloApi
{
    public class OrganizationBase
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string WebsiteUrl { get; set; }
    }

    public class Organization : OrganizationBase
    {
        public object BlogUrl { get; set; }
        public object AngellistUrl { get; set; }
        public string LinkedinUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string Phone { get; set; }
        public List<string> Languages { get; set; }
        public int? FoundedYear { get; set; }
        public string LogoUrl { get; set; }
        public object CrunchbaseUrl { get; set; }
        public string PrimaryDomain { get; set; }
    }
}
