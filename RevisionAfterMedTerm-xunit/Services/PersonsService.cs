using System;
using System.ComponentModel.DataAnnotations;
using Entities;
using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.DTO.Enums;
using Services.Helpers;

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

        private PersonResponse ConvertPersonToPersonResponse(Person person)
        {
            PersonResponse personResponse = person.ToPersonResponse();
            personResponse.Country = _countriesServices.GetCountryByCountryId(person.CountryId)?.CountryName;
            return personResponse;
        }

        public PersonResponse AddPerson(PersonAddRequest request)
        {
            // check if PersonAddRequest is null
            if(request==null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            //Model Validation
            ValidationHelper.ModelValidation(request);

            // convert PersonAddRequest to Person object - before add to list
            Person person=request.ToPerson();

            // generate PersonId
            person.PersonId=Guid.NewGuid();

            //add person object to the list
            _persons.Add(person);

            //convert to PersonResponse
            return ConvertPersonToPersonResponse(person);
            
        }

        public List<PersonResponse> GetAllPersons()
        {
            return _persons.Select(temp => temp.ToPersonResponse()).ToList();
        }

        public PersonResponse? GetPersonByPersonId(Guid? personId)
        {
            if (personId == null)
                return null;
            Person? person= _persons.FirstOrDefault(temp => temp.PersonId == personId);
            if (person == null)
                return null;
            return person.ToPersonResponse() ?? null;
        }

        public List<PersonResponse> GetFilteredPersons(string searchBy, string? searchstring)
        {
            List<PersonResponse> allPersons = GetAllPersons();
            List<PersonResponse> matchingPersons = allPersons;

            if (searchBy == null || searchstring==null)
                return matchingPersons;

            switch (searchBy)
            {
                case nameof(Person.PersonName):
                    matchingPersons = allPersons.Where(temp =>
                    (temp.PersonName!=null)?temp.PersonName.Contains(searchstring,StringComparison.OrdinalIgnoreCase) : true).ToList();
                    break;

                case nameof(Person.Email):
                    matchingPersons = allPersons.Where(temp =>
                    (temp.Email != null) ? temp.Email.Contains(searchstring, StringComparison.OrdinalIgnoreCase) : true).ToList();
                    break;

                case nameof(Person.DateOfBirth):
                    matchingPersons = allPersons.Where(temp =>
                    (temp.DateOfBirth != null) ? temp.DateOfBirth.Value.ToString("dd MMMM yyyy").Contains(searchstring, StringComparison.OrdinalIgnoreCase) : true).ToList();
                    break;

                case nameof(Person.Gender):
                    matchingPersons = allPersons.Where(temp =>
                    (temp.Gender != null) ? temp.Gender.Contains(searchstring, StringComparison.OrdinalIgnoreCase) : true).ToList();
                    break;

                case nameof(Person.CountryId):
                    matchingPersons = allPersons.Where(temp =>
                    (temp.Country != null) ? temp.Country.Contains(searchstring, StringComparison.OrdinalIgnoreCase) : true).ToList();
                    break;

                case nameof(Person.Address):
                    matchingPersons = allPersons.Where(temp =>
                    (temp.Address != null) ? temp.Address.Contains(searchstring, StringComparison.OrdinalIgnoreCase)    : true).ToList();
                    break;

                default: matchingPersons=allPersons; break;
            }
            return matchingPersons;
        }

        public List<PersonResponse> GetSortedPersons(List<PersonResponse> allPersons, string sortBy, SortOrderOptions sortOrder)
        {
            if (sortBy != null)
                return allPersons;

            List<PersonResponse> sortedPersons = (sortBy, sortOrder) switch
            {
                (nameof(PersonResponse.PersonName), SortOrderOptions.ASC) => allPersons.OrderBy(temp => temp.PersonName, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.PersonName), SortOrderOptions.DESC) => allPersons.OrderBy(temp => temp.PersonName, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.Email),
            SortOrderOptions.ASC) => allPersons.OrderBy(temp => temp.Email, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.Email),
                SortOrderOptions.DESC) => allPersons.OrderBy(temp => temp.Email, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.DateOfBirth),
            SortOrderOptions.ASC) => allPersons.OrderBy(temp => temp.DateOfBirth).ToList(),

                (nameof(PersonResponse.DateOfBirth),
                SortOrderOptions.DESC) => allPersons.OrderBy(temp => temp.DateOfBirth).ToList(),

                (nameof(PersonResponse.Age),
                SortOrderOptions.ASC) => allPersons.OrderBy(temp => temp.Age).ToList(),

                (nameof(PersonResponse.Age),
                SortOrderOptions.DESC) => allPersons.OrderBy(temp => temp.Age).ToList(),

                (nameof(PersonResponse.Gender),
            SortOrderOptions.ASC) => allPersons.OrderBy(temp => temp.Gender, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.Gender),
                SortOrderOptions.DESC) => allPersons.OrderBy(temp => temp.Gender, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.Country),
            SortOrderOptions.ASC) => allPersons.OrderBy(temp => temp.Country, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.Country),
                SortOrderOptions.DESC) => allPersons.OrderBy(temp => temp.Country, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.Address),
            SortOrderOptions.ASC) => allPersons.OrderBy(temp => temp.Email, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.Address),
                SortOrderOptions.DESC) => allPersons.OrderBy(temp => temp.Email, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.ReceiveNewsLetters),
            SortOrderOptions.ASC) => allPersons.OrderBy(temp => temp.ReceiveNewsLetters).ToList(),

                (nameof(PersonResponse.ReceiveNewsLetters),
                SortOrderOptions.DESC) => allPersons.OrderBy(temp => temp.ReceiveNewsLetters).ToList(),
                _ => allPersons
            } ;

            return sortedPersons;
        }
    }
}
