using System.ComponentModel.DataAnnotations;
using CustomValidations_Examples2.CustomValidators;
namespace ModelValidations_Examples2.Models
{
    public class Person
    {
        [Required(ErrorMessage = "{0} can't be empty or null")]
        [Display(Name = "Person name")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} should be between {2} and {1} characters long")]
        public string? PersonName { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
        /*[RegularExpression("^01[0125][0-9]{8}$\r\n",ErrorMessage ="The phone number is not valid")]*/
        public string? Phone { get; set; }

        [Required(ErrorMessage = "{0} can't be empty or null")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "{0} can't be empty or null")]
        [Compare("Password")]
        public string? ConfirmPassword { get; set; }
        [Range(0,999.99,ErrorMessage ="{0} should be between {1} and {2} ")]
        public double? Price { get; set; }

        [DateRangeValidator("FromDate",ErrorMessage="From date should be older than or equal to 'To date'")]
        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }   

        [MinimumYearValidatorAttribute]
        public DateTime? DateOfBirth { get; set; }

        public override string ToString()
        {
            return $"Person Object - Person Name: {PersonName}, Email: {Email}, Phone: {Phone}, Password: {Password}, Confirm Password: {ConfirmPassword}, Price: {Price}";
        }
    }
}
