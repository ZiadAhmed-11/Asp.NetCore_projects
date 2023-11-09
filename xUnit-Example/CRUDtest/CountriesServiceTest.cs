using ServiceContracts;
using ServiceContracts.DTO;
using System;
using System.Collections.Generic;

namespace CRUDtest
{
    public class CountriesServiceTest
    {
        private readonly ICountriesService _countriesService;

        public CountriesServiceTest(ICountriesService countriesService)
        {
            _countriesService = countriesService;
        }
    }
}
