using HotelBookingApp.ControllerInterfaces;
using HotelBookingApp.Model;
using HotelBookingApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingApp.Controller
{
    class HotelController : IHotelController
    {

        private HotelService hotelService;

        public HotelController()
        {
            hotelService = new HotelService();
        }

        
        private void BindOwner()
        {
            hotelService.BindOwner();
        }

        
        public List<Hotel> GetAll()
        {
            return hotelService.GetAll();
        }

        
        public Hotel Get(int id)
        {
            return hotelService.Get(id);
        }

        
        public void Update(Hotel entity)
        {
            hotelService.Update(entity);
        }

        
        public void Create(Hotel hotel)
        {
            hotelService.Create(hotel);
        }

        
        public List<Apartment> GetAllApartments()
        {
            return hotelService.GetAllApartments();
        }

        
        public void Delete(Hotel hotel)
        {
            hotelService.Delete(hotel);
        }

        
        public void Save()
        {
            hotelService.Save();
        }


    }
}
