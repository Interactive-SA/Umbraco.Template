using Microsoft.AspNetCore.Mvc;

namespace YourProjectNamespace.Controllers;

public class ErrorController : Controller
{
    [Route("Error")]
    public IActionResult Index()
    {
        return View("Error404");
    }
}