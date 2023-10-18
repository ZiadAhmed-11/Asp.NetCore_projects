using Microsoft.AspNetCore.Mvc;

namespace LayoutViews.Controllers
{
    public class ProductsController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
