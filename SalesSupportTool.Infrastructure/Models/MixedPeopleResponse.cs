namespace SalesSupportTool.Infrastructure.ApolloApi.Models
{
    public class MixedPeopleResponse : BaseListingResponse
    {
        public List<object> contacts { get; set; }
        public List<Person> people { get; set; }
    }
}
