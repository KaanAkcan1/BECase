using BECase.Common.Entities.App;
using BECase.Data.Context;
using BECase.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using BECase.Business.Interfaces;
using BECase.Business.Services;
using BECase.Data.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

namespace BECase.Business
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddAppDbContext(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services
                .AddTransient<IAppUserService, AppUserService>()
                .AddTransient<ICustomerService, CustomerService>()
                .AddTransient<IInvoiceService, InvoiceService>()
                .AddScoped<JwtRefreshTokenService, JwtRefreshTokenService>()
                .AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection AddSecurity(this IServiceCollection services, JwtOptions jwtSettingsConfig)
        {
            jwtSettingsConfig = Configuration.JwtOption;

            services.AddIdentity<AppUser, IdentityRole<Guid>>(o =>
            {
                // Password settings
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 8;

                o.SignIn.RequireConfirmedEmail = false;
                o.SignIn.RequireConfirmedPhoneNumber = false;

                //User settings
                o.User.RequireUniqueEmail = true;
                o.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";

                o.Lockout.AllowedForNewUsers = false;
                o.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                o.Lockout.MaxFailedAccessAttempts = 3;

            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            var key = System.Text.Encoding.UTF8.GetBytes(jwtSettingsConfig.AccessTokenSecret);

            services.AddAuthentication()
                .AddJwtBearer(x =>
                {
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidIssuers = new List<string>() { },
                        ValidAudiences = new List<string>() { },
                    };
                    x.Events = new JwtBearerEvents
                    {
                        //OnAuthenticationFailed = context =>
                        //{
                        //    context.Response.Redirect("/Account/Login");
                        //    return Task.CompletedTask;
                        //},
                        //OnChallenge = context =>
                        //{
                        //    context.HandleResponse();
                        //    context.Response.Redirect("/Account/Login");
                        //    return Task.CompletedTask;
                        //}
                    };
                });


            services.AddAuthorization(options =>
            {
                options.AddPolicy("EmployeeOnly", policy => policy.RequireClaim("EmployeeNumber"));
            });

            return services;
        }

    }
}
