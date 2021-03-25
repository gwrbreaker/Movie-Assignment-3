using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Assignment_3.Models
{
    public interface IMovieRepository
    {
        //Creates an Iqueryable of type movies for the repository
        IQueryable<Movies> Movies { get; }
    }
}
