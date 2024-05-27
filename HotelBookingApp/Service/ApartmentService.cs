using HotelBookingApp.Model;
using HotelBookingApp.Repository;
using HotelBookingApp.RepositoryInterfaces;
using HotelBookingApp.ServiceInterfaces;
using System.Collections.Generic;


namespace HotelBookingApp.Service
{
    public class ApartmentService : IApartmentService
    {
        private readonly IApartmentRepository apartmentRepository;
        private readonly IHotelRepository hotelRepository;
        public ApartmentService()
        {
            apartmentRepository = ApartmentRepository.GetInstance();
            hotelRepository = HotelRepository.GetInstance();
            BindHotel();
        }

        public void BindHotel()
        {
            foreach(var a in GetAll())
            {
                Hotel h = hotelRepository.Get(a.HotelId);
                a.Hotel = h;
                h.Apartments.Add(a.Id, a);
            }
        }
        
        public List<Apartment> GetAll()
        {
            return apartmentRepository.GetAll();
        }

        public Apartment Get(int id)
        {
            return apartmentRepository.Get(id);
        }

        public void Create(Apartment entity)
        {
            apartmentRepository.Create(entity);
        }
        public void Delete(Apartment entity)
        {
            apartmentRepository.Delete(entity);
        }
        public Apartment Update(Apartment entity)
        {
            return apartmentRepository.Update(entity);
        }
        
        void IService<Apartment>.Update(Apartment entity)
        {
            Update(entity);
        }

        public void Save()
        {
            apartmentRepository.Save();
        }

    }
}
