namespace SalesSupportTool.Api.ViewModels.ApolloApi
{
    public class Account
    {
        public string Name { get; set; }
        public string FullAddress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneStatus { get; set; }
        public string WebsiteUrl { get; set; }
        public string LinkedInUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string Domain { get; set; }
        public string AccountStageId { get; set; }
        public string OwnedByOrganizationName { get; set; }
        public string OwnedByOrganizationWebsiteUrl { get; set; }
        public DateTime? LastActivityDate { get; set; }
    }
}
