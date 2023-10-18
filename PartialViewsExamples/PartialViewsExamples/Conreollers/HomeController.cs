using Microsoft.AspNetCore.Mvc;

namespace PartialViewsExamples.Conreollers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("about")]
        public IActionResult About()
        {
            return View();
        }
    }
}
