using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Chu.Models;
using SQLitePCL;
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
            ViewBag.Categories = _context.Categories.ToList();
            //.OrderBy(x => x.Category)

            return View("MovieCollection", new Collection());
        }


        // HTTP POST method for handling form submission and adding a new movie collection record
        [HttpPost]
        public IActionResult MovieCollection(Collection response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response); //Add record to the database
                _context.SaveChanges();
                return View("Confirmation", response);
            }
            
            else // Invalid data
            {
                foreach (var modelStateKey in ViewData.ModelState.Keys)
                {
                    var value = ViewData.ModelState[modelStateKey];
                    foreach (var error in value.Errors)
                    {
                        Console.WriteLine($"Key: {modelStateKey}, Error: {error.ErrorMessage}");
                        // Log these errors or inspect them
                        // You can use Debug.WriteLine(error.ErrorMessage); for a quick check
                    }
                }

                // Repopulate ViewBag.Categories before returning to the view
                ModelState.Remove("CategoryId");
                ViewBag.Categories = _context.Categories.ToList();
                return View(response);

            }

        }

        public IActionResult MovieList()
        {
            //var movies = _context.Movies.FromSqlRaw("SELECT * FROM Movies");
            var movies = _context.Movies
                .Include(m => m.Category)
                .ToList();
                // .OrderBy(x => x.Title).ToList();

            return View(movies);

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("MovieCollection", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Collection updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int id) 
        { 
            var recordToDelete = _context.Movies
                 .Single(x => x.MovieId == id);

            return View(recordToDelete);

        }

        [HttpPost]
        public IActionResult Delete(Collection deleteinfo)
        {
            _context.Movies.Remove(deleteinfo);
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }


    }


    
}
