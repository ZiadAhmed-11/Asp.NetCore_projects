using ModelBinding_Revision1.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace ModelBinding_Revision1.Models
{
    public class Person: IValidatableObject
    {
        [Required (ErrorMessage ="{0} can't be empty or null.")]
        [Display(Name ="Person Name")]
        public string? PersonName { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public double? Price { get; set; }
        [MinimumYearValidator]
        public DateTime? DateOfBirth { get; set; }
        public int? Age { get; set; }

        public DateTime? FromDate { get; set; }
        [DateRangeValidator("FromDate",ErrorMessage="From Date should be older than to date or equal")]
        public DateTime? ToDate { get; set; }
        public override string ToString()
        {
            return $"Person Object - Person name: {PersonName}, Email: {Email}, Phone: {Phone}, Password: {Password}, ConfirmPassword: {ConfirmPassword}, Price: {Price}";
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(Age.HasValue==false&&DateOfBirth.HasValue==false)
            {
                yield return new ValidationResult("Either Date of birth or Age must be supplied.");
            }
        }
    }
}
