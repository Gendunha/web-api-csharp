using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using System.Configuration;
using web_api_csharp.Models.Repos;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

static void ConfigureServices(IServiceCollection services)
{
    // Получение значения строки подключения
    var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
    string connString = configuration.GetSection("connectionString").Value;

    services.AddScoped<ICompanyRepository, CompanyRepository>();
    services.AddScoped<IFieldRepository, FieldRepository>();
    services.AddScoped<IWorkshopRepository, WorkshopRepository>();
    services.AddScoped<IWellRepository, WellRepository>();

    // Добавление строки подключения в сервисы
    services.AddSingleton(new ConnectionStringSettings { ConnectionString = connString });
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
