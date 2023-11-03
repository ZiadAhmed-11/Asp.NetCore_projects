using Microsoft.AspNetCore.Mvc;

namespace EnvironmentsExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        //constructor
        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [Route("/")]
        [Route("some-route")]
        public IActionResult Index()
        {
            ViewBag.currentEnvironment = _webHostEnvironment.EnvironmentName;
            return View();
        }

        [Route("some-route")]
        public IActionResult Other()
        {
            return View();
        }
    }
}
