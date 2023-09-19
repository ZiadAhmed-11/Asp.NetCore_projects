using Microsoft.AspNetCore.Mvc;

namespace Assignment_Controller.controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
