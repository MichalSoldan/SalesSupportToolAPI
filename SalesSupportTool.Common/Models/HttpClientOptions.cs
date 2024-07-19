using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSupportTool.Common.Models
{
    public class HttpClientOptions
    {
        public string ApiKey { get; set; }

        public Uri BaseAddress { get; set; }

        public string Password { get; set; }

        public int? RetryCount { get; set; }

        public TimeSpan? Timeout { get; set; }

        public string UserName { get; set; }

        public bool? UseAADToken { get; set; }

    }
}
