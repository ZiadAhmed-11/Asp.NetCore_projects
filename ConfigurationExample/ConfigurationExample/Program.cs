var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();

app.UseStaticFiles();
app.MapControllers();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.Map("/config", async context =>
    {
        await context.Response.WriteAsync(app.Configuration["MykEY\n"]);

        await context.Response.WriteAsync(app.Configuration.GetValue<string>("MykEY"));

    });
});
app.Run();
