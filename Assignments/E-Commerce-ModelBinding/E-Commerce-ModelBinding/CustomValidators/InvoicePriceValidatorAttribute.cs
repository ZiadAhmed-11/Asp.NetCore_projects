using E_Commerce_ModelBinding.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection;


namespace E_Commerce_ModelBinding.CustomValidators
{
    public class InvoicePriceValidatorAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value!=null)
            {
                //get products
                PropertyInfo? otherProperty = validationContext.ObjectType.GetProperty(nameof(Order.Products));
                if(otherProperty!=null) 
                {
                    //get value of Products of current object
                    List<Product> products= (List<Product>)otherProperty.GetValue(validationContext.ObjectInstance)!; //"!" operator specifies that the value returned by GetValue() will not be null


                    //calc total value
                    double totalPrice = 0;
                    foreach(var Product in products)
                    {
                        totalPrice += Product.Price*Product.Quantity;
                    }
                    
                    //value of "InviocePrice"
                    double actualPrice=(double)value;

                    if(totalPrice>0)
                    {
                        if(totalPrice!=actualPrice)
                        {
                            return new ValidationResult(ErrorMessage = "Invoice Price should be equal to the total cost of all products in the order");
                        }
                    }
                    else
                    {
                        return new ValidationResult(ErrorMessage = "No products found.");
                    }

                    return  ValidationResult.Success;
                }
                return null;

            }
            else
            return null;
        }
    }
}
