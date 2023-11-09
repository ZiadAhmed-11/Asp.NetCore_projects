using System;
using System.Collections.Generic;
using Entities;
using ServiceContracts.DTO;
using ServiceContracts;
using Services;

namespace CRUDtests
{
    public class CountriesServiceTest
    {
        private readonly ICountriesService _countriesService;
        public CountriesServiceTest()
        {
            _countriesService = new CountriesService();
        }
        [Fact]
        // when countryAddRequest is null
        public void AddCountry_NullCountry()
        {
            //arrange
            CountryAddRequest? request = null;
            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                //Act
                _countriesService.AddCountry(request);
            });
        }

        // when CountryName is null
        [Fact]
        public void AddCountry_CountryNameIsNill()
        {
            //arrange
            CountryAddRequest? request = new CountryAddRequest { CountryName=null};
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                _countriesService.AddCountry(request);
            });
        }

        // when countryName is duplicated
        [Fact]
        public void AddCountry_CountryNameIsDuplicated()
        {
            //arrange
            CountryAddRequest? request1 = new CountryAddRequest { CountryName = "USA" };
            CountryAddRequest? request2 = new CountryAddRequest { CountryName = "USA" };
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                _countriesService.AddCountry(request1);
                _countriesService.AddCountry(request2);
            });
        }
        //When no error (insert the country to the list)
        [Fact]
        public void AddCountry_ProperCountryDetails()
        {
            //arrange
            CountryAddRequest? request = new CountryAddRequest { CountryName = "Cairo" };
            
            //Act
            CountryResponse response=_countriesService.AddCountry(request);
            //Assert
            Assert.True(response.CountryId != Guid.Empty);
            
        }
    }
}
