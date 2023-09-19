using RouteConstraints.CustomConstraints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(options => { options.ConstraintMap.Add("months",typeof(MonthsCustomConstraints));});

var app = builder.Build();

/*app.MapGet("/", () => "Hello World!");*/
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    // Part one :int :bool :datetime
    endpoints.Map("datereports/{datereport:datetime}", async (context) =>
    {
        DateTime? DateReport = Convert.ToDateTime(context.Request.RouteValues["datereport"]);
        await context.Response.WriteAsync($"Date : {DateReport}");
    });


    // Part three :minlength(3):maxlength(7) ( :length() :min() :max() :range() )-> numbers :alpha ->(a/z A/Z)   :regex(expresion) ->ex: egy.mobile number
    endpoints.Map("employee/profile/{employeename:length(3,7)=ziad}", async (context) =>
    {
        string? EmployeeName = Convert.ToString(context.Request.RouteValues["employeename"]);
        await context.Response.WriteAsync($"Employee Name : {EmployeeName}");
    });
});
app.Run(async context =>
{
    await context.Response.WriteAsync($"Request received at {context.Request.Path}");
});
app.Run();

