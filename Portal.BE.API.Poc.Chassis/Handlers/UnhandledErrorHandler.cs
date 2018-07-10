using Microsoft.AspNetCore.Mvc.Filters;
using Portal.BE.API.Poc.Chassis.Logging;
using Serilog;
using System;

namespace Portal.BE.API.Poc.Chassis.Handlers
{
    public class UnhandledErrorHandler : ErrorHandler
    {
        public override void Handle(ExceptionContext context, ApiError apiError)
        {
            if (CanHandle(context.Exception)) {
                var ex = context.Exception;
                var msg = ex.Message;
                var stack = ex.StackTrace;

                apiError = new ApiError(msg);
                apiError.detail = stack;             
                context.HttpContext.Response.StatusCode = 500;

                // Send Logs to App Insights
                Log.Error(ex, "UnhandledError");

                return;
            }
        }

        protected override bool CanHandle(Exception ex)
        {
            return true;
        }
    }
}
