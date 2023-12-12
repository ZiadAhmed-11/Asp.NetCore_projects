using ServiceContract.DTO;
using ServiceContract.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContract
{
    public interface IPersonsServices
    {
        PersonResponse AddPerson(PersonAddRequest? personAddRequest);
        List<PersonResponse> GetAddPersons();
        PersonResponse GetPersonByPersonId(Guid? personId);

        List<PersonResponse> GitFilteredPersons(string searchBy, string? searchString);

        List<PersonResponse> GetSortedPersons(List<PersonResponse> addPersons, string sortBy, SortedOrderOptions sortOrder);

        PersonResponse UpdatePerson(PersonUpdateRequest? personUpdateRequest);

        bool DeletePerson(Guid? PersonId);
    }
}
