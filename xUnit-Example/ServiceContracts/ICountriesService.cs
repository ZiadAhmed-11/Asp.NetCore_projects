using Entities;
using ServiceContracts.DTO;

namespace ServiceContracts
{
    /// <summary>
    /// Represents buisness logic for manipulating country entity 
    /// </summary>
    public interface ICountriesService
    {
        /// <summary>
        /// Adds a country object to the list of countries
        /// </summary>
        /// <param name="countryAddRequest">Country object to add </param>
        /// <returns>REturns the country object after adding it(with Id)</returns>
        CountryResponse AddCountry(CountryAddRequest? countryAddRequest);
       
    }
}