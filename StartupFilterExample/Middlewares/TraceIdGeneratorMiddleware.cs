namespace StartupFilterExample.Middlewares
{
    public class TraceIdGeneratorMiddleware
    {
        private readonly RequestDelegate _next;

        public TraceIdGeneratorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, ILogger<TraceIdGeneratorMiddleware> logger)
        {
            logger.LogInformation("TraceIdGeneratorMiddleware");
            httpContext.Items[Constants.EmployeeIdItemName] = Guid.NewGuid();
            await _next(httpContext);
        }
    }
}
