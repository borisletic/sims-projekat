using HotelBookingApp.ControllerInterfaces;
using HotelBookingApp.Model;
using HotelBookingApp.Service;
using System.Collections.Generic;

namespace HotelBookingApp.Controller
{
    // Controller responsible for handling guest-related operations
    class GuestController : IGuestController
    {
        private GuestService guestService;

        // Constructor to initialize the GuestService
        public GuestController()
        {
            guestService = new GuestService();
        }

        // Get all guests
        public List<Guest> GetAll()
        {
            return guestService.GetAll();
        }

        // Get guest by id
        public Guest Get(int id)
        {
            return guestService.Get(id);
        }

        // Update guest information
        public void Update(Guest entity)
        {
            guestService.Update(entity);
        }

        // Get guest by email and password (for login)
        public Guest GetByEmailAndPassword(string email, string password)
        {
            return guestService.GetByEmailAndPassword(email, password);
        }

        // Save changes made to guests
        public void Save()
        {
            guestService.Save();
        }
    }
}
