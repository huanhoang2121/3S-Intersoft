using System;
using System.Collections.Generic;
using System.Globalization;
using AutoMapper;
using FluentValidation.AspNetCore;
using LoggingCodefirst.Models.Data;
using LoggingCodefirst.Resources;
using LoggingCodefirst.Services;
using LoggingCodefirst.Validators.User;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace LoggingCodefirst
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            
            services.AddAutoMapper();
            services.AddSession();
            
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IStockService, StockService>();
            
            services.AddHttpContextAccessor();
            
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.AccessDeniedPath = new PathString("/Error/401");
                    options.LoginPath = new PathString("/Account/Login");
                    options.ReturnUrlParameter = "RequestPath";
                    options.SlidingExpiration = true;
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                });
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
//            validate
            services.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginValidator>());
            
            services.AddDbContext<DataContext>(item => item.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            
            #region Resources
            
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.AddSingleton<LocalizationService<CommonResource>>();
            services.AddSingleton<LocalizationService<HomeResource>>();
            services.AddSingleton<LocalizationService<ErrorResource>>();
            services.AddSingleton<LocalizationService<UserResource>>();
            services.AddSingleton<LocalizationService<BrandResource>>();
            services.AddSingleton<LocalizationService<CategoryResource>>();
            services.AddSingleton<LocalizationService<ProductResource>>();
            services.AddSingleton<LocalizationService<StockResource>>();
            services.AddSingleton<LocalizationService<StoreResource>>();
 
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new List<CultureInfo>
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("vi-VN")
                };
                options.DefaultRequestCulture = new RequestCulture("en-US");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            }); 
            
            #endregion
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.Use(async (context, next) =>
            {
                await next();
                if (!context.Response.HasStarted && context.Response.StatusCode != StatusCodes.Status200OK)
                {
                    switch (context.Response.StatusCode)
                    {
                        case StatusCodes.Status400BadRequest:
                            context.Request.Path ="/Error/400";
                            await next();
                            break;
                        case StatusCodes.Status401Unauthorized:
                            context.Request.Path ="/Error/401";
                            await next();
                            break;
                        case StatusCodes.Status403Forbidden :
                            context.Request.Path ="/Error/403";
                            await next();
                            break;
                        case StatusCodes.Status404NotFound :
                            context.Request.Path ="/Error/404";
                            await next();
                            break;
                        case StatusCodes.Status405MethodNotAllowed :
                            context.Request.Path ="/Error/405";
                            await next();
                            break;
                        case StatusCodes.Status500InternalServerError:
                            context.Request.Path ="/Error/500";
                            await next();
                            break;
                    }
                }
            });
            
            app.UseRequestLocalization();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();
            
            app.UseAuthentication();
           
            #region Resources
            
            var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);
            
            #endregion


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}