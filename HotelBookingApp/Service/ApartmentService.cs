using HotelBookingApp.Model;
using HotelBookingApp.Observer;
using HotelBookingApp.Repository;
using HotelBookingApp.RepositoryInterfaces;
using HotelBookingApp.ServiceInterfaces;
using HotelBookingApp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingApp.Service
{
    public class ApartmentService : IApartmentService
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IHotelRepository _hotelRepository;
        public ApartmentService()
        {
            _apartmentRepository = ApartmentRepository.GetInstance();
            _hotelRepository = HotelRepository.GetInstance();
            BindHotel();
        }

        public void BindHotel()
        {
            foreach(var a in GetAll())
            {
                Hotel h = _hotelRepository.Get(a.HotelId);
                a.Hotel = h;
                h.Apartments.Add(a.Id, a);
            }
        }
        
        public List<Apartment> GetAll()
        {
            return _apartmentRepository.GetAll();
        }

        public Apartment Get(int id)
        {
            return _apartmentRepository.Get(id);
        }

        public void Create(Apartment entity)
        {
            _apartmentRepository.Create(entity);
        }
        public void Delete(Apartment entity)
        {
            _apartmentRepository.Delete(entity);
        }
        public Apartment Update(Apartment entity)
        {
            return _apartmentRepository.Update(entity);
        }
        
        void IService<Apartment>.Update(Apartment entity)
        {
            Update(entity);
        }

        public void Save()
        {
            _apartmentRepository.Save();
        }

    }
}
