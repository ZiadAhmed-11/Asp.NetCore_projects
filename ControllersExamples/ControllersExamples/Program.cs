using ControllersExamples.Controllers;

var builder = WebApplication.CreateBuilder(args);
/*builder.Services.AddTransient<HomeController>();         (1)                       */

builder.Services.AddControllers(); //Add all the Controller classes as services, And the short cut of 1

var app = builder.Build();

app.MapControllers();  // ( It internaly and automaticaly calls UseRouting() and UseEndpoints() ) 

/*app.UseRouting();
app.UseEndpoints(endpoints =>
{
    //endpoints.MapControllers();   (2)
    endpoints.MapControllers(); //the short cut of 2  ( Detect all the controller methods  )

});*/

app.Run();
