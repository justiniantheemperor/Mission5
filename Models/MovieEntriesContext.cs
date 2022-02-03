using Microsoft.EntityFrameworkCore;
using Mission5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission5.Models
{
    public class MovieApplicationContext : DbContext
    {
        // constructor
        public MovieApplicationContext (DbContextOptions<MovieApplicationContext> options) : base (options)
        {
            // Leave Blank for now 
        }
        // Models for Responses and Categories
        public DbSet<ApplicationResponse> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }
        
        // Seed Data
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Action" },
                new Category { CategoryId = 2, CategoryName = "Adventure" },
                new Category { CategoryId = 3, CategoryName = "Animated" },
                new Category { CategoryId = 4, CategoryName = "Comedy" },
                new Category { CategoryId = 5, CategoryName = "Drama" },
                new Category { CategoryId = 6, CategoryName = "Fantasy" },
                new Category { CategoryId = 7, CategoryName = "Historical" },
                new Category { CategoryId = 8, CategoryName = "Sci-Fi" },
                new Category { CategoryId = 9, CategoryName = "Thriller" },
                new Category { CategoryId = 10, CategoryName = "Western" }
            );


            mb.Entity<ApplicationResponse>().HasData(

                new ApplicationResponse
                {
                    Id = 1,
                    CategoryId = 1,
                    Title = "Infinity War",
                    Year = 2018,
                    Director = "Anthony Russo, Joe Russo",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = "My wife love it too"
                },
                new ApplicationResponse
                {
                    Id = 2,
                    CategoryId = 3,
                    Title = "Lego Move, The",
                    Year = 2014,
                    Director = "Phil Lord, Christopher Miller",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },
                new ApplicationResponse
                {
                    Id = 3,
                    CategoryId = 4,
                    Title = "Sleepless in Seattle",
                    Year = 1993,
                    Director = "Nora Ephron",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "",
                    Notes = "My wife's pick"
                }
             );
        }
    }
}
