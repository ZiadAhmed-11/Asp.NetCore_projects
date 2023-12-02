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
        public PersonsService(bool initalize=true)
        {
            _persons = new List<Person>();
            _countriesServices=new CountriesService();
            if(initalize)
            {
                //
                //2D2AEB08-3469-413B-B2E2-312D176E96E1
                //F9C2F799-3DBC-43E9-8FE9-4A2A153E4343
                //21406194-6B52-42ED-9A29-2EF68D5D4415
                _persons.Add(new Person() { PersonId = Guid.Parse("A1947EFA-5335-451F-835A-8C313D39809B"),PersonName= "Rhetta",Email= "redmott0@nature.com",DateOfBirth=DateTime.Parse( "1/14/2022"),Gender= "Female",Address= "54 Almo Place",ReceiveNewsLetters=true,CountryId=Guid.Parse ("86507429-B66C-4414-A6B0-1515726E71BE") });
                _persons.Add(new Person() { PersonId = Guid.Parse("DA7BA8D0-A77D-4B9D-810E-5FA89B1EBF45"), PersonName = "Olivie", Email = "oterren1@dagondesign.com", DateOfBirth = DateTime.Parse("11/15/2011"), Gender = "Female", Address = "1 Luster Park", ReceiveNewsLetters = true, CountryId = Guid.Parse("86507429-B66C-4414-A6B0-1515726E71BE") });

                /* 
                
,,Female,,true
Tootsie,tmarten2@dagondesign.com,3/10/2000,Female,571 Namekagon Center,true
Hansiain,hboyan3@w3.org,5/29/2019,Male,97018 Daystar Park,false
Catharina,cgennerich4@nps.gov,5/15/2001,Female,8 West Way,false
Clayton,cdrescher5@huffingtonpost.com,7/26/2002,Male,4862 Talmadge Pass,false
Aigneis,abonnavant6@unicef.org,8/21/2019,Female,507 Arkansas Parkway,false
Catlin,ccomellini7@hud.gov,6/2/2021,Female,8704 Meadow Vale Drive,true
Pennie,pbaunton8@tiny.cc,11/2/2010,Male,39342 Fallview Center,true
Nestor,nbraunroth9@themeforest.net,1/12/2018,Genderfluid,871 Grim Court,true
                */
            }
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

        public PersonResponse UpdatePerson(PersonUpdateRequest? personUpdateRequest)
        {
            if (personUpdateRequest == null)
                throw new ArgumentNullException(nameof(personUpdateRequest));
            ValidationHelper.ModelValidation(personUpdateRequest);

            //get matching person object to update
            Person? matchingPerson = _persons.FirstOrDefault(temp => temp.PersonId == personUpdateRequest.PersonId);
            if (matchingPerson == null)
                throw new ArgumentException("Given person id doesn't exist");
            
            //update all details
            matchingPerson.PersonName= personUpdateRequest.PersonName;
            matchingPerson.Email= personUpdateRequest.Email;
            matchingPerson.DateOfBirth = personUpdateRequest.DateOfBirth;
            matchingPerson.Gender = personUpdateRequest.Gender.ToString();
            matchingPerson.Address = personUpdateRequest.Address;
            matchingPerson.CountryId=personUpdateRequest.CountryId;
            matchingPerson.ReceiveNewsLetters = personUpdateRequest.ReceiveNewsLetters;

            return matchingPerson.ToPersonResponse();
        }

        public bool DeletePerson(Guid? personId)
        {
            if (personId == null)
                throw new ArgumentNullException(nameof(personId));
            Person? person = _persons.FirstOrDefault(temp => temp.PersonId == personId);
            if (person == null)
                return false;

            _persons.RemoveAll(temp => temp.PersonId == personId);
            return true;
        }
    }
}
