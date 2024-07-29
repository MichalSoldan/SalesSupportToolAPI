namespace SalesSupportTool.Api.ViewModels.ApolloApi
{
    public class Person
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LinkedinUrl { get; set; }
        public string Title { get; set; }
        public string PhotoUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string GithubUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string Headline { get; set; }
        public string Email { get; set; }
        public List<EmploymentHistory> EmploymentHistory { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public List<string> Departments { get; set; }
        public List<string> SubDepartments { get; set; }
        public string Seniority { get; set; }
        public List<object> Functions { get; set; }
    }
}
