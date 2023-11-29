

namespace StartupFilterExample.Middlewares
{
    public class NameGeneratorMiddleware
    {
        private readonly RequestDelegate _next;

        public NameGeneratorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, ILogger<NameGeneratorMiddleware> logger)
        {
            object? employeeId = httpContext.Items[Constants.EmployeeIdItemName];
            if (employeeId is not null)
            {
                httpContext.Items[Constants.EmployeeNameItemName] = "Jane Doe";
            }
            else
            {
                httpContext.Items[Constants.EmployeeNameItemName] = "Unknown";
            }
            logger.LogInformation("NameGeneratorMiddleware");
            await _next(httpContext);
        }
    }
}
