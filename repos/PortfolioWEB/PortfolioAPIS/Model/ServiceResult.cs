using FluentValidation.Results;
using System.Collections.Generic;
using System.Net;

namespace PortfolioAPIS.Model
{
    public class ServiceResult<T>
    {
        
        public T data { get; set; }

        public List<string> errorList { get; set; }
        public HttpStatusCode Http_Code { get; set; }
        public bool notFound { get; set; }
    }
}
