﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSupportTool.Domain.Models.ChatGptApi
{
    public class Message
    {
        public string role { get; set; }
        public string content { get; set; }
    }
}
