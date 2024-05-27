using System.Collections.Generic;
using HotelBookingApp.Model;

namespace HotelBookingApp.RepositoryInterfaces
{
    public interface IAdministratorRepository
    {
        Administrator Update(Administrator administrator);

        List<Administrator> GetAll();
        
        Administrator Get(int id);

        void Save();
    }
}