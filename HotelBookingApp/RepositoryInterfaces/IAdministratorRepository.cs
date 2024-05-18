using System.Collections.Generic;
using HotelBookingApp.Model;

namespace HotelBookingApp.RepositoryInterfaces
{
    public interface IAdministratorRepository
    {
        Administrator Update(Administrator entity);

        List<Administrator> GetAll();
        
        Administrator Get(int id);

        void Save();
    }
}