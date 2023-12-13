using Entities;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Services
{
    public class CountriesService : ICountriesServices
    {
        //privated field
        private readonly PersonsDbContext _db;

        //Constructor
        public CountriesService(PersonsDbContext personsDbContext)
        {
            _db = personsDbContext;
            
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
            if (_db.Countries.Count(temp => temp.CountryName == countryAddRequest.CountryName) > 0)
            {
                throw new ArgumentException("Country Name already existed");
            }

            //convert object from CountryAddRequest to Country type
            Country country = countryAddRequest.ToCountry();
            //generate CountryId
            country.CountryId = Guid.NewGuid();
            //Add country object to _countries
            _db.Countries.Add(country);
            _db.SaveChanges();

            return country.ToCountryResponse();

        }

        public List<CountryResponse> GetAllCountries()
        {
            return _db.Countries.Select(country => country.ToCountryResponse()).ToList();
        }

        public CountryResponse? GetCountryByCountryId(Guid? countryId)
        {
            if (countryId == null)
                return null;

            Country? country_response_from_list= _db.Countries.FirstOrDefault(temp => temp.CountryId == countryId);

            if(country_response_from_list==null)
                return null;

            return country_response_from_list.ToCountryResponse();

        }


    }
}