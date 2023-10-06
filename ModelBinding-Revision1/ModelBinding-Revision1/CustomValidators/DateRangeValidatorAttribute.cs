using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ModelBinding_Revision1.CustomValidators
{
    public class DateRangeValidatorAttribute:ValidationAttribute
    {
        public String OtherPropertyName { get;set; }
        public DateRangeValidatorAttribute(string otherPropertyName) 
        {
            OtherPropertyName = otherPropertyName;  
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            //value= ToDate
            if (value!=null)
            {
                //get Todate
                DateTime to_date=(DateTime) value;
                //get FromDate
                PropertyInfo? otherPropert=validationContext.ObjectType.GetProperty(OtherPropertyName);
                DateTime? from_date=Convert.ToDateTime(otherPropert.GetValue(validationContext.ObjectInstance));
            if(from_date> to_date)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
            return null;
        }
    }
}
