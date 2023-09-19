using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Management.Models
{
    public class SQLHotelRepository : IHotelRepositry
    {
        private readonly AppDBContext context;

        public SQLHotelRepository(AppDBContext context)
        {
            this.context = context;
        }
        public HotelTB Add(HotelTB hotel)
        {
            context.Hotels.Add(hotel);
            context.SaveChanges();
            return hotel;
        }

        public HotelTB Delete(int id)
        {
           HotelTB hotel = context.Hotels.Find(id);
            if (hotel != null)
            {
                context.Hotels.Remove(hotel);
                context.SaveChanges();
            }
            return hotel;
        }

        public HotelTB GetHotel(int id)
        {
           HotelTB hotel = context.Hotels.Find(id);
            return hotel;
        }

        public IEnumerable<HotelTB> GetHotels()
        {
            return context.Hotels;
        }

        public HotelTB Update(HotelTB hotel)
        {

            var Newhotel = context.Hotels.Attach(hotel);
            Newhotel.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

            return hotel;
        }

     
    }
}
