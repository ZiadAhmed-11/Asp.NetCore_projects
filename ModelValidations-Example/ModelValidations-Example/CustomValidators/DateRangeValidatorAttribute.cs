using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ModelValidations_Example.CustomValidators
{

    public class DateRangeValidatorAttribute :ValidationAttribute
    {
        public string OtherPropertyName { get; set; }
        public DateRangeValidatorAttribute(string otherPropertyName)
        {
            OtherPropertyName = otherPropertyName;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value!=null)
            {
                //get ToDate

                DateTime to_date =(DateTime) value;

                //get FromDate
                PropertyInfo? otherProperty = validationContext.ObjectType.GetProperty(OtherPropertyName);

                DateTime from_date=Convert.ToDateTime(otherProperty.GetValue(validationContext.ObjectInstance));

                if (from_date > to_date)
                {
                    return new ValidationResult(ErrorMessage);
                }
                else
                    return ValidationResult.Success;
            }
            return null;
        }
    }
}
