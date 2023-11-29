
using Microsoft.Extensions.Logging;

namespace StartupFilterExample.Middlewares
{
    public class Middleware1
    {
        private readonly RequestDelegate _next;

        public Middleware1(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, ILogger<Middleware1> logger)
        {
            object? employeeId = httpContext.Items[Constants.EmployeeIdItemName];
            if (employeeId is not null)
            {
                logger.LogInformation($"{employeeId} - Middleware - 1");
            }
            await _next(httpContext);
        }
    }
}
