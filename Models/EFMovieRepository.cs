using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Assignment_3.Models
{
    public class EFMovieRepository : IMovieRepository
    {
        private MovieDbContext _context;

        //Constructor
        public EFMovieRepository(MovieDbContext context)
        {
            _context = context;
        }
        public IQueryable<Movies> Movies => _context.Movies;
    }
}
