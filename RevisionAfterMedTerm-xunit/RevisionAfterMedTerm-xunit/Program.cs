using ServiceContracts;
using Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<ICountriesServices,CountriesService>();
builder.Services.AddSingleton<IPersonService,PersonsService >();

var app = builder.Build();
app.UseStaticFiles();
app.MapControllers();


app.Run();
