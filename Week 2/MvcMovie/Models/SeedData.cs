using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }
            context.Movie.AddRange(
                new Movie
                {
                    Title = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Romantic Comedy",
                    Rating = "R",
                    Price = 7.99M
                },
                new Movie
                {
                    Title = "Ghostbusters ",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Comedy",
                    Rating = "PG",
                    Price = 8.99M
                },
                new Movie
                {
                    Title = "Ghostbusters 2",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genre = "Comedy",
                    Rating = "PG",
                    Price = 9.99M
                },
                new Movie
                {
                    Title = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Western",
                    Rating = "Un-Rated",
                    Price = 3.99M
                },
                        new Movie
                {
                    Title = "Another Man's Poison",
                    ReleaseDate = DateTime.Parse("1951-11-20"),
                    Genre = "Thriller",
                    Rating = "Un-Rated",
                    Price = 4.99M
                },
                        new Movie
                {
                    Title = "Troll 2",
                    ReleaseDate = DateTime.Parse("1990-10-12"),
                    Genre = "Horror",
                    Rating = "Pg-13",
                    Price = 1.99M
                },
                        new Movie
                {
                    Title = "The Adventures of Sharkboy & Lavagirl",
                    ReleaseDate = DateTime.Parse("2005-6-4"),
                    Genre = "Hero",
                    Rating = "PG",
                    Price = 79.99M
                }



            );
            context.SaveChanges();
        }
    }
}