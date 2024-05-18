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
        private readonly IReservationRepository _reservationRepository;
        private readonly IGuestRepository _guestRepository;
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IOwnerRepository _ownerRepository;
        public ReservationService()
        {
            _reservationRepository = ReservationRepository.GetInstance();
            _guestRepository = GuestRepository.GetInstance();
            _apartmentRepository = ApartmentRepository.GetInstance();
            _ownerRepository = OwnerRepository.GetInstance();
            BindGuest();
            BindApartment();
            BindOwner();
        }

        private void BindApartment()
        {
            foreach(var r in _reservationRepository.GetAll())
            {
                r.Apartment = _apartmentRepository.Get(r.ApartmentId);
            }
        }

        private void BindOwner()
        {
            foreach(var r in _reservationRepository.GetAll())
            {
                r.Owner = _ownerRepository.Get(r.OwnerId);
            }
        }
        private void BindGuest()
        {
            foreach(var r in _reservationRepository.GetAll())
            {
                r.Guest = _guestRepository.Get(r.GuestId);
            }
        }
      
        public List<Reservation> GetAll()
        {
            return _reservationRepository.GetAll();
        }
        public Reservation Get(int id)
        {
            return _reservationRepository.Get(id);
        }
        public void Create(Reservation reservation)
        {
            _reservationRepository.Create(reservation);
        }
        public void Subscribe(IObserver observer)
        {
            _reservationRepository.Subscribe(observer);
        }
        public void Unsubscribe(IObserver observer)
        {
            _reservationRepository.Unsubscribe(observer);
        }
        public void Update(Reservation reservation)
        {
            _reservationRepository.Update(reservation);
        }
        public void Delete(Reservation reservation)
        {
            _reservationRepository.Delete(reservation);
        }            
        public void Save()
        {
            _reservationRepository.Save();
        }

    }

}
