using Microsoft.AspNetCore.Mvc;
using ViewsExample.Models;

namespace ViewsExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("Home")]
        [Route("/")]
        public IActionResult Index()
        {
            ViewData["AppTitle"] = "Asp.Net Core App";

            List<Person> people = new List<Person>() 
            {
                new Person(){ name = "Ziad", DateOfBirth = Convert.ToDateTime("2002-08-11") },
                new Person(){name="Linda", DateOfBirth=DateTime.Parse("2000-5-7")},
                new Person(){name="Susan",DateOfBirth=DateTime.Parse("1983-11-9")} 
            };

            //ViewData["people"] = people;
            //ViewBag.People = people;

            return View("Index",people);
        }

        [Route("/person-details/{name}")]
        public IActionResult Details(string? name)
        {
            if(name==null)
            {
                return Content("Person name can't be null.");
            }
            List<Person> people = new List<Person>()
            {
                new Person(){ name = "Ziad", DateOfBirth = Convert.ToDateTime("2002-08-11"), },
                new Person(){name="Linda", DateOfBirth=DateTime.Parse("2000-5-7")},
                new Person(){name="Susan",DateOfBirth=DateTime.Parse("1983-11-9")}
            };
            Person? matchingPerson = people.Where(temp => temp.name == name).FirstOrDefault();
            return View(matchingPerson);
        }

        [Route("person-with-product")]
        public IActionResult PersonWithProduct()
        {
            Person person = new Person() {name="Taha",DateOfBirth=Convert.ToDateTime("2004-10-07") };
            Product product = new Product() { ProductId = 1,ProductName="Air Conditioner" };
            PersonAndProductWrapperModel personAndProductWrapperModel = new PersonAndProductWrapperModel() { PersonData = person, ProductData = product };
            return View(personAndProductWrapperModel);
        }
    }
}
