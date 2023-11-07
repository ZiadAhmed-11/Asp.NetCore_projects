using System;
using Entities;
namespace ServiceContracts.DTO
{
    /// <summary>
    /// DTO class that is used to return type for most of CountriesService Methods
    /// </summary>
    public class CountryResponse
    {
        public Guid CountryId { get; set; }
        public string? CountryName { get; set; }

    }

    public static class CountryExtensions
    {
        public static CountryResponse ToCountryResponse(this Country country)
        {
            return new CountryResponse() { CountryId = country.CountryId, CountryName = country.CountryName };
        }
    }
}
