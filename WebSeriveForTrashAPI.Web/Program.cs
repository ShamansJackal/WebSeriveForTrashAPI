using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using RestSharp;
using System.Text;
using WebSeriveForTrashAPI.Service.FileDownloader;
using WebSeriveForTrashAPI.Service.Telegram;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = Environment.GetEnvironmentVariable("JwtIssuer") != null,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = Environment.GetEnvironmentVariable("JwtIssuer"),
        ValidAudience = Environment.GetEnvironmentVariable("JwtIssuer"),
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            Environment.GetEnvironmentVariable("JwtKey") ?? throw new Exception("JWT signature key not found")
        ))
    };
});
builder.Services.AddAuthorization();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<RestClient>(x => new RestClient(new RestClientOptions("https://api.telegram.org")
{
    MaxTimeout = 10000,
    ThrowOnAnyError = false
}));
builder.Services.AddTransient<Messager>();
builder.Services.AddTransient<FileDownloader>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
