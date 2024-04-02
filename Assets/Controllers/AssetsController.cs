using Microsoft.AspNetCore.Mvc;

namespace Assets.Controllers;

public class AssetsController : Controller
{
    
    public IActionResult Assets()
    {
        return View();
    }
}