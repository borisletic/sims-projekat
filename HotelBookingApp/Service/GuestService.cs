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
    public class GuestService : IGuestService
    {
        private readonly IGuestRepository guestRepository;
        public GuestService()
        {
            guestRepository = GuestRepository.GetInstance();
        }
        
        public List<Guest> GetAll()
        {
            return guestRepository.GetAll();
        }

        public Guest Get(int id)
        {
            return guestRepository.Get(id);
        }

        public void Update(Guest entity)
        {
            guestRepository.Update(entity);
        }
        
        public Guest GetByEmailAndPassword(string email, string password)
        {
            return GetAll().Find(o => o.Email.Equals(email) && o.Password.Equals(password));
        }

        void IService<Guest>.Update(Guest entity)
        {
            guestRepository.Update(entity);
        }

        public void Save()
        {
            guestRepository.Save();
        }
    }
}
