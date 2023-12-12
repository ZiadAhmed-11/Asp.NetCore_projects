using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Helpers
{
    public class ValidationHelper
    {
        internal static void ModelValidation(object obj)
        {
            {
                ValidationContext validationContext = new ValidationContext(obj);
                List<ValidationResult> validationResults = new List<ValidationResult>();

                bool isvalid=Validator.TryValidateObject(obj,validationContext,validationResults,true);
                if (!isvalid)
                {
                    throw new ArgumentException(validationResults.FirstOrDefault()?.ErrorMessage);
                }
            }
        }


    }
}
