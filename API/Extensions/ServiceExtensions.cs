using API.Models.Settings;
using API.Quartz;
using API.Quartz.Jobs;
using API.Services;
using API.Services.Constract;
using API.SignalR;
using API.SignalR.Constract;
using Domain.Interfaces.Repositories;
using Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Quartz.Spi;
using System.Reflection;
using System.Text;

namespace API.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCORS(this IServiceCollection services, string corsName)
        {
             services.AddCors(options =>
             {
                options.AddPolicy(name: corsName,
                    policy =>
                    {
                        policy.AllowAnyOrigin();
                        policy.AllowAnyMethod();
                        policy.AllowAnyHeader();
                    });
             });
        }

        public static void ConfigureAuthentication(this IServiceCollection services, ConfigurationManager config)
        {
            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = config["JwtSettings:Issuer"];
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = config["JwtSettings:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = config["JwtSettings:Audience"],
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtSettings:Key"])),
                };
                options.RequireHttpsMetadata = false;

                // configure to get accesstoken from hubs url
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        var accessToken = context.Request.Query["access_token"].FirstOrDefault();

                        var path = context.HttpContext.Request.Path;
                        if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/hubs"))
                        {
                            context.Token = accessToken;
                        }

                        return Task.CompletedTask;
                    }
                };
            });

        }

        public static void ConfigureIoCRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IVerifiedCodeRepository, VerifiedCodeRepository>();
            services.AddScoped<IUserRoomRepository, UserRoomRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IFileRepository, FileRepository>();
        }

        public static void ConfigureIoCServices(this IServiceCollection services)
        {
            services.AddTransient<IAppServices, AppServices>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IVerifiedCodeService, VerifiedCodeService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IBookerService, BookerService>();
            services.AddTransient<IDriverService, DriverService>();
            services.AddTransient<IUserRoomService, UserRoomService>();
            services.AddTransient<IRoomService, RoomService>();
            services.AddTransient<IMessageService, MessageService>();
            services.AddTransient<IFileService, FileService>();
        }

        public static void ConfigureIoCSignalR(this IServiceCollection services)
        {
            services.AddTransient<ISignalRService, SignalRService>();
        }

        public static void ConfigureIoCCronJob(this IServiceCollection services)
        {
            // Sign job
            services.AddTransient<MessageJob>();

            services.AddTransient<IJobFactory, JobFactory>();
            services.AddSingleton<IJobScheduler, JobScheduler>();
        }
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "MaaS API Project", Version = "v1" });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Description = "Bearer Authentication with JWT Token",
                    Type = SecuritySchemeType.ApiKey,
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        },
                        new string[]{}
                    }
                });

                // configure swagger xml description
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var filePath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(filePath);
            });
        }

        public static void ConfigureSettings(this IServiceCollection services, WebApplicationBuilder builder)
        {
            // configure strongly typed settings object
            // this project not use because must load config by environment
        }
    }
}
