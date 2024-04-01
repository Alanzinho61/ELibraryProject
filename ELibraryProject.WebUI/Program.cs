using ELibraryProject.Core.Service;
using ELibraryProject.Model.Context;
using ELibraryProject.Service.DbService;
using Microsoft.EntityFrameworkCore;

namespace ELibraryProject.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddMvc();

            builder.Services.AddDbContext<ELibraryContext>(options => options.UseSqlServer
            ("Server=DESKTOP-CF4C8LU\\SQLEXPRESS;Database=ELibrary;Integrated Security=True;Connect" +
            " Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi" +
            " Subnet Failover=False"));

            //Dependency Injection tanimimiz sayesinde cagirilan araci interface e gore  hedef servisin kurallari uygulanir.
            builder.Services.AddScoped(typeof(IDbService<>), typeof(CoreDbService<>));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //Admin areasi icin route yapisini olusturduk. 
            app.MapAreaControllerRoute(
                name: "Admin",
                areaName: "Admin",
                pattern: "Admin/{Controller=Home}/{Action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{Controller=Home}/{Action=Index}/{id?}");

            app.Run();
        }
    }
}
