using HotelBookingApp.ControllerInterfaces;
using HotelBookingApp.Model;
using HotelBookingApp.Service;
using System.Collections.Generic;

namespace HotelBookingApp.Controller
{
    // Controller responsible for handling owner-related operations
    class OwnerController : IOwnerController
    {

        private OwnerService ownerService;

        // Constructor to initialize the OwnerService
        public OwnerController()
        {
            ownerService = new OwnerService();
        }

        // Get all owners
        public List<Owner> GetAll()
        {
            return ownerService.GetAll();
        }

        // Get owner by id
        public Owner Get(int id)
        {
            return ownerService.Get(id);
        }

        // Update owner information
        public Owner Update(Owner entity)
        {
            return ownerService.Update(entity);
        }

        // Get owner by email and password (for login)
        public Owner GetByEmailAndPassword(string email, string password)
        {
            return ownerService.GetByEmailAndPassword(email, password);
        }

        // Create a new owner
        public void Create(Owner owner)
        {
            ownerService.Create(owner);
        }

        // Save changes made to owners
        public void Save()
        {
            ownerService.Save();
        }
    }
}

