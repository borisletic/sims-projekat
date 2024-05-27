using HotelBookingApp.ControllerInterfaces;
using HotelBookingApp.Model;
using HotelBookingApp.Service;
using System.Collections.Generic;

namespace HotelBookingApp.Controller
{
    class OwnerController : IOwnerController
    {

        private OwnerService ownerService;

        public OwnerController()
        {
            ownerService = new OwnerService();
        }

        
        public List<Owner> GetAll()
        {
            return ownerService.GetAll();
        }

        
        public Owner Get(int id)
        {
            return ownerService.Get(id);
        }

        
        public Owner Update(Owner entity)
        {
            return ownerService.Update(entity);
        }

        
        public Owner GetByEmailAndPassword(string email, string password)
        {
            return ownerService.GetByEmailAndPassword(email, password);
        }

        
        public void Create(Owner owner)
        {
            ownerService.Create(owner);
        }

        
        public void Save()
        {
            ownerService.Save();
        }



    }
}
