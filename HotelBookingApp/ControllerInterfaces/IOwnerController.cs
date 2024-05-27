using HotelBookingApp.Model;
using System.Collections.Generic;


namespace HotelBookingApp.ControllerInterfaces
{
    public interface IOwnerController
    {

        List<Owner> GetAll();
        Owner Get(int id);
        Owner Update(Owner owner);
        Owner GetByEmailAndPassword(string email, string password);
        void Create(Owner owner);
        void Save();

    }
}
