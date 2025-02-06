using CryptoWeb.Service;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder();

builder.Services.AddScoped<VigenereService>();   // Registerar service

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "My ECRYPTER API", Version = "v1" });
});

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "My ENCRYPTER API V1");
    options.RoutePrefix = string.Empty;
});

app.MapControllers();
app.Run();
