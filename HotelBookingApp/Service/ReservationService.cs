using HotelBookingApp.Model;
using HotelBookingApp.Model.Enums;
using HotelBookingApp.Observer;
using HotelBookingApp.Repository;
using HotelBookingApp.RepositoryInterfaces;
using HotelBookingApp.ServiceInterfaces;
using System.Collections.Generic;


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

        public void BindGuest()
        {
            foreach (var reservation in reservationRepository.GetAll())
            {
                reservation.Guest = guestRepository.Get(reservation.GuestId);
            }
        }

        public void BindApartment()
        {
            foreach(var reservation in reservationRepository.GetAll())
            {
                reservation.Apartment = apartmentRepository.Get(reservation.ApartmentId);
            }
        }

        public void BindOwner()
        {
            foreach(var reservation in reservationRepository.GetAll())
            {
                reservation.Owner = ownerRepository.Get(reservation.OwnerId);
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
