using MiddlewareExamples2.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);

//Custom Middleware Add
builder.Services.AddTransient<MyCustomMiddleware>();

var app = builder.Build();

/*app.MapGet("/", () => "Hello World!");*/
app.Use(async (HttpContext context,RequestDelegate Next) => {
    await context.Response.WriteAsync("Hello\n");
    await Next(context);
});

//Custom Middleware call
app.UseMiddleware<MyCustomMiddleware>();

app.Run(async (HttpContext context) => {
    await context.Response.WriteAsync("Hello Again");
});

app.Run();