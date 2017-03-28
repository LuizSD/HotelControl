using System.Collections.Generic;
using Core.Hotel;


namespace HotelControl.Repository.Contracts
{
    interface IHotelRepository
    {
        List<Hotel> GetsHotels();
        List<string> GetCheapestHotel(string fileName);
    }
}
