var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

/*app.MapGet("/", () => "Hello World!");*/
app.UseRouting();

app.Use(async (context, next) => {
    Microsoft.AspNetCore.Http.Endpoint endpoint= context.GetEndpoint();
    await next();
});

app.UseRouting();

app.Run();
