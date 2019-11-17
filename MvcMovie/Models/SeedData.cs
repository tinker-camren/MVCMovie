using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MvcMovie.Models
{
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
                        Title = "Meet The Mormons",
                        ReleaseDate = DateTime.Parse("2014-10-10"),
                        Genre = "Religion",
                        Price = 7.99M,
                        Rating = "G",
                        ImagePath = "Resources\\MeetTheMormons.jpg"
                    },

                    new Movie
                    {
                        Title = "The RM",
                        ReleaseDate = DateTime.Parse("2003-1-31"),
                        Genre = "Religion",
                        Price = 8.99M,
                        Rating = "G",
                        ImagePath = "Resources\\TheRM.jpg"
                    },

                    new Movie
                    {
                        Title = "The Singles Ward",
                        ReleaseDate = DateTime.Parse("2002-2-1"),
                        Genre = "Religion",
                        Price = 9.99M,
                        Rating = "G",
                        ImagePath = "Resources\\TheSinglesWard.jpg"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}