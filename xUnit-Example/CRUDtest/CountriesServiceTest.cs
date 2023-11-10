using ServiceContracts;
using ServiceContracts.DTO;
using Services;
using System;
using System.Collections.Generic;

namespace CRUDtest
{
    public class CountriesServiceTest
    {
        private readonly ICountriesService _countriesService;

        public CountriesServiceTest()
        {
            _countriesService = new CountriesService();
        }
#region AddCountry
        // When CountryAddRequest is null, it should throw ArgumentNullException
        [Fact]
        public void AddCountry_NullCountry()
        {
            //Arrange
            CountryAddRequest? request =  null;
           
            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                //Act
                _countriesService.AddCountry(request);
            });
        }

        // When CountryName is null, it should throw ArgumentException
        [Fact]
        public void AddCountry_CountryNameIsNull()
        {
            //Arrange
            CountryAddRequest? request = new CountryAddRequest{CountryName=null };

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                _countriesService.AddCountry(request);
            });
        }

        // When CountryName is duplicate, it should throw ArgumentException
        [Fact]
        public void AddCountry_CountryNameIsDublicate()
        {
            //Arrange
            CountryAddRequest? request1 = new CountryAddRequest() { CountryName="Cairo"};
            CountryAddRequest? request2 = new CountryAddRequest() { CountryName = "Cairo" };

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                _countriesService.AddCountry(request1);
                _countriesService.AddCountry(request2);

            });
        }

        // When you supply proper country name ,it should insert (add) to list of countries 
        [Fact]
        public void AddCountry_properCountryDetails()
        {
            //Arrange
            CountryAddRequest? request = new CountryAddRequest { CountryName = "Giza" };

            //Act
            CountryResponse response= _countriesService.AddCountry(request);

            //Assert
            Assert.True(response.CountryId != Guid.Empty);
        }
        #endregion

        #region GetAllCountries
        [Fact]
        // the list of countries should be Empty by default
        public void GetAllCountries_EmptyList()
        {
            //Act
            List<CountryResponse> Actual_country_response_list= _countriesService.GetAllCountries();

            //Assert
            Assert.Empty(Actual_country_response_list);
        }

        [Fact]
        public void GetCountries_AddFewCountries()
        {
            List<CountryAddRequest>
        }

        #endregion
    }
}
