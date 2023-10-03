using System.ComponentModel.DataAnnotations;

namespace CustomValidations_Examples2.CustomValidators
{
    public class MinimumYearValidatorAttribute :ValidationAttribute
    {
        public int MinimumYear { get; set; } = 2000;
        // parameterless constructor
        public MinimumYearValidatorAttribute()
        {
        }
        // parameterized constructor
        public MinimumYearValidatorAttribute(int minimumYear)
        {
            MinimumYear = minimumYear;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime date = (DateTime)value;

                if (date.Year >= MinimumYear)
                {
                    return new ValidationResult("Minimum year allowed is 2000");
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            else
                return null;
        }
    }
}
