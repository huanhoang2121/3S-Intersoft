using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using AutoMapper;
using FluentValidation.AspNetCore;
using LoggingCodefirst.DependencyInjection.Implementation;
using LoggingCodefirst.DependencyInjection.Interface;
using LoggingCodefirst.Models.Data;
using LoggingCodefirst.Resources;
using LoggingCodefirst.Validators;
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
            
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IStockService, StockService>();
            
            services.AddSession();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
//            validate
            services.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginValidator>());
            
            services.AddDbContext<DataContext>(item => item.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            
            #region Resources
            
            services.AddSingleton<LocalizationService>();
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            
            services.AddMvc()
                .AddViewLocalization()
                .AddDataAnnotationsLocalization(options =>
                {
                    options.DataAnnotationLocalizerProvider = (type, factory) =>
                    {
                        var assemblyName = new AssemblyName(typeof(PropertyResource).GetTypeInfo().Assembly.FullName);
                        return factory.Create("PropertyResource", assemblyName.Name);
                    };
                });
            
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
                if (!context.Response.HasStarted)
                {
                    switch (context.Response.StatusCode)
                    {
                        case StatusCodes.Status400BadRequest :
                            context.Request.Path ="/Error/400";
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