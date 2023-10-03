using System.ComponentModel.DataAnnotations;

namespace CustomValidations_Examples2.CustomValidators
{
    public class DateRangeValidatorAttribute:ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value != null)
            {
                DateTime to_date = (DateTime)value;

            }
        }
    }
}
