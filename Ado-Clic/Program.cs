using System.Text;
using Ado_Clic.Handlers;
using Business.Services.Implementations;
using Business.Services.Interfaces;
using Infrastructure.DataContext;
using Infrastructure.Repositories.Implementations;
using Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddDbContext<AdoclicDataContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("Infrastructure")));

builder.Services.AddAuthentication("JwtCookie")
    .AddCookie("JwtCookie", options =>
    {
        options.LoginPath = "/signin"; // Redirect here if not authenticated
        options.AccessDeniedPath = "/AccessDenied";
    })
    .AddJwtBearer("Bearer", options =>
    {
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                var token = context.Request.Cookies["jwtToken"];
                Console.WriteLine("token is currently: " + token);
                if (!string.IsNullOrEmpty(token))
                {
                    context.Token = token;
                }
                return Task.CompletedTask;
            }
        };

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration.GetSection("Jwt:Issuer").Value,
            ValidAudience = builder.Configuration.GetSection("Jwt:Issuer").Value,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt:Key").Value))
        };
    });

var apiBaseUrl = builder.Configuration["ApiSettings:BaseUrl"];

builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient<JwtCookieHandler>();

builder.Services.AddHttpClient("ApiClient", client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
})
.AddHttpMessageHandler<JwtCookieHandler>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.Use(async (context, next) =>
{
    await next();

    if (context.Response.StatusCode == 401 && !context.User.Identity.IsAuthenticated)
    {
        context.Response.Redirect("/signin");
    }
});
app.UseAuthorization();

app.MapRazorPages();

app.MapControllers();

await app.RunAsync();