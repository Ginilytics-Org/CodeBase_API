using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Ginilytics.Common.CustomExceptions;

namespace Ginilytics.Api.Startup.Setup.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                switch (ex)
                {
                    case CustomValidationException e:
                        await HandleExceptionAsync(httpContext, e);
                        break;
                    default:
                        await HandleExceptionAsync(httpContext, ex);
                        break;
                }
            }
        }




        #region exception handlers
        private async Task HandleExceptionAsync(HttpContext context, CustomValidationException exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadGateway;
            var errorDetails = new ErrorDetails
            {
                ErrorDescription = exception.Message
            };

            _logger.LogWarning("Validations failed:{0}", errorDetails.ErrorDescription);
            await context.Response.WriteAsync(JsonConvert.SerializeObject(errorDetails));
        }


        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var errorDetails = new ErrorDetails
            {
                ErrorDescription = exception.Message,
                InnerException = exception.InnerException?.Message,
                Source = exception.Source
            };

            _logger.LogError(exception.Message, exception);
            await context.Response.WriteAsync(JsonConvert.SerializeObject(errorDetails));
        }
        #endregion
    }
}