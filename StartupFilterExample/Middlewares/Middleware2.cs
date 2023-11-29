using Microsoft.Extensions.Logging;

namespace StartupFilterExample.Middlewares
{
    public class Middleware2
    {
        private readonly RequestDelegate _next;

        public Middleware2(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, ILogger<Middleware2> logger)
        {
            object? employeeId = httpContext.Items[Constants.EmployeeIdItemName];
            if (employeeId is not null)
            {
                logger.LogInformation($"{employeeId} - Middleware - 2");
            }
            await _next(httpContext);
        }
    }
}
