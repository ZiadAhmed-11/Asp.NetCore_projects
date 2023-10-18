using Microsoft.AspNetCore.Mvc;
using ViewComponentsExample.Models;
namespace ViewComponentsExample.ViewComponents
{
    public class GridViewComponent :ViewComponent
    {

        public async Task<IViewComponentResult>InvokeAsync()
        {
            PersonGridModel model = new PersonGridModel()
            {
                GridTitle = "Persons List",
                Persons = new List<Person> { 
                    new Person() {PersonName="Ziad",JobTitle="Manager" },
                    new Person(){PersonName="Taha",JobTitle="Manager" },
                    new Person(){PersonName="Mostafa",JobTitle="Employee"}
                }
            };
            ViewData["Grid"] = model;
            return View(model); //invoked a partial view Views/Shared/Components/Grid/Default.cshtml
        }
    }
}
