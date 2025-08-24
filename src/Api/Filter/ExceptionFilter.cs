using Application.DTOs.Responses;
using Exception.ExceptionBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filter
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ScheduleExceptionBase)
                HandlerProjectException(context);
            else
                ThrowUnkownError(context);
        }

        public void HandlerProjectException(ExceptionContext context)
        {
            var cashFlowException = (ScheduleExceptionBase)context.Exception;
            var errorResponse = new ErrorResponseDTO(cashFlowException.GetErrors());
            context.HttpContext.Response.StatusCode = cashFlowException.StatusCode;
            context.Result = new ObjectResult(errorResponse);
        }

        public void ThrowUnkownError(ExceptionContext context)
        {
            var errorResponse = new ErrorResponseDTO("Unkown error");
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(errorResponse);
        }
    }
}
