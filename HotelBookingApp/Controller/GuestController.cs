using HotelBookingApp.ControllerInterfaces;
using HotelBookingApp.Model;
using HotelBookingApp.Service;
using System.Collections.Generic;

namespace HotelBookingApp.Controller
{
    class GuestController: IGuestController
    {

        private GuestService guestService;

        public GuestController()
        {
            guestService = new GuestService();
        }

        
        public List<Guest> GetAll()
        {
            return guestService.GetAll();
        }

        
        public Guest Get(int id)
        {
            return guestService.Get(id);
        }

        
        public void Update(Guest entity)
        {
            guestService.Update(entity);
        }

        
        public Guest GetByEmailAndPassword(string email, string password)
        {
            return guestService.GetByEmailAndPassword(email, password);
        }

        
        public void Save()
        {
            guestService.Save();
        }


    }
}
