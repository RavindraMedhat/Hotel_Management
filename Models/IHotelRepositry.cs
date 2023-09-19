using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Management.Models
{
    interface IHotelRepositry
    {
        HotelTB GetHotel(int id);
        IEnumerable<HotelTB> GetHotels();
        HotelTB Add(HotelTB hotel);
        HotelTB Update(HotelTB hotel);
        HotelTB Delete(int id);
    }
}
