using Microsoft.AspNetCore.Mvc.Filters;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IECFW.Middlewares
{
    public class ExceptionHandlingFilter : ExceptionFilterAttribute // : IExceptionFilter
    {
        public override void OnException(ExceptionContext exceptionContext)
        {
            var exception = exceptionContext.Exception;
            //log your exception here

            exceptionContext.ExceptionHandled = true; //optional 


            var httpContext = exceptionContext.HttpContext;

            var userAgent = httpContext.Request.Headers["User-Agent"];
            var host = httpContext.Request.Host; // Value !
            var scheme = httpContext.Request.Scheme;

            var user = httpContext.User;  // user related information 

            //var requestForm = httpContext.Request.Form?.ToDictionary(x => x.Key, x => x.Value.ToString());
            //var requestQuery = httpContext.Request.Query.ToDictionary(x => x.Key, x => x.Value.ToString());


            var methodName = httpContext.Request?.Method;
            var pathValue = httpContext.Request?.Path.Value;

            var errorCode = HttpStatusCode.BadRequest;
        }
    }
}
