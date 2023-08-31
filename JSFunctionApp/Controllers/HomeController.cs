using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using JSFunctionApp.Models;

namespace JSFunctionApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Calculate(char paramA, char paramB, int paramC, int paramD, int paramE)
    {
        try
        {
            int result = GetExpectedValue(paramA, paramB, paramC, paramD, paramE);
            return Json(new { success = true, result });
        }
        catch (Exception ex)
        {
            return Json(new { success = false, error = ex.Message });
        }
    }

    private int GetExpectedValue(char paramA, char paramB, int paramC, int paramD, int paramE)
    {
        try
        {
            if (paramB == 'A' && paramC == 0 && paramD == 0 && paramE == 0)
            {
                return 1;
            }
            else if ((paramB == 'B') && (paramA == 'A' || paramA == 'B') && paramC == 1 && paramD == 1 && paramE == 0)
            {
                return 1;
            }
            else if ((paramB == 'B') && (paramA == 'A' || paramA == 'B') && paramC == 0 && paramD == 1 && paramE == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        catch
        {
            return 0; // Return 0 for any exceptions
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

