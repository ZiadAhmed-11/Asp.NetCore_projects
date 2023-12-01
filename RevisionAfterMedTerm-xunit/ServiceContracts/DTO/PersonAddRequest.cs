using System;
using ServiceContracts.DTO.Enums;
using Entities;
using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.DTO
{
    public class PersonAddRequest
    {
        [Required(ErrorMessage ="Person Name can't be blank")]
        public string? PersonName { get; set; }
        [Required(ErrorMessage ="Email can't be blank")]
        [EmailAddress(ErrorMessage ="Email should be valid email")]
        public string? Email { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public GenderOptions? Gender { get; set; }
        public Guid? CountryId { get; set; }
        public string? Address { get; set; }
        public bool? ReceiveNewsLetters { get; set; }

        public Person ToPerson()
        {
            return new Person() { PersonName= PersonName, Email = Email, DateOfBirth=DateOfBirth,Gender=Gender.ToString(),Address=Address,CountryId=CountryId,ReceiveNewsLetters=ReceiveNewsLetters};
        }
    }
}

