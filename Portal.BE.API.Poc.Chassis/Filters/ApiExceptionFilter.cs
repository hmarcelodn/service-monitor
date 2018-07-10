using Microsoft.AspNetCore.Mvc.Filters;
using Portal.BE.API.Poc.Chassis.Handlers;
using Portal.BE.API.Poc.Chassis.Logging;

namespace Portal.BE.API.Poc.Chassis.Filters
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            ApiError apiError = null;

            // Handle Errors thru the chain
            ErrorHandler apiErrorHanler = new ApiErrorHandler();
            ErrorHandler unauthorizedErrorHandler = new UnauthorizedErrorHandler();
            ErrorHandler unhandledErrorHandler = new UnhandledErrorHandler();

            // Set Handlers
            apiErrorHanler.SetNextHandler(unauthorizedErrorHandler);
            unauthorizedErrorHandler.SetNextHandler(unhandledErrorHandler);

            // Hanle
            apiErrorHanler.Handle(context, apiError);            

            base.OnException(context);
        }
    }
}
