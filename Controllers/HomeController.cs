using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CronogramaSenac.Models;

namespace CronogramaSenac.Controllers;

[Route("[controller]")]
public class HomeController : Controller
{
    /*atualizando"*/
    private readonly ILogger<HomeController> _logger;
    //blaaaaaa
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }


    [Route("privacy")]
    public IActionResult Privacy()
    {
        return View();
    }
}
