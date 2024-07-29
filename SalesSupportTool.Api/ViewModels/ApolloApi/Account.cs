namespace SalesSupportTool.Api.ViewModels.ApolloApi
{
    public class Account
    {

        /// <summary>
        /// Gets or sets the company name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the company address
        /// </summary>
        public string FullAddress { get; set; }

        /// <summary>
        /// Gets or sets the company phone number
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the company website
        /// </summary>
        public string Website { get; set; }
        public string Domain { get; set; }
    }
}
