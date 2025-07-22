
using AspNetCoreMvc_FinalProject.Models;
using AspNetCoreWebApiExample.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebApiExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //This below works for webapi and mvc views also. but we need to do attribute routing, change below at last.
            builder.Services.AddControllersWithViews();
            

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<MvcCoreDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConStr")));
            builder.Services.AddScoped<ICustomerDAL, CustomerSqlDAL>();
            //builder.Services.AddScoped(typeof(ICustomerDAL), typeof(CustomerXmlDAL));
            //Add cors service to allow api outside
            builder.Services.AddCors();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(options =>
            {
                //if you want to allow specic origins, methods, headers.
                //options.WithOrigins("https://nareshit.com", "https://google.com");
                //options.WithMethods("specify methods here");
                //options.WithHeaders("specify headers here");

                //To allow all write below code:
                options.AllowAnyOrigin();
                options.AllowAnyMethod();
                options.AllowAnyHeader();
            });
            app.UseHttpsRedirection();

            app.UseAuthorization();


            //app.MapControllers();  ->attribute routing: for this you have to mentione route on controllere action methods.

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
