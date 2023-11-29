
using StartupFilterExample.Middlewares;

namespace StartupFilterExample.StartupFilters
{
    public class NameStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app => {
                app.UseMiddleware<NameGeneratorMiddleware>();
                next(app);
            };
        }
    }
}
