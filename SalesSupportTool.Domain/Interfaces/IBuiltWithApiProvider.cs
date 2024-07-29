using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSupportTool.Domain.Interfaces
{
    public interface IBuiltWithApiProvider
    {
        Task<object> GetDomain(string domain);
    }
}
