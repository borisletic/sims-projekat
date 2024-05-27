using HotelBookingApp.Model;
using System.Collections.Generic;


namespace HotelBookingApp.ControllerInterfaces
{
    public interface IApartmentController
    {

        void BindHotel();
        List<Apartment> GetAll();
        Apartment Get(int id);
        void Create(Apartment apartment);
        void Delete(Apartment apartment);
        Apartment Update(Apartment apartment);
        void Save();

    }
}
