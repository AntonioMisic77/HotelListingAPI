using DapperTest.Models;

namespace DapperTest.Services.Repository.HotelRepository
{
    public interface IHotelRepository
    {
        public Task<IEnumerable<Hotel>> GetHotelsAsync();

        public Task<IEnumerable<Hotel>> GetHotelAsync(int id);

        public Task CreateHotelAsync(Hotel hotel);

        public Task UpdateHotelAsync(Hotel hotel);

        public Task DeleteHotelAsync(int id);

    }
}
