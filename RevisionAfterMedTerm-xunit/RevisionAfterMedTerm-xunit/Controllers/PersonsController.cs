using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.DTO.Enums;

namespace RevisionAfterMedTerm_xunit.Controllers
{
    public class PersonsController : Controller
    {
        //private field
        private readonly IPersonService _personService;

        //constructor
        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        [Route("persons/index")]
        [Route("/")]
        public IActionResult Index(string searchBy,string? searchString,string sortBy=nameof(PersonResponse.PersonName),SortOrderOptions sortOrder =SortOrderOptions.ASC)
        {
            //search
            ViewBag.SearchFields = new Dictionary<string, string>
            {
                { nameof(PersonResponse.PersonName) ,"Perons Name"},
                { nameof(PersonResponse.Email) ,"Email"},
                { nameof(PersonResponse.DateOfBirth) ,"Date of Birth"},
                { nameof(PersonResponse.Gender) ,"Gender"},
                { nameof(PersonResponse.Country) ,"Country"},
                { nameof(PersonResponse.Address) ,"Address"}
            };
            List<PersonResponse> persons = _personService.GetFilteredPersons(searchBy, searchString);

            ViewBag.CurrentSearchBy = searchBy;
            ViewBag.CurrentSearchString = searchString;

            //sort
            List<PersonResponse> sortedPerson= _personService.GetSortedPersons(persons, sortBy, sortOrder);
            ViewBag.CurrentSortBy = sortBy;
            ViewBag.CurrentSortOrder=sortOrder;
            return View(persons);
        }
    }
}
