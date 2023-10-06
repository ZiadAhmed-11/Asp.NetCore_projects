using Microsoft.AspNetCore.Mvc;
using ModelBinding_Revision2.Models;

namespace ModelBinding_Revision2.Controllers
{
    public class HomeController : Controller
    {
        [Route("register")]
        public IActionResult Index(Person person)
        {
            if(!ModelState.IsValid)
            {
                List<string> errorList=new List<string>();
                foreach(var value in ModelState.Values)
                {
                    foreach(var error in value.Errors)
                    {
                        errorList.Add(error.ErrorMessage);
                    }
                }
                string Errors = string.Join("\n", errorList);
                return BadRequest(Errors);
            }
            return Content($"{person}");
        }
    }
}
