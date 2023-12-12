using ServiceContract;
using ServiceContract.DTO;
using System;
using Entities;

namespace Services
{
    public class CountriesServices : ICountriesServices
    {
        private readonly List<Country> _countries;

        

        public CountryResponse AddCountry(CountryAddRequest? countryAddRequest)
        {
            if(countryAddRequest==null)
            {
                throw new ArgumentNullException(nameof(countryAddRequest));
            }

            if(countryAddRequest.CountryName==null)
            {
                throw new ArgumentException(nameof(countryAddRequest.CountryName));
            }
            if(_countries.Where(temp=>temp.CountryName==countryAddRequest.CountryName).Count()>0)
            {
                throw new ArgumentException("Country name already existed");
            }

            Country country = countryAddRequest.ToCountry();

            country.CountryId=Guid.NewGuid();
            _countries.Add(country);

            return country.ToCountryResponse();
        }

        public List<CountryResponse> GetAllCountries()
        {
            return _countries.Select(country => country.ToCountryResponse()).ToList();
        }

        public CountryResponse? GetCountryByCountryId(Guid? countryId)
        {
            if(countryId==null)
            {
                return null;
            }
            Country? countryFromList = _countries.FirstOrDefault(temp=>temp.CountryId==countryId);
            if (countryFromList == null)
                return null; 
            
            return countryFromList.ToCountryResponse();
        }
    }
}