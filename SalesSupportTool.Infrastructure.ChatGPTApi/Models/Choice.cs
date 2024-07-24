using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSupportTool.Infrastructure.ChatGPTApi.Models
{
    public class Choice
    {
        public int index { get; set; }
        public Message message { get; set; }
        public object logprobs { get; set; }
        public string finish_reason { get; set; }
    }
}
