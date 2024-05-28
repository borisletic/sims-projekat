using HotelBookingApp.Model;
using HotelBookingApp.Repository;
using HotelBookingApp.RepositoryInterfaces;
using HotelBookingApp.ServiceInterfaces;
using System.Collections.Generic;


namespace HotelBookingApp.Service
{
    public class GuestService : IGuestService
    {
        private readonly IGuestRepository guestRepository;

        // Constructor injection of the guest repository
        public GuestService()
        {
            guestRepository = GuestRepository.GetInstance();
        }

        // Retrieves all guests
        public List<Guest> GetAll()
        {
            return guestRepository.GetAll();
        }

        // Retrieves a guest by ID
        public Guest Get(int id)
        {
            return guestRepository.Get(id);
        }

        // Updates a guest's information
        public void Update(Guest entity)
        {
            guestRepository.Update(entity);
        }

        // Retrieves a guest by email and password
        public Guest GetByEmailAndPassword(string email, string password)
        {
            return GetAll().Find(o => o.Email.Equals(email) && o.Password.Equals(password));
        }

        // Explicitly implemented Update method from IService interface
        void IService<Guest>.Update(Guest entity)
        {
            guestRepository.Update(entity);
        }

        // Saves changes made to guests
        public void Save()
        {
            guestRepository.Save();
        }
    }
}

