using System.ComponentModel.DataAnnotations;

namespace ModelValidations_Example.CustomValidators
{
    public class MinimumYearValidatorAttr:ValidationAttribute
    {
        public int MinimumYear { get; set; }
        //parametered Constructor
        public MinimumYearValidatorAttr() 
        {
            
        }
        public MinimumYearValidatorAttr(int minimumYear)
        {
            MinimumYear = minimumYear;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime date = (DateTime)value;
                if (date.Year >= 2000)
                {
                    return new ValidationResult("Minimum year allowed is 2000");
                }
                else
                    return ValidationResult.Success;
            }
            else
                return null;
        }
    }
}
