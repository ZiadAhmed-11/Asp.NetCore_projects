var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

/*app.MapGet("/", () => "Hello World!");
*/
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    //add your end points
    endpoints.Map("/ziad",async (context) => { await context.Response.WriteAsync("Hello Mr. Ziad"); });

    endpoints.Map("/Ahmed", () => "Hello Mr. Ahmed");

});
app.Run(async context =>
{
    await context.Response.WriteAsync($"Request received at {context.Request.Path}");
});
app.Run();

