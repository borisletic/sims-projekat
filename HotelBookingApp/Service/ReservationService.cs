using HotelBookingApp.Model;
using HotelBookingApp.Model.Enums;
using HotelBookingApp.Observer;
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
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository reservationRepository;
        private readonly IGuestRepository guestRepository;
        private readonly IApartmentRepository apartmentRepository;
        private readonly IOwnerRepository ownerRepository;
        public ReservationService()
        {
            reservationRepository = ReservationRepository.GetInstance();
            guestRepository = GuestRepository.GetInstance();
            apartmentRepository = ApartmentRepository.GetInstance();
            ownerRepository = OwnerRepository.GetInstance();
            BindGuest();
            BindApartment();
            BindOwner();
        }

        public void BindApartment()
        {
            foreach(var r in reservationRepository.GetAll())
            {
                r.Apartment = apartmentRepository.Get(r.ApartmentId);
            }
        }

        public void BindOwner()
        {
            foreach(var r in reservationRepository.GetAll())
            {
                r.Owner = ownerRepository.Get(r.OwnerId);
            }
        }
        public void BindGuest()
        {
            foreach(var r in reservationRepository.GetAll())
            {
                r.Guest = guestRepository.Get(r.GuestId);
            }
        }
      
        public List<Reservation> GetAll()
        {
            return reservationRepository.GetAll();
        }
        public Reservation Get(int id)
        {
            return reservationRepository.Get(id);
        }
        public void Create(Reservation reservation)
        {
            reservationRepository.Create(reservation);
        }
        public void Subscribe(IObserver observer)
        {
            reservationRepository.Subscribe(observer);
        }
        public void Unsubscribe(IObserver observer)
        {
            reservationRepository.Unsubscribe(observer);
        }
        public void Update(Reservation reservation)
        {
            reservationRepository.Update(reservation);
        }
        public void Delete(Reservation reservation)
        {
            reservationRepository.Delete(reservation);
        }            
        public void Save()
        {
            reservationRepository.Save();
        }

    }

}
