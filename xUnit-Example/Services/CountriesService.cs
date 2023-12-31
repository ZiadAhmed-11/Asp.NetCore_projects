﻿using ServiceContracts;
using ServiceContracts.DTO;
using Entities;
namespace Services
{
    public class CountriesService : ICountriesService
    {
        //privated field
        private readonly List<Country> _countries;

        //Constructor
        public CountriesService()
        {
            _countries = new List<Country>();
        }

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

            if (_countries.Where(temp => temp.CountryName == countryAddRequest.CountryName).Count() > 0)
            {
                throw new ArgumentException("Country Name already existd");
            }

            //convert object from CountryAddRequest to Country type
            Country country=countryAddRequest.ToCountry();

            //generate CountryId
            country.CountryId = Guid.NewGuid();
            //Add country object to _countries
            _countries.Add(country);

            return country.ToCountryResponse();
        }

        public List<CountryResponse> GetAllCountries()
        {
           return _countries.Select(country => country.ToCountryResponse()).ToList();

        }
    }
}