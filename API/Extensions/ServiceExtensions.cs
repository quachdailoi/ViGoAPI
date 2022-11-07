using API.Helpers;
using API.Models.Settings;
using API.Quartz;
using API.Quartz.Jobs;
using API.TaskQueues;
using API.Services;
using API.Services.Constract;
using API.SignalR;
using API.SignalR.Constract;
using Domain.Interfaces.Repositories;
using Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Quartz.Spi;
using System.Reflection;
using System.Text;
using API.TaskQueues.TaskResolver;
using Microsoft.AspNetCore.Http.Json;
using API.Utils;
using FluentValidation;
using API.Validators;
using API.Worker;
using API.Models.DTO;
using Microsoft.Extensions.Hosting;

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
                    ClockSkew = TimeSpan.Zero
                };
                options.RequireHttpsMetadata = false;

                // configure to get accesstoken from hubs url
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        var accessToken = context.Request.Query["access_token"].FirstOrDefault();

                        var path = context.HttpContext.Request.Path;
                        if (!string.IsNullOrEmpty(accessToken) && (path.StartsWithSegments("/hubs") || path.StartsWithSegments("/gps")))
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
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IBookingDetailRepository, BookingDetailRepository>();
            services.AddScoped<IBookingDetailDriverRepository, BookingDetailDriverRepository>();
            services.AddScoped<IPromotionUserRepository, PromotionUserRepository>();
            services.AddScoped<IPromotionRepository, PromotionRepository>();
            services.AddScoped<IFileRepository, FileRepository>();
            services.AddScoped<IRouteRepository, RouteRepository>();
            services.AddScoped<IStationRepository, StationRepository>();
            services.AddScoped<IRouteStationRepository, RouteStationRepository>();
            services.AddScoped<IBannerRepository, BannerRepository>();
            services.AddScoped<IVehicleTypeRepository, VehicleTypeRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IFareRepository, FareRepository>();
            services.AddScoped<IFareTimelineRepository, FareTimelineRepository>();
            services.AddScoped<IRouteRoutineRepository, RouteRoutineRepository>();
            services.AddScoped<IAffiliateAccountRepository, AffiliateAccountRepository>();
            services.AddScoped<IAffiliatePartyRepository, AffiliatePartyRepository>();
            services.AddScoped<IWalletRepository, WalletRepository>();
            services.AddScoped<IWalletTransactionRepository, WalletTransactionRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<IPricingRepository, PricingRepository>();
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
            services.AddTransient<IBookingService, BookingService>();
            services.AddTransient<IBookingDetailService, BookingDetailService>();
            services.AddTransient<IBookingDetailDriverService, BookingDetailDriverService>();
            services.AddTransient<IPromotionService, PromotionService>();
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<IRouteService, RouteService>();
            services.AddTransient<IStationService, StationService>();
            services.AddTransient<IRouteStationService, RouteStationService>();
            services.AddTransient<IRapidApiService, RapidApiService>();
            services.AddTransient<IBannerService, BannerService>();
            services.AddTransient<ILocationService, LocationService>();
            services.AddTransient<IPaymentService, PaymentService>();
            services.AddTransient<IAdminService, AdminService>();
            services.AddTransient<IVehicleTypeService, VehicleTypeService>();
            services.AddTransient<IVehicleService, VehicleService>();
            services.AddTransient<IFareService, FareService>();
            services.AddTransient<IFareTimelineService, FareTimelineService>();
            services.AddTransient<IPaymentService, PaymentService>();
            services.AddTransient<IRouteRoutineService, RouteRoutineService>();
            services.AddTransient<IAffiliateAccountService, AffiliateAccountService>();
            services.AddTransient<IAffiliatePartyService, AffiliatePartyService>();
            services.AddTransient<IWalletService, WalletService>();
            services.AddTransient<IWalletTransactionService, WalletTransactionService>();
            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<IPricingService, PricingService>();
        }
        public static void ConfigureIoCRedisMessageQueue(this IServiceCollection services)
        {
            services.AddSingleton<IRedisMQService, RedisMQService>();
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

        public static void ConfigurationJobQueue(this IServiceCollection services)
        {
            //services.AddHostedService<MessageTasks>();
            services.AddHostedService<MappingBookingTask>();
            //services.AddHostedService<TestTask>();
        }

        public static void ConfigurationSeedData(this IServiceCollection services)
        {
            services.AddHostedService<DumpRoutes>();
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.MapType<DateOnly>(() => new OpenApiSchema { Format = "date", Type = "string" });
                options.MapType<TimeOnly>(() => new OpenApiSchema { Format = "time", Type = "string" });

                //options.SwaggerDoc("v1", new OpenApiInfo { Title = "MaaS API Project", Version = "v1" });
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

            services.ConfigureOptions<ConfigureSwaggerOptions>();
        }

        public static void ConfigureSettings(this IServiceCollection services, WebApplicationBuilder builder)
        {
            // configure strongly typed settings object
            // this project not use because must load config by environment
        }

        public static void ConfigureApiVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                options.ReportApiVersions = true;
                //options.ApiVersionReader = ApiVersionReader.Combine(
                //new QueryStringApiVersionReader("api-version"),
                //new HeaderApiVersionReader("X-Version"),
                //new MediaTypeApiVersionReader("ver")); // use this for input version in swagger UI
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
        }
        public static void ConfigureValidator(this IServiceCollection services)
        {
            services.LoadAllValidators();
        }

        public static void AddHostBackgroundServices(this IServiceCollection services, string[] args)
        {
            services.AddHostedService<QueuedHostedService>();
            services.AddSingleton<IBackgroundTaskQueue, BackgroundTaskQueue>();
        }
    }
}
