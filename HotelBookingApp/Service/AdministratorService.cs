using HotelBookingApp.Model;
using HotelBookingApp.Repository;
using HotelBookingApp.RepositoryInterfaces;
using HotelBookingApp.ServiceInterfaces;
using System.Collections.Generic;


namespace HotelBookingApp.Service
{
    public class AdministratorService : IAdministratorService
    {
        private readonly IAdministratorRepository administratorRepository;

        // Constructor injection of the administrator repository
        public AdministratorService()
        {
            administratorRepository = AdministratorRepository.GetInstance();
        }

        // Retrieves all administrators
        public List<Administrator> GetAll()
        {
            return administratorRepository.GetAll();
        }

        // Retrieves an administrator by ID
        public Administrator Get(int id)
        {
            return administratorRepository.Get(id);
        }

        // Updates an existing administrator
        public Administrator Update(Administrator entity)
        {
            return administratorRepository.Update(entity);
        }

        // Retrieves an administrator by email and password
        public Administrator GetByEmailAndPassword(string email, string password)
        {
            return GetAll().Find(o => o.Email.Equals(email) && o.Password.Equals(password));
        }

        // Explicitly implemented Update method from IService interface
        void IService<Administrator>.Update(Administrator entity)
        {
            Update(entity);
        }

        // Saves changes made to administrators
        public void Save()
        {
            administratorRepository.Save();
        }
    }
}

