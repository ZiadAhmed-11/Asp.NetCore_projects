using System;
using Entities;
using ServiceContracts;
using ServiceContracts.DTO;
namespace Services
{
    public class PersonsService : IPersonService
    {
        //private field (list)
        private readonly List<Person> _persons;
        private readonly ICountriesServices _countriesServices;
        //constructor
        public PersonsService()
        {
            _persons = new List<Person>();
            _countriesServices=new CountriesService();
        }
        public PersonResponse AddPerson(PersonAddRequest request)
        {
            // validation
            if(request==null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            if(request.PersonName==null)
            {
                throw new ArgumentException("PersonName can't be blank");
            }

            // convert PersonAddRequest to Person object - before add to list
            Person person=request.ToPerson();

            // generate PersonId
            person.PersonId=Guid.NewGuid();
            //add person object to the list
            _persons.Add(person);

            //convert to PersonResponse
            PersonResponse personResponse = person.ToPersonResponse();
            personResponse.Country = _countriesServices.GetCountryById(person.CountryId)?.CountryName;
            
        }

        public List<PersonResponse> GetAllPersons()
        {
            throw new NotImplementedException();
        }
    }
}
