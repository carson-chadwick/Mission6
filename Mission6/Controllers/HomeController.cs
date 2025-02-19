using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Chadwick.Models;
using Mission6.Models;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace Mission6.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext _context; // Database context

        public HomeController(MovieContext temp)  // Injecting the context
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            //Linq
            var movies = _context.Movies
                .Include(x => x.Category)
                .OrderBy(x => x.Title).ToList();
            return View(movies);
           
        }

        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieForm()
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName).ToList();
            return View(new MovieFormModel());  // Show empty form on GET request
        }

        [HttpPost]
        public IActionResult MovieForm(MovieFormModel response)
        {
            if (ModelState.IsValid) // Check if the form is valid
            {
                _context.Movies.Add(response); // Add movie to the database
                _context.SaveChanges(); // Save changes

                return View("Confirmation", response); // Show confirmation page
            }
            else
            {
                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryId).ToList();

                return View(response);
            }

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName).ToList();

            return View("MovieForm", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(MovieFormModel updatedInfo)
        {
            git_context.Update(updatedInfo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(MovieFormModel movieFormInput)
        {
            _context.Movies.Remove(movieFormInput);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}


