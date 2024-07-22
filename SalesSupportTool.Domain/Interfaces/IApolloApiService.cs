using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSupportTool.Domain.Interfaces
{
    public interface IApolloApiService
    {
        Task<string> SearchCompanyAsync(string searchKey);
        Task<string> SearchPeopleAsync(string searchKey);

    }
}
