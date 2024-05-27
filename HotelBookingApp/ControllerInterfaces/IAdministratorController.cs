using HotelBookingApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingApp.ControllerInterfaces
{
    public interface IAdministratorController
    {

        List<Administrator> GetAll();
        Administrator Get(int id);
        Administrator Update(Administrator entity);
        Administrator GetByEmailAndPassword(string email, string password);
        void Save();

    }
}
