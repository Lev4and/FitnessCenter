using FitnessCenter.AspNetCore.Services;
using FitnessCenter.Model.Database;
using FitnessCenter.Model.Database.Repository.Abstract;
using FitnessCenter.Model.Database.Repository.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FitnessCenter.AspNetCore
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            Configuration.Bind("DbConfig", new DbConfig());
            
            services.AddTransient<IBlogRepository, EFBlogRepository>();
            services.AddTransient<IClientsRepository, EFClientsRepository>();
            services.AddTransient<IGendersRepository, EFGendersRepository>();
            services.AddTransient<IServicesRepository, EFServicesRepository>();
            services.AddTransient<ITrainersRepository, EFTrainersRepository>();
            services.AddTransient<ITestimonialsRepository, EFTestimonialsRepository>();
            services.AddTransient<IBlogCommentsRepository, EFBlogCommentsRepository>();
            services.AddTransient<IClientServicesRepository, EFClientServicesRepository>();
            services.AddTransient<IServiceCategoriesRepository, EFServiceCategoriesRepository>();
            services.AddTransient<ITrainerCategoriesRepository, EFTrainerCategoriesRepository>();
            services.AddTransient<IBlogCommentAnswersRepository, EFBlogCommentAnswersRepository>();
            services.AddTransient<DataManager>();
            services.AddTransient<UploadFileService>();
            services.AddDbContext<FitnessCenterDbContext>((options) =>
            {
                options.UseSqlServer(DbConfig.ConnectionString);
            });

            //services.AddIdentity<IdentityUser, IdentityRole>(options =>
            //{
            //    options.Password.RequireDigit = true;
            //    options.Password.RequiredLength = 5;
            //    options.Password.RequireUppercase = true;
            //    options.Lockout.MaxFailedAccessAttempts = 5;
            //    options.User.RequireUniqueEmail = true;
            //    options.SignIn.RequireConfirmedEmail = false;
            //}).AddEntityFrameworkStores<FitnessCenterDbContext>().AddDefaultTokenProviders();

            //services.ConfigureApplicationCookie(options =>
            //{
            //    options.Cookie.Name = "fitnessCenterAuth";
            //    options.Cookie.HttpOnly = true;
            //    options.LoginPath = "/account/login";
            //    options.AccessDeniedPath = "/account/accessdenied";
            //    options.SlidingExpiration = true;
            //});

            //services.AddAuthorization(x =>
            //{
            //    x.AddPolicy("AdminArea", policy => { policy.RequireRole("Администратор"); });
            //});

            services.AddControllersWithViews(x =>
            {
                //x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            //app.UseCookiePolicy();

            //app.UseAuthentication();
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute(
                    name: "AdminArea",
                    areaName: "Admin",
                    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
