
using StartupFilterExample.Middlewares;

namespace StartupFilterExample.StartupFilters
{
    public class TraceStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app => {
                app.UseMiddleware<TraceIdGeneratorMiddleware>();
                next(app);
            };
        }
    }
}
