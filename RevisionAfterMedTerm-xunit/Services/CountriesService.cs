using Entities;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Services
{
    public class CountriesService : ICountriesServices
    {
        //privated field
        private readonly List<Country> _countries;

        //Constructor
        public CountriesService()
        {
            _countries = new List<Country>();
        }

        public CountryResponse AddCountry(CountryAddRequest? countryAddRequest)
        {//validation
            if (countryAddRequest == null)
            {
                throw new ArgumentNullException(nameof(countryAddRequest));
            }

            if (countryAddRequest.CountryName == null)
            {
                throw new ArgumentException(nameof(countryAddRequest.CountryName));
            }
            if (_countries.Where(temp => temp.CountryName == countryAddRequest.CountryName).Count() > 0)
            {
                throw new ArgumentException("Country Name already existd");
            }

            //convert object from CountryAddRequest to Country type
            Country country = countryAddRequest.ToCountry();
            //generate CountryId
            country.CountryId = Guid.NewGuid();
            //Add country object to _countries
            _countries.Add(country);
           
            return country.ToCountryResponse();

        }

        public List<CountryResponse> GetAllCountries()
        {
            throw new NotImplementedException();
        }
    }
}