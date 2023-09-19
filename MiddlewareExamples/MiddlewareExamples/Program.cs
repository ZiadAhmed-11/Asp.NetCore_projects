using MiddlewareExamples.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>();
var app = builder.Build();

app.UseMiddleware<MyCustomMiddleware>();

app.Run(async(HttpContext context) => {
    await context.Response.WriteAsync("Hello");

});

app.Run(async (HttpContext context) => {
    await context.Response.WriteAsync("Hello");

});

app.Run();
