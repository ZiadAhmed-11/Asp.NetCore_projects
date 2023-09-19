using Microsoft.AspNetCore.Mvc;

namespace IActionResult_Example.controllers
{
    public class HomeController : Controller
    {
        //the final url we need : http://localhost:5067/book?bookid=10&isloggedin=true

        [Route("/bookstore")]
        public IActionResult Index()
        {
            // book id should be applied
            if (!Request.Query.ContainsKey("bookid"))
            {
                /*                Response.StatusCode = 400;*/
                /*                  return Content("Book id is not supplied");
                *//*              return new BadRequestResult();
                */
                return BadRequest("Book id is not supplied");
            }

            // book id can't be empty
            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            {
                /*Response.StatusCode = 400;
                return Content("Book id can't be null or empty");*/
                return BadRequest("Book id can't be null or empty");
            }

            // book id should be between 1 to 1000
            int bookId = Convert.ToInt16(Request.Query["bookid"]);
            if (bookId <= 0)
            {
                /*Response.StatusCode = 400;
                return Content("Book id Can't be less than or equal zero");*/
                return BadRequest("Book id Can't be less than or equal zero");
            }
            if (bookId > 1000)
            {
                /*                Response.StatusCode = 404;
                                return Content("Book id can't be greater than 1000");*/
                return NotFound("Book id can't be greater than 1000");
            }

            // isloggedin should be true
            if (Convert.ToBoolean(Request.Query["isloggedin"]) == false)
            {
                /*                Response.StatusCode = 401;
                */
                return Unauthorized("User must be authenticated");
            }

            //return new StatusCodeResult(status - code) or return StatusCode(status - code)

            return new RedirectToActionResult("Books", "Store",new { });
        }
    }
}
