using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Models
{
    public class MovieApplicationContext : DbContext
    {
        // constructor
        public MovieApplicationContext (DbContextOptions<MovieApplicationContext> options) : base (options)
        {
            // Leave Blank for now 
        }
        public DbSet<ApplicationResponse> Responses { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<ApplicationResponse>().HasData(
                new ApplicationResponse
                {
                    id = 1,
                    Category = "Action/Adventure",
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
                    id = 2,
                    Category = "Action/Adventure",
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
                    id = 3,
                    Category = "Rom-Com",
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
