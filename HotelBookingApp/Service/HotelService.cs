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

        // Constructor injection of the hotel and owner repositories
        public HotelService()
        {
            hotelRepository = HotelRepository.GetInstance();
            ownerRepository = OwnerRepository.GetInstance();

            BindOwner();
        }

        // Binds owners to hotels
        public void BindOwner()
        {
            foreach (var hotel in GetAll())
            {
                // Get the owner associated with each hotel
                hotel.Owner = ownerRepository.Get(hotel.OwnerId);
            }
        }

        // Retrieves all hotels
        public List<Hotel> GetAll()
        {
            return hotelRepository.GetAll();
        }

        // Retrieves a hotel by ID
        public Hotel Get(int id)
        {
            return hotelRepository.Get(id);
        }

        // Updates a hotel's information
        public void Update(Hotel entity)
        {
            hotelRepository.Update(entity);
        }

        // Creates a new hotel
        public void Create(Hotel hotel)
        {
            hotelRepository.Create(hotel);
        }

        // Retrieves all apartments across all hotels
        public List<Apartment> GetAllApartments()
        {
            var apartments = new List<Apartment>();

            foreach (var hotel in GetAll())
            {
                // Add all apartments of each hotel to the list
                apartments.AddRange(hotel.Apartments.Values);
            }

            return apartments;
        }

        // Deletes a hotel
        public void Delete(Hotel hotel)
        {
            hotelRepository.Delete(hotel);
        }

        // Saves changes made to hotels
        public void Save()
        {
            hotelRepository.Save();
        }
    }
}

