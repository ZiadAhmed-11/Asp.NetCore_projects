using Microsoft.AspNetCore.Mvc;

namespace RevisionAfterMedTerm_xunit.Controllers
{
    public class PersonsController : Controller
    {
        [Route("persons/index")]
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
