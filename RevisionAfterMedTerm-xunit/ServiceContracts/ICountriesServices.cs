﻿using ServiceContracts.DTO;

namespace ServiceContracts
{
    public interface ICountriesServices
    {
        CountryResponse AddCountry(CountryAddRequest? countryAddRequest);

        List<CountryResponse> GetAllCountries();

        CountryResponse? GetCountryByCountryId(Guid? countryId);

        
    }
}