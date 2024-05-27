using HotelBookingApp.Model;
using System.Collections.Generic;


namespace HotelBookingApp.ControllerInterfaces
{
    public interface IGuestController
    {

        List<Guest> GetAll();
        Guest Get(int id);
        void Update(Guest entity);
        Guest GetByEmailAndPassword(string email, string password);
        void Save();


    }
}
