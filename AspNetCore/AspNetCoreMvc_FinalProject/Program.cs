using AspNetCoreMvc_FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreMvc_FinalProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

            //Dependency injection code to use sql server connection string from appsettings.json file.
            builder.Services.AddDbContext<MvcCoreDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConStr")));
            
            //Dependency injection to use XML
            //builder.Services.AddScoped<ICustomer, CustomerXmlDAL>();
            builder.Services.AddScoped<ICustomer, CustomerSqlDAL>();

            //Registering identity service
            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = false;

            }).AddEntityFrameworkStores<MvcCoreDBContext>().AddDefaultTokenProviders();


            //Registering facebook and google authentications.
            builder.Services.AddAuthentication()
                .AddGoogle(options =>
            {
                options.ClientId = "161325890892-ihki95e2j2ult4hc7mtvf3i9nbe0mqog.apps.googleusercontent.com";
                options.ClientSecret = "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";
            })
                .AddFacebook(options =>
                {
                    options.AppId = "3142659679240829";
                    options.AppSecret = "e76337872d1cc895683c03819a7596ef";
                });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                //Client Error handler Middlewares,, total 3
                //1. Below code will show static error message with status code
                //app.UseStatusCodePages();
                //2. Below code will redirect to error page we creted and will show status code and also error view page
                //app.UseStatusCodePagesWithRedirects("/ClientError/{0}"); //This will execute with 2 requests
                //3. This will execute with with only 1 request.
                app.UseStatusCodePagesWithReExecute("/ClientError/{0}");

                //Server Error handler Middlewares,, total 1 only
                app.UseExceptionHandler("/ServerError");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
