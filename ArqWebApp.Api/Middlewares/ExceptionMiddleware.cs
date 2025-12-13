using ArqWebApp.Api.Models;
using System.Net;

namespace ArqWebApp.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var response = exception switch
            {
                KeyNotFoundException => new ErrorDetails
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Message = exception.Message
                },
                _ => new ErrorDetails
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Message = "Ocurrió un error interno"
                }
            };

            context.Response.StatusCode = response.StatusCode;
            return context.Response.WriteAsync(response.ToString());
        }
    }
}
