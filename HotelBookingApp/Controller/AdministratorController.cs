using HotelBookingApp.Service;
using HotelBookingApp.Model;
using System.Collections.Generic;
using HotelBookingApp.ControllerInterfaces;

namespace HotelBookingApp.Controller
{
    // Controller responsible for handling administrator-related operations
    public class AdministratorController : IAdministratorController
    {
        private readonly AdministratorService administratorService;

        // Constructor to initialize the AdministratorService
        public AdministratorController()
        {
            administratorService = new AdministratorService();
        }

        // Get all administrators
        public List<Administrator> GetAll()
        {
            return administratorService.GetAll();
        }

        // Get administrator by id
        public Administrator Get(int id)
        {
            return administratorService.Get(id);
        }

        // Update administrator
        public Administrator Update(Administrator entity)
        {
            return administratorService.Update(entity);
        }

        // Get administrator by email and password (for login)
        public Administrator GetByEmailAndPassword(string email, string password)
        {
            return administratorService.GetByEmailAndPassword(email, password);
        }

        // Save changes made to administrators
        public void Save()
        {
            administratorService.Save();
        }
    }
}


