using System.ComponentModel.DataAnnotations;

namespace ModelBinding_Revision2.Models
{
    public class Person
    {
        [Required]
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public override string ToString()
        {
            return $"Person Id: {Id}, Person Name: {Name}, Email: {Email}, PHone: {Phone}";
        }
    }
}
