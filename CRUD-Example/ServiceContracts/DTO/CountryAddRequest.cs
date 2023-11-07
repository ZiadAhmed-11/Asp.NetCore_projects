using System;
using System.Collections.Generic;
using Entities;
namespace ServiceContracts.DTO
{
    public class CountryAddRequest
    {
        /// <summary>
        /// DTO class for adding new country
        /// </summary>
        public string? CountryName { get; set; }
        // id not a part of country request

        public Country ToCountry()
        {
            return new Country { CountryName = CountryName };
        }

    }
}
