using CitiesManagerWebAPI.DataBaseContext;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
;
});

//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApiVersioning(config=>
{
    config.ApiVersionReader = new UrlSegmentApiVersionReader();
});

var app = builder.Build();
app.UseHttpsRedirection();

app.UseSwagger();  // creates endpoint for swagger.json : it contains all the info about all action method
app.UseSwaggerUI(); // swagger ui for testing all web api endpoints 

app.UseAuthorization();

app.MapControllers();

app.Run();
