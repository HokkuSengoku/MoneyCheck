using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MoneyCheck.DataAcess.EntityFramework;
using MoneyCheck.Models;

namespace MoneyCheck.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly DbContext _context;

    public HomeController(ILogger<HomeController> logger, DbContext context)
    {
        _context = context;
        _logger = logger;
    }

   /* public IActionResult CreateUser(User user)
    {
        _context.Add(new User() { Id = 1, UserName = "Hokku", Balance = 0, UserAccounts = new List<Account>() });
        _context.SaveChanges();
        return View();
    } */
    
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}