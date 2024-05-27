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
    public class AdministratorService : IAdministratorService
    {
        private readonly IAdministratorRepository administratorRepository;
        public AdministratorService()
        {
            administratorRepository = AdministratorRepository.GetInstance();
        }
        
        public List<Administrator> GetAll()
        {
            return administratorRepository.GetAll();
        }

        public Administrator Get(int id)
        {
            return administratorRepository.Get(id);
        }

        public Administrator Update(Administrator entity)
        {
            return administratorRepository.Update(entity);
        }
        
        public Administrator GetByEmailAndPassword(string email, string password)
        {
            return GetAll().Find(o => o.Email.Equals(email) && o.Password.Equals(password));
        }
        void IService<Administrator>.Update(Administrator entity)
        {
            Update(entity);
        }
        public void Save()
        {
            administratorRepository.Save();
        }
    }
}
