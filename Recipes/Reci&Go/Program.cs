using Reci_Go.Services;
using Reci_Go.Repositories;
using Reci_Go.Services.Interface;
using Reci_Go.Models;
using Reci_Go.Services.Implementations;

namespace Reci_Go
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddScoped(typeof(IServiceGeneric<Users>), typeof(UsersService));
            //builder.Services.AddScoped(typeof(IServiceGeneric<Categories>), typeof(CategoriesService));
            //builder.Services.AddScoped(typeof(IServiceGeneric<Categories>), typeof(CategoriesService<Category>));


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

            app.MapRazorPages();

            app.Run();
        }
    }
}