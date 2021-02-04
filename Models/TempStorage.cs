using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Assignment_3.Models
{
    public static class TempStorage
    {
        private static List<Movies> GetMovies = new List<Movies>();

        public static IEnumerable<Movies> movies => GetMovies;

        public static void AddMovies(Movies movies)
        {
            GetMovies.Add(movies);
        }
    }
}
