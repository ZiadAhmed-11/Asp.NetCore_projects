using Microsoft.AspNetCore.Mvc;

namespace RedirectResult_Examples.controller
{
    public class StoreController : Controller
    {
        [Route("Store/books")]
        public IActionResult Books()
        {
            return Content("<h1> Book Store </h1>");
        }
    }
}
