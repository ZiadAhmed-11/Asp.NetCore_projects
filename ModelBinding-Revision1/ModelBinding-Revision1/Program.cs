var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var app = builder.Build();
app.UseRouting();
app.MapControllers();
app.UseStaticFiles();
app.MapGet("/", () => "Hello World!");

app.Run();
