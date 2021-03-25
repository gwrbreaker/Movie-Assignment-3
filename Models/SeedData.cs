using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Assignment_3.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            MovieDbContext context = application.ApplicationServices.
                CreateScope().ServiceProvider.GetRequiredService<MovieDbContext>();
            //If there are any migrations that were not done yet this will execute them
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Movies.Any())
            {
                context.Movies.AddRange(
                    //This is the seed data for I Am Legend for the database
                    new Movies
                    {

                        Category = "Action",
                        Title = "I Am Legend",
                        Year = "2003",
                        Director = "Francis Lawrence",
                        Rating = Rating.PG13,
                        Edited = false,
                        Lent = "Sam",
                        Notes = "Best Movie Ever"
                    }
                    
                         


                    );

                context.SaveChanges();
            }
        }
    }
}
