using HotelBookingApp.Model;
using System.Collections.Generic;


namespace HotelBookingApp.ControllerInterfaces
{
    public interface IApartmentController
    {

        void BindHotel();
        List<Apartment> GetAll();
        Apartment Get(int id);
        void Create(Apartment entity);
        void Delete(Apartment entity);
        Apartment Update(Apartment entity);
        void Save();

    }
}
