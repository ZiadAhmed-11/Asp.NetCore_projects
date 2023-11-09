using System.ComponentModel.DataAnnotations;

namespace CitiesManager.WebAPI.Models
{
    public class city
    {
        [Key]
        public Guid cityId { get; set; }
        public string? cityName { get; set; }
    }
}
