using ServiceContract.DTO;

namespace ServiceContract
{
    public interface ICountriesServices
    {
        CountryResponse AddCountry(CountryAddRequest? countryAddRequest);

        List<CountryResponse> GetAllCountries();

        CountryResponse? GetCountryByCountryId(Guid? countryId);
    }
}