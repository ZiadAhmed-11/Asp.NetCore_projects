namespace Entities
{/// <summary>
///  Domain Model for country
/// </summary>
    public class Country
    {
        public Guid CountryId { get; set; }
        public string? CountryName { get; set; }
    }
}