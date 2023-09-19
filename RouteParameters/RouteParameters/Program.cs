var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

/*app.MapGet("/", () => "Hello World!");*/
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.Map("files/{filename}.{extension?}", async (context) =>
    {
        string? filename = Convert.ToString(context.Request.RouteValues["filename"]);
        string? extension = Convert.ToString(context.Request.RouteValues["extension"]);

        await context.Response.WriteAsync($"In Files - {filename}.{extension} ");
    });
    endpoints.Map("employee/profile/{employee=ziad}", async (context) =>
    {
        string? EmployeeName = Convert.ToString(context.Request.RouteValues["employee"]);
        await context.Response.WriteAsync($"Employee Name : {EmployeeName}");
    });
});
app.Run(async context =>
{
    await context.Response.WriteAsync($"Request received at {context.Request.Path}");
});
app.Run();

