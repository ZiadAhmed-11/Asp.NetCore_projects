using System.ComponentModel.DataAnnotations;

namespace E_Commerce_ModelBinding.Models
{
    public class Product
    {
        [Required(ErrorMessage = "{0} can't be empty or null.")]
        [Display(Name ="Product Code")]
        [Range(1,int.MaxValue)]
        public int ProductCode { get; set; }

        [Required(ErrorMessage = "{0} can't be empty or null.")]
        [Display(Name ="Product Price")]
        [Range(1,double.MaxValue)]
        public double Price { get; set; }
        [Required(ErrorMessage = "{0} can't be empty or null.")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} should be between a valid number")]
        public int Quantity { get; set; }
    }
}
