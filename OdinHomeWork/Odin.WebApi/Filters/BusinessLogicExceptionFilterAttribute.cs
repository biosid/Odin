using Odin.Services.Exceptions;
using Odin.Services.LoggingService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Helpers;
using System.Web.Http.Filters;

namespace Odin.WebApi.Filters
{
    public class BusinessLogicExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly ILogginingService _loggingService = new LogginingService();

        public override void OnException(HttpActionExecutedContext context)
        {

            _loggingService.LogError(context.Exception, Json.Encode(context.ActionContext.ActionArguments + "\r\n"));
            if (context.Exception is BusinessLogicException)
            {
                context.Response = context.Request.CreateErrorResponse(HttpStatusCode.BadRequest, context.Exception.Message);
                context.Request.CreateErrorResponse(HttpStatusCode.BadRequest, context.Exception.Message);

            }
        }
    }
}