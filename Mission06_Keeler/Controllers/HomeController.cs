using Microsoft.AspNetCore.Mvc;
using Mission06_Keeler.Models;

namespace Mission06_Keeler.Controllers;

public class HomeController : Controller
{
    private MovieCollectionContext _context;
    public HomeController(MovieCollectionContext context) // DI-provided EF Core context
    {
        _context = context;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult About()
    {
        return View();
    }
    [HttpGet]
    public IActionResult AddMovie()
    {
        ViewBag.Categories = _context.Categories.ToList();
        return View(new Movie());
    }
    [HttpPost]
    public IActionResult AddMovie(Movie movie)
    {
        if (ModelState.IsValid)
        {
             _context.Movies.Add(movie); // Persist the posted movie to the database
             _context.SaveChanges();
                    
             return View("Confirmation", movie); // Show the submitted movie back to the user
        }
        else
        {
            ViewBag.Categories = _context.Categories.ToList();
            
            return View(movie);
        }
    }

    public IActionResult ViewMovies()
    {
        var movies = _context.Movies.ToList();
        return View(movies);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var recordToEdit = _context.Movies.Single(m => m.MovieId == id);
        ViewBag.Categories = _context.Categories.ToList();
        return View("AddMovie", recordToEdit);
    }

    [HttpPost]
    public IActionResult Edit(Movie recordToEdit)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Update(recordToEdit);
            _context.SaveChanges();
            
            return RedirectToAction("ViewMovies");
        }
        else
        {
            ViewBag.Categories = _context.Categories.ToList();
            
            return View("AddMovie", recordToEdit);
        }
        
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var recordToDelete = _context.Movies.Single(m => m.MovieId == id);
        return View("DeleteMovie", recordToDelete);
    }

    [HttpPost]
    public IActionResult Delete(Movie recordToDelete)
    {
        _context.Movies.Remove(recordToDelete);
        _context.SaveChanges();
        return RedirectToAction("ViewMovies");
    }
}
