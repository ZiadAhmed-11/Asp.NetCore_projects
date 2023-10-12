using Microsoft.AspNetCore.Mvc;
using wheather_RazorView.Models;

namespace wheather_RazorView.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        [Route("/home")]
        public IActionResult Index()
        {
            List<CityWeather> cityWeathers = new() {
            new CityWeather() {CityUniqueCode="LDN",CityName="London",DateAndTime=Convert.ToDateTime("2030-01-01 8:00"),TemperatureFahrenheit=33},
            new CityWeather() {CityUniqueCode="NYC",CityName="NewYork",DateAndTime=Convert.ToDateTime("2030-01-01 3:00"),TemperatureFahrenheit=60},
            new CityWeather() {CityUniqueCode="PAR",CityName="Paris",DateAndTime=Convert.ToDateTime("2030-01-01 9:00"),TemperatureFahrenheit=82}
            };

            return View( cityWeathers);
        }
        [Route("details/{cityCode?}")]
        public IActionResult City(string? cityCode)
        {
            List<CityWeather> cityWeathers = new() {
            new CityWeather() {CityUniqueCode="LDN",CityName="London",DateAndTime=Convert.ToDateTime("2030-01-01 8:00"),TemperatureFahrenheit=33},
            new CityWeather() {CityUniqueCode="NYC",CityName="NewYork",DateAndTime=Convert.ToDateTime("2030-01-01 3:00"),TemperatureFahrenheit=60},
            new CityWeather() {CityUniqueCode="PAR",CityName="Paris",DateAndTime=Convert.ToDateTime("2030-01-01 9:00"),TemperatureFahrenheit=82}
            };
            //if cityCode is not supplied in the route parameter
            if (string.IsNullOrEmpty(cityCode))
            {
                //send null as model object to "Views/Weather/Index" view
                return View();
            }

            //get matching city object based on the city code
            CityWeather? city = cityWeathers.Where(temp => temp.CityUniqueCode == cityCode).FirstOrDefault();

            //send matching city object to "Views/Weather/Index" view
            return View(city);
        }
    }
}
