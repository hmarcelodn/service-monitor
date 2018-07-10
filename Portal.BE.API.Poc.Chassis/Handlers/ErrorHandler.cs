using Microsoft.AspNetCore.Mvc.Filters;
using Portal.BE.API.Poc.Chassis.Logging;
using System;

namespace Portal.BE.API.Poc.Chassis.Handlers
{
    public abstract class ErrorHandler
    {
        protected ErrorHandler NextHandler;

        public void SetNextHandler(ErrorHandler nextHandler) {
            this.NextHandler = nextHandler;
        }

        public abstract void Handle(ExceptionContext context, ApiError apiError);

        protected abstract bool CanHandle(Exception ex);
    }
}
