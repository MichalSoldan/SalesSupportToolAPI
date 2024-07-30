﻿namespace SalesSupportTool.Infrastructure.BuiltWithApi.Models
{
    public class Response
    {
        public List<DomainResult> Results { get; set; }
        public List<Error> Errors { get; set; }
        public object Trust { get; set; }
    }
}
