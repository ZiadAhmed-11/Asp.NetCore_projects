using Microsoft.AspNetCore.Mvc;

namespace IActionResult_Example.controllers
{
    public class HomeController : Controller
    {
        //the final url we need : http://localhost:5067/book?bookid=10&isloggedin=true

        [Route("book")]
        public IActionResult Index([FromQuery] int? bookid, [FromQuery] bool? isloggedin)
        {
            // book id should be applied
            if (bookid.HasValue == false)
            {
                /*                Response.StatusCode = 400;*/
                /*                  return Content("Book id is not supplied");
                *//*              return new BadRequestResult();
                */
                return BadRequest("Book id is not supplied");
            }

            // book id can't be empty
            if (string.IsNullOrEmpty(Convert.ToString(bookid)))
            {
                /*Response.StatusCode = 400;
                return Content("Book id can't be null or empty");*/
                return BadRequest("Book id can't be null or empty");
            }

            // book id should be between 1 to 1000

            if (bookid <= 0)
            {
                /*Response.StatusCode = 400;
                return Content("Book id Can't be less than or equal zero");*/
                return BadRequest("Book id Can't be less than or equal zero");
            }
            if (bookid > 1000)
            {
                /*                Response.StatusCode = 404;
                                return Content("Book id can't be greater than 1000");*/
                return NotFound("Book id can't be greater than 1000");
            }

            // isloggedin should be true
            if (isloggedin == false)
            {
                /*                Response.StatusCode = 401;
                */
                return Unauthorized("User must be authenticated");
            }

            //return new StatusCodeResult(status - code) or return StatusCode(status - code)

            return Content($"Book id : {bookid}", "text/plain");
        }
    }
}
