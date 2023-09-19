/*var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.Map("/", async context =>
    {
        await context.Response.WriteAsync("Hello");
    });
});
app.Run();
*/

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("countries/{countryID:int?}", async (context) =>
    {
        if(!context.Request.RouteValues.ContainsKey("countryID"))
        {
            await context.Response.WriteAsync("1, United States\n2, Canada\n3, United Kingdom\n4, Indian\n5, Japan");
        }
        else
        {
            string[] countries = {"United Statees","Canada","United Kingdom","India","Japan"};
            int countryid = Convert.ToInt32(context.Request.RouteValues["countryID"]);
            await context.Response.WriteAsync($"{countries[countryid-1]}");
        }
    });
});
app.Run();