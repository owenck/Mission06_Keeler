using Microsoft.AspNetCore.Mvc;
using Mission06_Keeler.Models;

namespace Mission06_Keeler.Controllers;

public class HomeController : Controller
{
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
        return View("Confirmation", movie);
    }
}