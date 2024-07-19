using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSupportTool.Common.Models
{
    public class JwtAuthOptions
    {
        public const string SettingsName = "JwtAuth";

        public string Audience { get; set; }

        public bool Enabled { get; set; } = true;

        public string Issuer { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Secret { get; set; }
    }
}
