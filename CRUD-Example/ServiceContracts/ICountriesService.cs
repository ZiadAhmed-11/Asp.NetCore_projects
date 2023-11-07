using ServiceContracts.DTO;

namespace ServiceContracts
{
    public interface ICountriesService
    {
        /// <summary>
        /// Adds country object to the list of countries
        /// </summary>
        /// <param name="countryAddRequest">Country object to add</param>
        /// <returns>Returns the country object after adding it (included newly generater country id)</returns>
        CountryResponse AddCountry(CountryAddRequest? countryAddRequest);

    }
}