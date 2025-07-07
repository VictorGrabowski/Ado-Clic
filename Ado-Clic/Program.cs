using Ado_Clic.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseInMemoryDatabase("name"));
var app = builder.Build();

app.MapRazorPages();    
app.Run();