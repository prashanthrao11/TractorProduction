using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TractorProduction.Web.Models
{
    public class Response<T>
    {
        public T Model { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}
