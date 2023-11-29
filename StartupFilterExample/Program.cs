using StartupFilterExample;
using StartupFilterExample.Middlewares;
using StartupFilterExample.StartupFilters;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IStartupFilter, TraceStartupFilter>();
builder.Services.AddTransient<IStartupFilter, NameStartupFilter>();


var app = builder.Build();
app.UseMiddleware<Middleware1>();
app.UseMiddleware<Middleware2>();

app.MapGet("/", (HttpContext context) => { 
    var employeeId = context.Items[Constants.EmployeeIdItemName];
    var employeeName = context.Items[Constants.EmployeeNameItemName];
    return Results.Ok(new { employeeId, employeeName});
});


app.Run();