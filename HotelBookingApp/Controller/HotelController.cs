using HotelBookingApp.ControllerInterfaces;
using HotelBookingApp.Model;
using HotelBookingApp.Service;
using System.Collections.Generic;

namespace HotelBookingApp.Controller
{
    // Controller responsible for handling hotel-related operations
    class HotelController : IHotelController
    {

        private HotelService hotelService;

        // Constructor to initialize the HotelService
        public HotelController()
        {
            hotelService = new HotelService();
        }

        // Bind hotel to an owner
        private void BindOwner()
        {
            hotelService.BindOwner();
        }

        // Get all hotels
        public List<Hotel> GetAll()
        {
            return hotelService.GetAll();
        }

        // Get hotel by id
        public Hotel Get(int id)
        {
            return hotelService.Get(id);
        }

        // Update hotel information
        public void Update(Hotel entity)
        {
            hotelService.Update(entity);
        }

        // Create a new hotel
        public void Create(Hotel hotel)
        {
            hotelService.Create(hotel);
        }

        // Get all apartments associated with a hotel
        public List<Apartment> GetAllApartments()
        {
            return hotelService.GetAllApartments();
        }

        // Delete a hotel
        public void Delete(Hotel hotel)
        {
            hotelService.Delete(hotel);
        }

        // Save changes made to hotels
        public void Save()
        {
            hotelService.Save();
        }
    }
}

