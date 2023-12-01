using System;
using ServiceContracts.DTO;
using ServiceContracts.DTO.Enums;

namespace ServiceContracts
{
    public interface IPersonService
    {
        PersonResponse AddPerson(PersonAddRequest request);
        List<PersonResponse> GetAllPersons();

        PersonResponse? GetPersonByPersonId(Guid? personId);

        List<PersonResponse> GetFilteredPersons(string searchBy, string? searchstring);

        List<PersonResponse> GetSortedPersons(List<PersonResponse> addPersons, string sortBy, SortOrderOptions sortOrder); 
    }
}
