using SalesSupportTool.Domain.Models.ApolloApi;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSupportTool.Domain.Interfaces
{
    public interface IApolloApiService
    {
        Task<CompanyResponse> SearchCompanyAsync(string searchKey);
        Task<PeopleResponse> SearchPeopleAsync(string searchKey);

    }
}
