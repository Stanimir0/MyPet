using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyPet.Models;

namespace MyPet.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

   
    public IActionResult Index()
    {
        var dog = _context.Dogs.FirstOrDefault();
        return View(dog);
    }


    public IActionResult Privacy()
    {
        return View();
    }

    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
