using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Movie_Assignment_3.Models;

namespace Movie_Assignment_3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private MovieDbContext _context;
        private IMovieRepository _repository;
        

        public HomeController(ILogger<HomeController> logger, MovieDbContext context, IMovieRepository repository)
        {
            _logger = logger;
            _context = context;
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult myPodcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult enterMovie()
        {
            return View();
        }
        //returns the current movies in the database (there is only 1 by default)
        public IActionResult movieList()
        {
            IEnumerable<Movies> movies;

            movies = _context.Movies.OrderBy(m => m.Title);

            return View("movieList", movies);
        }

        //This view takes the data entered into the form, saves it to the database, and then displays the confirmation page
        [HttpPost]
        public IActionResult enterMovie(Movies movies)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movies);
                _context.SaveChanges();
            }

            return View("Confirmation", movies);
        }

       
        //Returns a form with all the info from the current database in it
        [HttpPost]
        public IActionResult EditForm(int MovieID)
        {
            IEnumerable<Movies> movies;
            movies = _repository.Movies.Where(m => m.MovieID == MovieID);

            return View("EditForm", movies.First());
        }

        //Updates the movie
        [HttpPost]
        public IActionResult MovieUpdate(Movies movies)
        {
            IEnumerable<Movies> Movies;

            _context.Movies.Update(movies);
            _context.SaveChanges();

            

            Movies = _context.Movies.OrderBy(m => m.Title);

            return View("movieList", Movies);
        }

        //Deletes the movie
        [HttpPost]
        public IActionResult DeleteMovie(int MovieID)
        {
            IEnumerable<Movies> movie;

            movie = _repository.Movies.Where(m => m.MovieID == MovieID);

            _context.Remove(movie.First());
            _context.SaveChanges();

            IEnumerable<Movies> movies;

            movies = _context.Movies.OrderBy(m => m.Title);

            return View("movieList", movies);
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
