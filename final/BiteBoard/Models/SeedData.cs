using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BiteBoard.Data;
using System;
using System.Linq;

namespace BiteBoard.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new BiteBoardContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<BiteBoardContext>>()))
        {
            // Look for any movies.
            if (context.movie.Any())
            {
                return;   // DB has been seeded
            }
            context.movie.AddRange(
                new movie
                {
                    Title = "Beef Bullion Soup",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Water, beef Bullion",
                    rating = "1 Hour",
                    Price = "1.Boil water. \r\n 2. Stir Water \r\n 3. Add Bullion"
                },
                new movie
                {
                    Title = "Chicken Bullion Soup",
                    ReleaseDate = DateTime.Parse("1999-2-12"),
                    Genre = "Water, Chicken Bullion",
                    rating = "2 Hour",
                     Price = "1.Boil water. \r\n 2. Stir Water \r\n 3. Add Bullion"
                },
                       new movie
                {
                    Title = "Robot Bullion Soup",
                    ReleaseDate = DateTime.Parse("2089-2-12"),
                    Genre = "Water, Robot Bullion",
                    rating = "10 Hour",
                     Price = "1.Boil water. \r\n 2. Stir Water \r\n 3. Add Bullion"
                },
                       new movie
                {
                    Title = "Fish Bullion Soup",
                    ReleaseDate = DateTime.Parse("1389-2-12"),
                    Genre = "Water, Fish Bullion",
                    rating = "100 Hour",
                     Price = "1.Boil water. \r\n 2. Stir Water \r\n 3. Add Bullion"
                },
                       new movie
                {
                    Title = "Cat Bullion Soup",
                    ReleaseDate = DateTime.Parse("9-2-12"),
                    Genre = "Water, cat Bullion",
                    rating = ".5 Hour",
                     Price = "1.Boil water. \r\n 2. Stir Water \r\n 3. Add Bullion"
                }



            );
            context.SaveChanges();
        }
    }
}