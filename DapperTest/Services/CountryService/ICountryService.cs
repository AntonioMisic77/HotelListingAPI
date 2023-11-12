using DapperTest.Models;

namespace DapperTest.Services.CountryService
{
    public interface ICountryService
    {
        public Task<IEnumerable<Country>> GetCountriesAsync();

        public Task<Country?> GetCountry(int id);

        public Task CreateCountry(Country country);

        public Task UpdateCountry(Country country);

        public Task DeleteCountry(int id);
    }
}
