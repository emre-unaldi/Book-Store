using BookStore.Services;
using System.Diagnostics;
using System.Net;
using System.Text.Json;

namespace BookStore.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private ILoggerService _logger;

        public CustomExceptionMiddleware(RequestDelegate next, ILoggerService logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var watch = Stopwatch.StartNew();
            try
            {
                string message = "[Request]  HTTP "
                    + context.Request.Method + " - "
                    + context.Request.Path;

                await _next(context);
                watch.Stop();

                message = "[Response] HTTP "
                    + context.Request.Method + " - "
                    + context.Request.Path + " responded "
                    + context.Response.StatusCode + " in "
                    + watch.Elapsed.TotalMilliseconds + " ms";

                _logger.Log(message);
            }
            catch (Exception ex)
            {
                watch.Stop();
                await HandleException(context, ex, watch);
            }
        }

        private Task HandleException(HttpContext context, Exception ex, Stopwatch watch)
        {
            string message = "[Error]  HTTP "
                + context.Request.Method + " - "
                + context.Response.StatusCode
                + " Error Message " + ex.Message
                + " in " + watch.Elapsed.TotalMilliseconds + " ms";

            _logger.Log(message);

            var errorDetails = new ErrorDetail
            {
                Errors = ex.Message
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var json = JsonSerializer.Serialize(errorDetails);

            return context.Response.WriteAsync(json);
        }
    }

    public static class CustomExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }

    public class ErrorDetail
    {
        public string Errors { get; set; }
    }
}
