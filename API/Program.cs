using API.Extensions;
using API.JwtFeatures;
using Domain.Interfaces.UnitOfWork;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Infrastructure.Data;
using Infrastructure.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Text.Json.Serialization;
using Microsoft.IdentityModel.Logging;
using API.SignalR;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var config = builder.Configuration;

IdentityModelEventSource.ShowPII = true;

// Config log
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(config)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

services.AddLogging();

//Config CORS
services.ConfigureCORS(MyAllowSpecificOrigins);

// Add services to the container.
services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// Add route with lower case
services.AddRouting(options => options.LowercaseUrls = true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.ConfigureSwagger();

// private key
var pathToKey = Path.Combine(Directory.GetCurrentDirectory(), config["Firebase:AdminSdkJsonFile"]);
GoogleCredential credential = GoogleCredential.FromFile(pathToKey);

// Create Firebase app
FirebaseApp.Create(new AppOptions
{
    Credential = credential,
    ProjectId = config["Firebase:ProjectId"],
    ServiceAccountId = config["Firebase:ServiceAccountId"]
});

string connectionString = Environment.GetEnvironmentVariable("PostgreSQLMaaSConnection");

if (string.IsNullOrEmpty(connectionString))
{
    connectionString = config.GetConnectionString("PostgreSQLMaaSConnection");
}

services.AddDbContextPool<AppDbContext>(options =>
        options.UseNpgsql(connectionString)
);

services.AddSignalR(cfg=>cfg.EnableDetailedErrors = true);

// Config for authentication
services.ConfigureAuthentication(config);

// Config for Identity
//services.ConfigureIdentity();

// Config for automapper
services.AddAutoMapper(typeof(Program));
//services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// IoC for Configuration
services.AddScoped<IJwtHandler, JwtHandler>();
services.AddSingleton<IConfiguration>(config);

// IoC for Repositories
services.ConfigureIoCRepositories();

// IoC for Services layer
services.ConfigureIoCServices();

// IoC for SignalR
services.ConfigureIoCSignalR();

// IoC for Quartz
services.ConfigureIoCCronJob();

#region IOC for Logging
services.AddLogging();
#endregion

#region IOC for UnitOfWork
services.AddScoped<IUnitOfWork, UnitOfWork>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MaaS API v1"));
}

app.UseHttpsRedirection();

// Using CORS
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapHub<SignalRHub>("/hubs");

app.Run();
