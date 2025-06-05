using Microsoft.AspNetCore.Mvc;

public class DogController : Controller
{
    private readonly ApplicationDbContext _context;

    public DogController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var dog = _context.Dogs.FirstOrDefault();
        return View(dog);
    }

    public IActionResult Gallery()
    {
        var dog = _context.Dogs.FirstOrDefault();
        return View(dog);
    }
}
