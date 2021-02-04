using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movie_Assignment_3.Models;

namespace Movie_Assignment_3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult enterMovie()
        {
            return View();
        }
        //This view takes the data entered into the form, saves it in TempStorage, and then displays the confirmation page
        [HttpPost]
        public IActionResult enterMovie(Movies movies)
        {
            TempStorage.AddMovies(movies);
            return View("Confirmation", movies);
        }
        //In this view I used Linq to make it so that all the movies are displayed unless the title is listed as 
        //"Independence Day", in which case it will be stored but not displayed, as it shows in the example in the book
        public IActionResult movieList()
        {
            return View(TempStorage.movies.Where(m => m.Title != "Independence Day"));
        }
        public IActionResult myPodcasts()
        {
            return View();
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
