using Microsoft.AspNetCore.Mvc;

namespace ControllersExamples.Controllers
{
    public class HomeController 
    {
        [Route("home")]
        [Route("/")]

        public string Index()
        {
            return "Hello From Home";
        }

        [Route("about")]

        public string About()
        {
            return "Hello From About";
        }

        [Route("contact-us/{mobile:regex(^\\d{{11}}$)}")]

        public string Contact()
        {
            return "Hello From Contact";
        }
    }
}
