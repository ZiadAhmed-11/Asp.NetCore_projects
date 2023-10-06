using Microsoft.AspNetCore.Mvc;

namespace ViewsExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("Home")]
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
