using Microsoft.AspNetCore.Mvc;
using Mission06_Chu.Models;
using System.Diagnostics;


// HomeController class handles the routing and logic for different pages
namespace Mission06_Chu.Controllers
{
    public class HomeController : Controller
    {
        private MovieCollectionContext _context;
        public HomeController(MovieCollectionContext temp) 
        { 
            _context = temp;
        }

        // Action method for the default Index page
        public IActionResult Index()
        {
            return View();
        }

        // Action method for another Index page
        public IActionResult Index2()
        {
            return View();
        }

        // HTTP GET method for displaying the MovieCollection form
        [HttpGet]
        public IActionResult MovieCollection()
        {
            return View();
        }


        // HTTP POST method for handling form submission and adding a new movie collection record
        [HttpPost]
        public IActionResult MovieCollection(Collection response)
        {
            _context.Collections.Add(response); //Add record to the database
            _context.SaveChanges();
            return View("Confirmation", response);
        }
    }
}
