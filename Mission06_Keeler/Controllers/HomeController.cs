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
        return View();
    }
    [HttpPost]
    public IActionResult AddMovie(Movie movie)
    {
        _context.Movies.Add(movie); // Persist the posted movie to the database
        _context.SaveChanges();
        
        return View("Confirmation", movie); // Show the submitted movie back to the user
    }
}
