using Microsoft.AspNetCore.Mvc.Filters;
using Portal.BE.API.Poc.Chassis.Logging;
using Serilog;
using Serilog.Events;
using System;

namespace Portal.BE.API.Poc.Chassis.Handlers
{
    public class ApiErrorHandler : ErrorHandler
    {
        public override void Handle(ExceptionContext context, ApiError apiError)
        {
            if (CanHandle(context.Exception))
            {
                var ex = (ApiException)context.Exception;
                apiError = new ApiError(ex.Message);
                apiError.errors = ex.Errors;
                context.HttpContext.Response.StatusCode = ex.StatusCode;

                // Send Logs to AI
                Log.Error(ex, "ApiError");
            }
            else
            {
                this.NextHandler.Handle(context, apiError);
            }
        }

        protected override bool CanHandle(Exception ex)
        {
            return (ex is ApiException);
        }
    }
}
