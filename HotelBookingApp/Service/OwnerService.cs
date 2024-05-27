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
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository ownerRepository;

        public OwnerService()
        {
            ownerRepository = OwnerRepository.GetInstance();
        }
        
        
        public List<Owner> GetAll()
        {
            return ownerRepository.GetAll();
        }

        public Owner Get(int id)
        {
            return ownerRepository.Get(id);
        }

        public Owner Update(Owner entity)
        {
            return ownerRepository.Update(entity);
        }

        public Owner GetByEmailAndPassword(string email, string password)
        {
            return GetAll().Find(o => o.Email.Equals(email) && o.Password.Equals(password));
        }

        void IService<Owner>.Update(Owner entity)
        {
            ownerRepository.Update(entity);
        }

        public void Create(Owner owner)
        {
            ownerRepository.Create(owner);
        }

        public void Save()
        {
            ownerRepository.Save();
        }
    }
}

