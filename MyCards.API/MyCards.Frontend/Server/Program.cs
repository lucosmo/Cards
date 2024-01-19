using Microsoft.AspNetCore.ResponseCompression;

namespace MyCards.Frontend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();
            //from https://stackoverflow.com/questions/70583469/host-web-api-in-blazor-server-application
            builder.Services.AddControllers();

            var cardControllerUrl = builder.Configuration["ApiClientBaseUrl"] + "Card/";
            var fileControllerUrl = builder.Configuration["ApiClientBaseUrl"] + "File/";

            builder.Services.AddHttpClient("CardClient", x =>
            {
                x.BaseAddress = new Uri(builder.Configuration["ApiClientBaseUrl"]+"Card/");
            });
            builder.Services.AddHttpClient("FileClient", x =>
            {
                x.BaseAddress = new Uri(builder.Configuration["ApiClientBaseUrl"]+"File/");
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();


            app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");
            //app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}