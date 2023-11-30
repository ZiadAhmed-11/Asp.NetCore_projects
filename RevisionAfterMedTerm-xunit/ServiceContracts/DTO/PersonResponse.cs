using Entities;
using System;
using System.Runtime.CompilerServices;

namespace ServiceContracts.DTO
{
    public class PersonResponse
    {
        public Guid PersonId { get; set; }
        public string? PersonName { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public Guid? CountryId { get; set; }
        public string? Country { get; set; }

        public string? Address { get; set; }
        public bool? ReceiveNewsLetters { get; set; }
        public double? Age { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != typeof(PersonResponse)) return false;
            
            PersonResponse person= (PersonResponse)obj;

            return PersonId == person.PersonId&&PersonName==person.PersonName&&Email==person.Email&&DateOfBirth==person.DateOfBirth&&Gender==person.Gender&&CountryId==person.CountryId&&Address==person.Address&&ReceiveNewsLetters==person.ReceiveNewsLetters;

        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

    }
    public static class PersonExtensions
    {
        public static PersonResponse ToPersonResponse(this Person person)
        {
            //person=> PersonResponse
            return new PersonResponse() { PersonId = person.PersonId, PersonName = person.PersonName, Email = person.Email, DateOfBirth = person.DateOfBirth, Gender = person.Gender, Address = person.Address, ReceiveNewsLetters = person.ReceiveNewsLetters, Age = (person.DateOfBirth != null) ? Math.Round((DateTime.Now - person.DateOfBirth.Value).TotalDays / 365.25) : null };
        }
    }

}
