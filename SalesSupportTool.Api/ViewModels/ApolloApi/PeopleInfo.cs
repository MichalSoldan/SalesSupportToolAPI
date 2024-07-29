using SalesSupportTool.Api.ViewModels;

namespace SalesSupportTool.Api.ViewModels.ApolloApi
{
    public class PeopleInfo : BaseModel
    {
        //public List<object> Contacts { get; set; }
        public List<Person> People { get; set; }
    }
}
