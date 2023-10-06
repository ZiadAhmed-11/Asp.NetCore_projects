using E_Commerce_ModelBinding.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_ModelBinding.Controllers
{

    public class HomeController : Controller
    {
        [Route("/order")]
        public IActionResult Index(Order order)
        {

            if (!ModelState.IsValid)
            {
                List<string> ErrorsMessage = new List<string>();
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        ErrorsMessage.Add(error.ErrorMessage);
                    }
                }
                string LastMessages = string.Join("\n", ErrorsMessage);
                return BadRequest(LastMessages);
            }
            Random random = new Random();
            int randomOrderNumber = random.Next(1, 99999);

            return Json(new { orderNumber = randomOrderNumber });
        }
    }
}
