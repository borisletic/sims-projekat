using HotelBookingApp.Model;
using System.Collections.Generic;


namespace HotelBookingApp.ControllerInterfaces
{
    public interface IHotelController
    {

        List<Hotel> GetAll();
        Hotel Get(int id);
        void Update(Hotel hotel);
        void Create(Hotel hotel);
        List<Apartment> GetAllApartments();
        void Delete(Hotel hotel);
        void Save();

    }
}
