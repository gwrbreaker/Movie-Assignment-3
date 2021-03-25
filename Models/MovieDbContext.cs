using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Assignment_3.Models
{
    public class MovieDbContext : DbContext
    {
        //This is where the database context of type database context is passed to the base
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {

        }
        //Get and set the Database set of type movies
        public DbSet<Movies> Movies { get; set; }
    }
}
