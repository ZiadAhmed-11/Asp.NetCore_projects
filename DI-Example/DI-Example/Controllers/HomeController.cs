using Microsoft.AspNetCore.Mvc;
using Services;
using ServiceContract;
namespace DI_Example.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICitiesService _CitiesService1;
        private readonly ICitiesService _CitiesService2;
        private readonly ICitiesService _CitiesService3;

        //Constractor
        public HomeController(ICitiesService citiesService1,ICitiesService citiesService2,ICitiesService citiesService3)
        {
            //Create object of CitiesService class
            //Most Problematic statement (why we use denpendency injection)
            // it is not a much problem but should be a problem in the real world project
            _CitiesService1 = citiesService1;//new CitiesService();
            _CitiesService2 = citiesService2;
            _CitiesService3 = citiesService3;
        }
        [Route("/")]
        public IActionResult Index()
        {
            List<string> cities= _CitiesService1.GetCities();
            ViewBag.InstanceId_CitiesServices_1 = _CitiesService1.ServiceInstanceId;
            ViewBag.InstanceId_CitiesServices_2 = _CitiesService2.ServiceInstanceId;
            ViewBag.InstanceId_CitiesServices_3 = _CitiesService3.ServiceInstanceId;

            return View(cities);
        }
    }
}
