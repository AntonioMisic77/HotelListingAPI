using DapperTest.Models;
using DapperTest.Services.Repository.HotelRepository;

namespace DapperTest.Services.HotelService
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        
        public async Task<IEnumerable<Hotel>> GetHotelsAsync()
        {
           return await _hotelRepository.GetHotelsAsync();
        }

        public async Task<Hotel?> GetHotelAsync(int id)
        {
           var hotels = await _hotelRepository.GetHotelAsync(id);

            return hotels.Count() > 0 ? hotels.First() : null;
        }

        public async Task CreateHotelAsync(Hotel hotel)
        {
            await _hotelRepository.CreateHotelAsync(hotel);
        }

        public async Task UpdateHotelAsync(Hotel hotel)
        {
            await _hotelRepository.UpdateHotelAsync(hotel);
        }

        public async Task DeleteHotelAsync(int id)
        {
           await _hotelRepository.DeleteHotelAsync(id);
        }
    }
}
