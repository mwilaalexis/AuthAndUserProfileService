using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UserProject.DataAccess.Data;
using UserProfileServiceProject.Mappings;
using UserProfileServiceProject.Repositories.Implementations;
using UserProject.DataAccess.Repositories.Interfaces;
using UserProject.Core.Security;
using UserProject.Core.Services.Implementations;
using UserProject.Core.Services.Interfaces;
using UserProject.DataAccess.Repositories.Implementations;

namespace UserProfileServiceProject.Extensions
{
    public static class ApplicationDependency
    {
        public static void AddConfigurationAndServices(this WebApplicationBuilder builder)
        {

            var connection = builder.Configuration.GetConnectionString("DefaultConnection").ToString();
            builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connection));
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
            builder.Services.AddScoped<IJwtService, JwtService>();
            builder.Services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

            builder.Services.AddScoped<IAuthService, AuthService>();

            builder.Services.AddSingleton<IMapper>(sp =>
            {
                var loggerFactory = sp.GetRequiredService<ILoggerFactory>();

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddMaps(typeof(MappingProfile).Assembly);
                }, loggerFactory);

                return config.CreateMapper();
            });




            builder.Services.AddScoped<IProfileService, ProfileService>();

            builder.ConfigureAuthentication();
            builder.ConfigureAuthorizationPolicy();
        }

        public static void ConfigureAuthorizationPolicy(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthorization(options =>
            {

                options.AddPolicy("BasicUserAccess", policy =>
                    policy.RequireRole("User", "Moderator", "Admin"));


                options.AddPolicy("ContentManager", policy =>
                    policy.RequireRole("Moderator", "Admin"));


                options.AddPolicy("AdminOnly", policy =>
                    policy.RequireRole("Admin"));
            });
        }
        public static void ConfigureAuthentication(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],

                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),

                       
                        ClockSkew = TimeSpan.FromMinutes(2),           
                    };

                   
                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            Console.WriteLine("=== JWT AUTH FAILED ===");
                            Console.WriteLine("Exception: " + context.Exception.Message);
                            if (context.Exception is SecurityTokenExpiredException expEx)
                            {
                                Console.WriteLine($"Token expired at: {expEx.Expires}");
                                Console.WriteLine($"Current server time: {DateTime.UtcNow}");
                            }
                            return Task.CompletedTask;
                        }
                    };
                });
        }

    }
}
