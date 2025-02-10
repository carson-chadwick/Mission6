using Microsoft.AspNetCore.Mvc;
using Mission6.Models;
using System.Diagnostics;

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
            return View();
        }

        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieForm()
        {
            return View(new MovieFormModel());  // Show empty form on GET request
        }

        [HttpPost]
        public IActionResult MovieForm(MovieFormModel response)
        {
            if (ModelState.IsValid) // Check if the form is valid
            {
                _context.Movies.Add(response); // Add movie to the database
                _context.SaveChanges(); // Save changes

                TempData["SuccessMessage"] = "Movie added successfully!"; // Show success message

                return RedirectToAction("MovieForm", response); // Show confirmation page
            }
            else
            {
                return View(response); // Return the form with errors if invalid
            }
        }
    }
}


