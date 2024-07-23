namespace SalesSupportTool.Infrastructure.ApolloApi.Models
{
    public class MixedCompanyResponse : BaseListingResponse
    {
        public List<Account> accounts { get; set; }
        public List<Organization> organizations { get; set; }
    }
}
