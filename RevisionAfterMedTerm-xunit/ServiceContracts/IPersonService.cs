using System;
using ServiceContracts.DTO;
namespace ServiceContracts
{
    public interface IPersonService
    {
        PersonResponse AddPerson(PersonAddRequest request);
        List<PersonResponse> GetAllPersons();
    }
}
