using Assignment_Controller;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var app = builder.Build();
app.UseStaticFiles();
app.MapControllers();


BankAccount a1 = new BankAccount();
a1.currentBalance = 1001;
a1.accountHolderName = "Example Name";
a1.currentBalance = 5000;

app.Run();
