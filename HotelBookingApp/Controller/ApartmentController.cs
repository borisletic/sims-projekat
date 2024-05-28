using HotelBookingApp.ControllerInterfaces;
using HotelBookingApp.Model;
using HotelBookingApp.Service;
using System.Collections.Generic;

namespace HotelBookingApp.Controller
{
    // Controller responsible for handling apartment-related operations
    class ApartmentController : IApartmentController
    {
        private ApartmentService apartmentService;

        // Constructor to initialize the ApartmentService
        public ApartmentController()
        {
            apartmentService = new ApartmentService();
        }

        // Bind apartment to a hotel
        public void BindHotel()
        {
            apartmentService.BindHotel();
        }

        // Get all apartments
        public List<Apartment> GetAll()
        {
            return apartmentService.GetAll();
        }

        // Get apartment by id
        public Apartment Get(int id)
        {
            return apartmentService.Get(id);
        }

        // Create a new apartment
        public void Create(Apartment entity)
        {
            apartmentService.Create(entity);
        }

        // Delete an apartment
        public void Delete(Apartment entity)
        {
            apartmentService.Delete(entity);
        }

        // Update an apartment
        public Apartment Update(Apartment entity)
        {
            return apartmentService.Update(entity);
        }

        // Save changes made to apartments
        public void Save()
        {
            apartmentService.Save();
        }
    }
}
