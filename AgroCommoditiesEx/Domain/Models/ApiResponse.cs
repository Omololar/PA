using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Domain.Models
{
    public class ApiResponse<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
