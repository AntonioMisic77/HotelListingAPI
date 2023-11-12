using DapperTest.Models;

namespace DapperTest.Services.Repository.CountryRepository
{
    public interface ICountryRepository
    {

        #region Methods
        public Task<IEnumerable<Country>> GetCountriesAsync();

        public Task<IEnumerable<Country>> GetCountryAsync(int id);

        public Task CreateCountryAsync(Country country);

        public Task UpdateCountryAsync(Country country);

        public Task DeleteCountryAsync(int id);

        #endregion
    }
}
