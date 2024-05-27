using HotelBookingApp.ControllerInterfaces;
using HotelBookingApp.Model;
using HotelBookingApp.Service;
using System.Collections.Generic;

namespace HotelBookingApp.Controller
{
    class ApartmentController: IApartmentController
    {
        private ApartmentService apartmentService;

        public ApartmentController()
        {
            apartmentService = new ApartmentService();
        }

        
        public void BindHotel()
        {
            apartmentService.BindHotel();
        }

        
        public List<Apartment> GetAll()
        {
            return apartmentService.GetAll();
        }

        
        public Apartment Get(int id)
        {
            return apartmentService.Get(id);
        }

        
        public void Create(Apartment entity)
        {
            apartmentService.Create(entity);
        }

        
        public void Delete(Apartment entity)
        {
            apartmentService.Delete(entity);
        }

        
        public Apartment Update(Apartment entity)
        {
            return apartmentService.Update(entity);
        }

        
        public void Save()
        {
            apartmentService.Save();
        }


    }
}
