using DapperTest.Models;

namespace DapperTest.Services.HotelService
{
    public interface IHotelService
    {
        public Task<IEnumerable<Hotel>> GetHotelsAsync();

        public Task<Hotel?> GetHotelAsync(int id);

        public Task CreateHotelAsync(Hotel hotel);

        public Task UpdateHotelAsync(Hotel hotel);

        public Task DeleteHotelAsync(int id);
    }
}
