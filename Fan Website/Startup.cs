using Fan_Website.Infrastructure;
using Fan_Website.Models;
using Fan_Website.Service;
using Fan_Website.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Fan_Website
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
            services.AddRouting(options => {
                options.LowercaseUrls = true;
                options.AppendTrailingSlash = true;
            });
           services.AddIdentity<ApplicationUser, IdentityRole>()
               .AddEntityFrameworkStores<AppDbContext>();

            services.AddDbContext<AppDbContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("Fansite")));

            services.AddIdentityCore<ApplicationUser>().AddRoles<IdentityRole>().AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IForum, ForumService>(); ;
            services.AddScoped<IPost, PostService>();
            services.AddScoped<IApplicationUser, ApplicationUserService>();
            services.AddScoped<IUpload, UploadService>();
            services.AddScoped<IScreenshot, ScreenshotService>(); 
            services.AddSingleton(Configuration); 
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication(); 
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}/{slug?}");
            });
        }
    }
}
