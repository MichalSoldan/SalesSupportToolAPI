namespace SalesSupportTool.Domain.Models.ApolloApi
{
    public class PeopleResponse : BaseListingResponse
    {
        public List<object> Contacts { get; set; }
        public List<Person> People { get; set; }
    }
}
