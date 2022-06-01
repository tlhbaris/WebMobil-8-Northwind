﻿using Microsoft.AspNetCore.Identity;
using WissenShop.Business.MappingProfiles;
using WissenShop.Business.Repositories;
using WissenShop.Business.Repositories.Abstracts;
using WissenShop.Business.Services.Email;
using WissenShop.Core.Entities;
using WissenShop.Data.EntityFramework;
using WissenShop.Data.Identity;

namespace WissenShop.Web.Core.Extensions
{
    public static class ServiceExtesions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            #region Identity

            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
                {
                    // Password settings.
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 6;
                    options.Password.RequiredUniqueChars = 1;

                    // Lockout settings.
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                    options.Lockout.MaxFailedAccessAttempts = 3;
                    options.Lockout.AllowedForNewUsers = false;

                    // User settings.
                    options.User.AllowedUserNameCharacters =
                        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._";
                    options.User.RequireUniqueEmail = true;
                }).AddEntityFrameworkStores<MyContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);

                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            #endregion

            services.AddTransient<IEmailService, SmtpEmailService>();

            services.AddScoped<IRepository<Product, Guid>, ProductRepo>();
            services.AddScoped<IRepository<Category, int>, CategoryRepo>();

            //builder.Services.AddAutoMapper(options => options.AddMaps("AdminTemplate.MappingProfiles"));
            services.AddAutoMapper(options =>
            {
                options.AddProfile<EntityMappingProfile>();
            });

            return services;
        }
    }
}