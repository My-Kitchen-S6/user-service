using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using user_service.Models;

namespace user_service.Data
{
    public class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app, bool isProd)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProd);
            }

        }
        private static void SeedData(AppDbContext context, bool isProd)
        {
            if (isProd)
            {
                Console.WriteLine("--> Attempting to apply migrations...");
                try
                {
                    context.Database.EnsureCreated();
                    context.Database.Migrate();
                }
                catch(Exception e)
                {
                    Console.WriteLine($"--> Could not run migrations: {e.Message}");
                }
            }

            if (!context.Users.Any())
            {
                Console.WriteLine("--> seeding data");
                context.Users.AddRange(
                    new User() {Auth0Id = "blahblah1", UserName="Tester1"},
                    new User() {Auth0Id = "blahblah2", UserName = "Tester2"},
                    new User() {Auth0Id = "blahblah3", UserName = "Tester3"}
                );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> we already have data");
            }

        }
    }
}