using System.Collections.Generic;
using System.Globalization;
using AutoMapper;
using FluentValidation.AspNetCore;
using LoggingCodefirst.Authentication;
using LoggingCodefirst.Interface;
using LoggingCodefirst.Models.Data;
using LoggingCodefirst.Resources;
using LoggingCodefirst.Services;
using LoggingCodefirst.Validators.User;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // Add CookieAuthentication
            #region Add CookieAuthentication

            services.AddAuthentication(UserCookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(UserCookieAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.AccessDeniedPath =       UserCookieAuthenticationDefaults.AccessDeniedPath;
                    options.ReturnUrlParameter =     UserCookieAuthenticationDefaults.ReturnUrlParameter;
                    options.LoginPath =              UserCookieAuthenticationDefaults.LoginPath;
                    options.LogoutPath =             UserCookieAuthenticationDefaults.LogoutPath;
                    options.ExpireTimeSpan =         UserCookieAuthenticationDefaults.ExpireTimeSpan;
                });
            
            #endregion
 
            // Add Localization
            #region AddLocalization
            
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            
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

            services.AddSingleton<LocalizationService<CommonResource>>();
            services.AddSingleton<LocalizationService<HomeResource>>();
            services.AddSingleton<LocalizationService<ErrorResource>>();
            services.AddSingleton<LocalizationService<UserResource>>();
            services.AddSingleton<LocalizationService<BrandResource>>();
            services.AddSingleton<LocalizationService<CategoryResource>>();
            services.AddSingleton<LocalizationService<ProductResource>>();
            services.AddSingleton<LocalizationService<StockResource>>();
            services.AddSingleton<LocalizationService<StoreResource>>();
  
            
            #endregion

            // Add application services.    
            #region Add Service
            
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IStockService, StockService>();   
            services.AddScoped<IRoleService, RoleService>();     
            
            services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();   
            
            #endregion
            
            services.AddDbContext<DataContext>(item => item.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));   

            services.AddAutoMapper();
            services.AddHttpContextAccessor();
            
            // Add FluentValidation
            services.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginValidator>());

            // If the app uses session state, call AddSession.
            services.AddMvc().AddSessionStateTempDataProvider();
            services.AddSession();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
                        default:
                            await next();
                            break;
                    }
                }
            });
            
            app.UseRequestLocalization();

            // Use HTTPS Redirection Middleware to redirect HTTP requests to HTTPS.
            app.UseHttpsRedirection();

            // Return static files and end the pipeline.
            app.UseStaticFiles();
           
            // Use Cookie Policy Middleware to conform to EU General Data 
            // Protection Regulation (GDPR) regulations.
            app.UseCookiePolicy();

            // Authenticate before the user accesses secure resources.
            app.UseAuthentication();

            // If the app uses session state, call Session Middleware after
            // Cookie Policy Middleware and before MVC Middleware.
            app.UseSession();
            
            app.UseMvcWithDefaultRoute();
            
            // Add MVC to the request pipeline.
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}