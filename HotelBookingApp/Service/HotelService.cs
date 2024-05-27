using HotelBookingApp.Model;
using HotelBookingApp.Repository;
using HotelBookingApp.RepositoryInterfaces;
using HotelBookingApp.ServiceInterfaces;
using System.Collections.Generic;


namespace HotelBookingApp.Service
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository hotelRepository;
        private readonly IOwnerRepository ownerRepository;

        public HotelService()
        {
            hotelRepository = HotelRepository.GetInstance();
            ownerRepository = OwnerRepository.GetInstance();

            BindOwner();
        }

        public void BindOwner()
        {
            foreach(var a in GetAll())
            {
                a.Owner = ownerRepository.Get(a.OwnerId);
            }
        }

        public List<Hotel> GetAll()
        {
            return hotelRepository.GetAll();
        }

        public Hotel Get(int id)
        {
            return hotelRepository.Get(id);
        }

        public void Update(Hotel entity)
        {
            hotelRepository.Update(entity);
        }
        
        public void Create(Hotel hotel)
        {
            hotelRepository.Create(hotel);
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
            hotelRepository.Delete(hotel);
        }

        public void Save()
        {
            hotelRepository.Save();
        }
    }
}
