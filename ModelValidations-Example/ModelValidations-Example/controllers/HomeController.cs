using Microsoft.AspNetCore.Mvc;
using ModelValidations_Example.Models;
namespace ModelValidations_Example.controllers
{
    public class HomeController : Controller
    {
        [Route("register")]
        public IActionResult Index(Person person)
        {
            if (!ModelState.IsValid) {
                //List<string> errorsList = new List<string>(); 
                string errors = string.Join("\n",ModelState.Values.SelectMany(value => value.Errors).Select(error => error.ErrorMessage));
                /*foreach(var value in ModelState.Values)  //All values
                {
                    foreach( var error in value.Errors)  //all error in one value
                    {
                        errorsList.Add(error.ErrorMessage);
                    }
                }*/

/*                string errors = string.Join("\n", errorsList);    
*/            return BadRequest(errors);
            }
            return Content($"{person}");
        }
    }
}
