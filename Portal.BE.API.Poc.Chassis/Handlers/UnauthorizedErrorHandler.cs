using Microsoft.AspNetCore.Mvc.Filters;
using Portal.BE.API.Poc.Chassis.Logging;
using Serilog;
using System;

namespace Portal.BE.API.Poc.Chassis.Handlers
{
    public class UnauthorizedErrorHandler : ErrorHandler
    {
        public override void Handle(ExceptionContext context, ApiError apiError)
        {
            if (CanHandle(context.Exception))
            {
                var ex = (UnauthorizedAccessException)context.Exception;
                apiError = new ApiError("Unauthorized Access");
                context.HttpContext.Response.StatusCode = 401;

                // Send Logs to App Insights
                Log.Error(ex, "UnauthorizedAccess");
            }
            else
            {
                this.NextHandler.Handle(context, apiError);
            }
        }

        protected override bool CanHandle(Exception ex)
        {
            return (ex is UnauthorizedAccessException);
        }
    }
}
