using Microsoft.AspNetCore.Mvc;

namespace Assignment_Controller.controllers
{
    public class HomeController : Controller
    {
        public object Account1()
        {
            BankAccount a1 = new BankAccount() { accountNumber = 1001, accountHolderName = "Example Name", currentBalance = 5000 };
            return a1;
        }

        [Route("/")]
        public IActionResult Index()
        {
            Response.StatusCode = 200;
            return Content("Welcome to the Best Bank");

        }

        [Route("/account-details")]
        public IActionResult AccountDetails()
        {
            Response.StatusCode = 200;
            
            return Json(Account1());
        }

        [Route("/account-statement")]
        public IActionResult AccountStatus() 
        {
            Response.StatusCode = 200;
            return File("git.pdf", "application/pdf");
        }

        [Route("/get-current-balance/{accountNumber:int?}")]
        public IActionResult GetBalance()
        {
            object accountNumberObj;
            if (HttpContext.Request.RouteValues.TryGetValue("accountNumber", out accountNumberObj) && accountNumberObj is string accountNumber)
            {
                if (string.IsNullOrEmpty(accountNumber))
                {
                    return NotFound("Account Number should be supplied");
                }
                if (int.TryParse(accountNumber, out int accountNumberInt))
                {
                    // Hard-coded data
                    var bankAccount = new { accountNumber = 1001, accountHolderName = "Example Name", currentBalance = 5000 };

                    if (accountNumberInt == 1001)
                    {
                        // If accountNumber is 1001, return the current balance value
                        return Content(bankAccount.currentBalance.ToString());
                    }
                    else
                    {
                        // If accountNumber is not 1001, return HTTP 400
                        return BadRequest("Account Number should be 1001");
                    }
                }
                else
                {
                    // If the 'accountNumber' provided in the route parameter is not a valid integer, return HTTP 400
                    return BadRequest("Invalid Account Number format");
                }
            }
            else
            {
                // If 'accountNumber' is not found in the route parameters, handle the error
                // For example, redirect to an error page or return a specific error message
                // return RedirectToAction("Error");
                return NotFound("Account Number should be supplied");
            }
        
        }

    }
}
