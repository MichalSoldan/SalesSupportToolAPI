namespace SalesSupportTool.Domain.Interfaces
{
    public interface IJwtAuthService
    {
        string IssueJwtToken(string login);
    }
}