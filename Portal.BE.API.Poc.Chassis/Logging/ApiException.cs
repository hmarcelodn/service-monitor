using System;
using System.Collections.Generic;

namespace Portal.BE.API.Poc.Chassis.Logging
{
    public class ApiException : Exception
    {
        public int StatusCode { get; set; }

        public IList<string> Errors { get; set; }

        public ApiException(string message,
                            int statusCode = 500,
                            IList<string> errors = null) 
            : base(message)
        {
            this.StatusCode = statusCode;
            this.Errors = errors;
        }

        public ApiException(Exception ex, int statusCode = 500) 
            : base(ex.Message)
        {
            this.StatusCode = statusCode;
        }
    }
}
