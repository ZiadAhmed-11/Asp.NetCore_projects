using System.ComponentModel.DataAnnotations;
using E_Commerce_ModelBinding.CustomValidators;
namespace E_Commerce_ModelBinding.Models
{
    public class Order
    {
        public int? OrderNo { get; set; }
        [Required(ErrorMessage = "{0} can't be empty or null.")]
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage ="{0} can't be empty or null.")]
        [Display(Name ="Invoice Price")]
        [InvoicePriceValidator]
        public double InvoicePrice { get; set; }

        [Required]
        public List<Product> Products { get; set; }

        
    }
}
