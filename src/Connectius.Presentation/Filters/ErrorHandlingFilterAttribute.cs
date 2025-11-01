using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Connectius.Presentation.Filters;

public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext exceptionContext)
    {
        var exception = exceptionContext.Exception;

        var details = new ProblemDetails()
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
            Title = "Um erro ocorreu durante o processamento da requisição",
            Status = (int)HttpStatusCode.InternalServerError
        };

        exceptionContext.Result = new ObjectResult(details);
        
        exceptionContext.ExceptionHandled = true;
    }
}