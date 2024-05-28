using HotelBookingApp.Model;
using HotelBookingApp.Repository;
using HotelBookingApp.RepositoryInterfaces;
using HotelBookingApp.ServiceInterfaces;
using System.Collections.Generic;


namespace HotelBookingApp.Service
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository ownerRepository;

        // Constructor injection of the owner repository
        public OwnerService()
        {
            ownerRepository = OwnerRepository.GetInstance();
        }

        // Retrieves all owners
        public List<Owner> GetAll()
        {
            return ownerRepository.GetAll();
        }

        // Retrieves an owner by ID
        public Owner Get(int id)
        {
            return ownerRepository.Get(id);
        }

        // Updates an owner's information
        public Owner Update(Owner entity)
        {
            return ownerRepository.Update(entity);
        }

        // Retrieves an owner by email and password
        public Owner GetByEmailAndPassword(string email, string password)
        {
            return GetAll().Find(o => o.Email.Equals(email) && o.Password.Equals(password));
        }

        // Explicit implementation of the Update method from the IService interface
        void IService<Owner>.Update(Owner entity)
        {
            ownerRepository.Update(entity);
        }

        // Creates a new owner
        public void Create(Owner owner)
        {
            ownerRepository.Create(owner);
        }

        // Saves changes made to owners
        public void Save()
        {
            ownerRepository.Save();
        }
    }
}


