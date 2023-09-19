var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//enable routing
app.UseRouting();
// creating end points
app.UseEndpoints(endpoints =>
{
    endpoints.Map("map1", async (context) =>
    {
        await context.Response.WriteAsync("In Map 1");
    });

    endpoints.Map("map2", async (context) =>
    {
        await context.Response.WriteAsync("In Map 2");
    });
});

app.Run(async (context)=>
{
    await context.Response.WriteAsync($"Request Received at {context.Request.Path}");
});
app.Run();
