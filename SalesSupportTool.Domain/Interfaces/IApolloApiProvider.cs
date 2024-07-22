namespace SalesSupportTool.Domain.Interfaces
{
    public interface IApolloApiProvider
    {
        Task<string> SearchCompanyAsync(string searchKey, int candidateMaximumQuantity = 10);
        Task<string> SearchPeopleAsync(string searchKey, int candidateMaximumQuantity = 10);
    }
}
