using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GoodReads.Application
{
    public class Result
    {
        public HttpStatusCode StatusCode { get; private set; }
        public bool IsSuccess { get; private set; }
        public object Value { get; private set; }
        public List<string> Errors { get; private set; }

        // Old methods
        public static Result Success(object value)
        {
            return new Result() { IsSuccess = true, Value = value };
        }

        public static Result NotFound(object value, List<string> errors)
        {
            return new Result()
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.NotFound,
                Value = value,
                Errors = errors,
            };
        }

        // new 
        public static Result BadRequest(object value, List<string> errors) => new Result { Value = value, IsSuccess = false, Errors = errors, StatusCode = HttpStatusCode.BadRequest };

    }
}
