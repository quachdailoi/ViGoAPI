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
using API.Middleware;
using AutoMapper;
using API.Mapper;
using API.Services.Constract;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var _config = builder.Configuration;

// Config log
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(_config)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

services.AddLogging();

//Config CORS
services.ConfigureCORS(MyAllowSpecificOrigins);

//API versioning
services.ConfigureApiVersioning();

// Add services to the container.
services.AddControllers(option =>
{
    option.AllowEmptyInputInBodyModelBinding = true;
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

//services.AddFluentValidationAutoValidation();
//services.AddValidatorsFromAssemblyContaining<InformationRequestValidator>();

// Add route with lower case
services.AddRouting(options => options.LowercaseUrls = true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.ConfigureSwagger();

// private key
var pathToKey = Path.Combine(Directory.GetCurrentDirectory(), _config["Firebase:AdminSdkJsonFile"]);
GoogleCredential credential = GoogleCredential.FromFile(pathToKey);

// Create Firebase app
FirebaseApp.Create(new AppOptions
{
    Credential = credential,
    ProjectId = _config["Firebase:ProjectId"],
    ServiceAccountId = _config["Firebase:ServiceAccountId"]
});

string connectionString = string.Empty;

if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "production")
{
    // Use connection string provided at runtime by Heroku.
    var connectionUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

    connectionUrl = connectionUrl.Replace("postgres://", string.Empty);
    var userPassSide = connectionUrl.Split("@")[0];
    var hostSide = connectionUrl.Split("@")[1];

    var user = userPassSide.Split(":")[0];
    var password = userPassSide.Split(":")[1];
    var host = hostSide.Split("/")[0];
    var database = hostSide.Split("/")[1].Split("?")[0];

    connectionString = $"Host={host};Database={database};Username={user};Password={password};SSL Mode=Require;Trust Server Certificate=true";
} else
{
    connectionString = _config.GetConnectionString("PostgreSQLMaaSConnection");
}

services.AddDbContextPool<AppDbContext>(options =>
        options.UseNpgsql(connectionString)
);

//var serviceProvider = builder.Services.BuildServiceProvider();
//try
//{
//    var dbContext = serviceProvider.GetRequiredService<AppDbContext>();
//    dbContext.Database.Migrate();
//}
//catch
//{
//}

// config for signalR
services.AddSignalR(cfg =>
{
    cfg.EnableDetailedErrors = true;
});

// Config for authentication
services.ConfigureAuthentication(_config);

// Config for Identity
//services.ConfigureIdentity();

// Config for automapper
services.AddAutoMapper(typeof(Program));
//services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// config class for settings: JwtSettings
services.ConfigureSettings(builder);

// IoC for Configuration
services.AddScoped<IJwtHandler, JwtHandler>();
services.AddSingleton<IConfiguration>(_config);

// IoC for Repositories
services.ConfigureIoCRepositories();

// IoC for Services layer
services.ConfigureIoCServices();

// IoC For Profile
services.AddSingleton(provider => new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new UserMappingProfile(provider.CreateScope().ServiceProvider.GetService<IFileService>()));

}).CreateMapper());

// add http context accessor
services.AddHttpContextAccessor();

// IoC for SignalR
services.ConfigureIoCSignalR();

// IoC for CronJobs
services.ConfigureIoCCronJob();

// add redis cache
var redisSetting = _config["RedisSettings:ConnectionString"];
if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "production")
{
    redisSetting = Environment.GetEnvironmentVariable("RedisSettings:ConnectionString");
}
services.AddStackExchangeRedisCache(r => r.Configuration = redisSetting);


#region IOC for Logging
services.AddLogging();
#endregion

#region IOC for UnitOfWork
services.AddScoped<IUnitOfWork, UnitOfWork>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        //c.SwaggerEndpoint("/swagger/v1/swagger.json", "MaaS API v1");
        foreach (var desc in provider.ApiVersionDescriptions)
        {
            c.SwaggerEndpoint($"/swagger/{desc.GroupName}/swagger.json", $"Vigo API {desc.GroupName.ToUpperInvariant()}");
        }
        c.DisplayRequestDuration();
    });
    IdentityModelEventSource.ShowPII = true;
}

app.UseHttpsRedirection();

// add middlewares
//app.UseErrorHandlerMiddleware();
app.UseJwtMiddleware();

// Using CORS
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapHub<SignalRHub>("hubs");

app.Run();
