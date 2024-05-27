using HotelBookingApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
