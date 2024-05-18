using HotelBookingApp.Model;
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
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IOwnerRepository _ownerRepository;
        public HotelService()
        {
            _hotelRepository = HotelRepository.GetInstance();
            _ownerRepository = OwnerRepository.GetInstance();
            BindOwner();
        }

        private void BindOwner()
        {
            foreach(var r in GetAll())
            {
                r.Owner = _ownerRepository.Get(r.OwnerId);
            }
        }

        public List<Hotel> GetAll()
        {
            return _hotelRepository.GetAll();
        }

        public Hotel Get(int id)
        {
            return _hotelRepository.Get(id);
        }

        public void Update(Hotel entity)
        {
            _hotelRepository.Update(entity);
        }
        
        public void Create(Hotel hotel)
        {
            _hotelRepository.Create(hotel);
        }

        public List<Apartment> GetAllApartments()
        {
            var apartments = new List<Apartment>();
            foreach (var hotel in GetAll())
            {
                apartments.AddRange(hotel.Apartments.Values);
            }
            return apartments;
        }

        public void Delete(Hotel hotel)
        {
            _hotelRepository.Delete(hotel);
        }

        public void Save()
        {
            _hotelRepository.Save();
        }
    }
}
