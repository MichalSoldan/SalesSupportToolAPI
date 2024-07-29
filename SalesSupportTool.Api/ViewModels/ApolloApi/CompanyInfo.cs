using SalesSupportTool.Api.ViewModels;

namespace SalesSupportTool.Api.ViewModels.ApolloApi
{
    public class CompanyInfo : BaseModel
    {
        public List<Account> Accounts { get; set; }
        public List<Organization> Organizations { get; set; }
    }
}
