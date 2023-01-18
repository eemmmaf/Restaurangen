using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Restaurangen.Data;
using Restaurangen.Models;


namespace Restaurangen
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<RestaurangenContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("RestaurangenContext") ?? throw new InvalidOperationException("Connection string 'RestaurangenContext' not found.")));

            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();


            //Använder seeding
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                SeedData.Initialize(services);
            }

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