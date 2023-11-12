using DapperTest.Models;
using DapperTest.Services.Repository.CountryRepository;

namespace DapperTest.Services.CountryService
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
                _countryRepository = countryRepository;
        }
        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            return await  _countryRepository.GetCountriesAsync();

        }

        public async Task<Country?> GetCountry(int id)
        {
           var countryEnumerable = await _countryRepository.GetCountryAsync(id);

            return countryEnumerable.Count() > 0 ? countryEnumerable.First() : null;
        }


        public async Task CreateCountry(Country country)
        {
            await _countryRepository.CreateCountryAsync(country);

        }

        public async Task UpdateCountry(Country country)
        {
            await _countryRepository.UpdateCountryAsync(country);
        }

        public async Task DeleteCountry(int id)
        {

            await _countryRepository.DeleteCountryAsync(id);

        }
    }
}
