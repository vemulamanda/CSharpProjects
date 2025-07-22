namespace AspNetCoreMvcFirstProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            if(!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");

                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            //app.UseRouting();

            app.UseAuthorization();
                         
            //This below code works for both conventional and attribute routing also.
            //you can use Below code used for both conventional routing and attribute routing.

            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}");

            //use Below code if you want to completely go for attribute routing:
            app.MapControllers();

            app.Run();
        }
    }
}
