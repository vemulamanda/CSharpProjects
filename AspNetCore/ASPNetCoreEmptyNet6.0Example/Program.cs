namespace ASPNetCoreEmptyNet6._0Example
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapGet("/", () => "Until .Net5.0, there is startup.cs file and from 6.0 there no startup file.");

            app.Run();
        }
    }
}
