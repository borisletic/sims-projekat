using HotelBookingApp.Service;
using HotelBookingApp.Model;
using System.Collections.Generic;
using HotelBookingApp.ControllerInterfaces;

namespace HotelBookingApp.Controller
{
    public class AdministratorController : IAdministratorController
    {
        private readonly AdministratorService administratorService;

        public AdministratorController()
        {
            administratorService = new AdministratorService();
        }

        public List<Administrator> GetAll()
        {
            return administratorService.GetAll();
        }

        public Administrator Get(int id)
        {
            return administratorService.Get(id);
        }

        public Administrator Update(Administrator entity)
        {
            return administratorService.Update(entity);
        }

        public Administrator GetByEmailAndPassword(string email, string password)
        {
            return administratorService.GetByEmailAndPassword(email, password);
        }

        public void Save()
        {
            administratorService.Save();
        }
    }
}

