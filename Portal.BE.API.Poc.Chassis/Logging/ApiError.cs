using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Portal.BE.API.Poc.Chassis.Logging
{
    public class ApiError: Exception
    {
        public string message { get; set; }
        public bool isError { get; set; }
        public string detail { get; set; }
        public IList<string> errors { get; set; }

        public ApiError(string message)
        {
            this.message = message;
            this.isError = true;
        }

        public ApiError(ModelStateDictionary modelState)
        {
            this.isError = true;

            if (modelState != null && modelState.Any(m => m.Value.Errors.Count > 0)) {
                message = "Correct errors and try again";
            }
        }
    }
}
