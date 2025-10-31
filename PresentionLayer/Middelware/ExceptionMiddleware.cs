using FluentValidation;
using System.Net;
using System.Text.Json;

namespace PresentionLayer.Middelware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
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
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private static async Task HandleExceptionAsync(HttpContext context,Exception exception)
        {
            context.Response.ContentType = "application/json";
            var statusCode = exception switch
            {
                ValidationException => HttpStatusCode.BadRequest, // 400
                KeyNotFoundException => HttpStatusCode.NotFound,  // 404
                UnauthorizedAccessException => HttpStatusCode.Unauthorized, // 401
                _ => HttpStatusCode.InternalServerError // 500
            };
            context.Response.StatusCode = (int)statusCode;
            var response = new
            {
                status = statusCode,
                message = exception.Message,
                details = exception is ValidationException fv
                   ? fv.Errors.Select(e => new { e.PropertyName, e.ErrorMessage })
                   : null
            };

            var json = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(json);

        }
    }
}
