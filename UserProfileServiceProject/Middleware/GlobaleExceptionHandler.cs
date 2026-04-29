using System.ComponentModel.DataAnnotations;
using System.Net;
using UserProject.Core.AppExceptions;

namespace UserProfileServiceProject.Middleware
{
    public class GlobaleExceptionHandler
    {
        private readonly RequestDelegate _next;

        public GlobaleExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); // Call the next middleware in the pipeline
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }


        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected
            var result = new { message = ex.Message };

            // Customize response based on exception type (if needed)
            if (ex is NotFoundAccountException)
            {
                code = HttpStatusCode.NotFound;
            }

            if (ex is UnauthorizedAccessException)
            {
                code = HttpStatusCode.NonAuthoritativeInformation;
            }

            else if (ex is EmailAlreadyTakenException)
            {
                code = HttpStatusCode.Conflict; // 409 for conflict
            }
            else if (ex is ValidationException)
            {
                code = HttpStatusCode.BadRequest;//400
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(result));
        }
    }



}
