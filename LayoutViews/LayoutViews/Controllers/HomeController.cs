using Microsoft.AspNetCore.Mvc;

namespace LayoutViews.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
