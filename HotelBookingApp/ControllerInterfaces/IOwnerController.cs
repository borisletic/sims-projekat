using HotelBookingApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingApp.ControllerInterfaces
{
    public interface IOwnerController
    {

        List<Owner> GetAll();
        Owner Get(int id);
        Owner Update(Owner entity);
        Owner GetByEmailAndPassword(string email, string password);
        void Create(Owner owner);
        void Save();

    }
}
