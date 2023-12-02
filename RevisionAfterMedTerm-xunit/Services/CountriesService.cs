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
        public CountriesService(bool initialize = true)
        {
            _countries = new List<Country>();
            if (initialize)
            {
                _countries.AddRange(new List<Country>() {
                new Country()
                {   CountryId=Guid.Parse("86507429-B66C-4414-A6B0-1515726E71BE"),CountryName="Cairo" },
                new Country()
                { CountryId = Guid.Parse("FCD9355A-1E86-4AD1-9BA4-E63AF7E3743F"), CountryName = "Fayoum" },
                new Country()
                { CountryId = Guid.Parse("D1774454-B27B-4E17-9CAA-E8946A905D2B"), CountryName = "Alex" },
                new Country()
                { CountryId = Guid.Parse("A4607DE1-F696-4982-9974-C72ACDEB3F8A"), CountryName = "Minia" },
                new Country()
                { CountryId = Guid.Parse("CB5A4A0E-A29E-4735-80CE-AB5214A9A8D6"), CountryName = "portSaid" }
            });
                //86507429-B66C-4414-A6B0-1515726E71BE
                //FCD9355A-1E86-4AD1-9BA4-E63AF7E3743F
                //D1774454-B27B-4E17-9CAA-E8946A905D2B
                //A4607DE1-F696-4982-9974-C72ACDEB3F8A
                //CB5A4A0E-A29E-4735-80CE-AB5214A9A8D6
            }
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
            return _countries.Select(country => country.ToCountryResponse()).ToList();
        }

        public CountryResponse? GetCountryByCountryId(Guid? countryId)
        {
            if (countryId == null)
                return null;

            Country? country_response_from_list= _countries.FirstOrDefault(temp => temp.CountryId == countryId);

            if(country_response_from_list==null)
                return null;

            return country_response_from_list.ToCountryResponse();

        }


    }
}