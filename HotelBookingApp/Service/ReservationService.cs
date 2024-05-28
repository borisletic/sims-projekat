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

        // Constructor injection of repositories
        public ReservationService()
        {
            reservationRepository = ReservationRepository.GetInstance();
            guestRepository = GuestRepository.GetInstance();
            apartmentRepository = ApartmentRepository.GetInstance();
            ownerRepository = OwnerRepository.GetInstance();

            // Bind guest, apartment, and owner to reservations
            BindGuest();
            BindApartment();
            BindOwner();
        }

        // Binds guests to reservations
        public void BindGuest()
        {
            foreach (var reservation in reservationRepository.GetAll())
            {
                reservation.Guest = guestRepository.Get(reservation.GuestId);
            }
        }

        // Binds apartments to reservations
        public void BindApartment()
        {
            foreach (var reservation in reservationRepository.GetAll())
            {
                reservation.Apartment = apartmentRepository.Get(reservation.ApartmentId);
            }
        }

        // Binds owners to reservations
        public void BindOwner()
        {
            foreach (var reservation in reservationRepository.GetAll())
            {
                reservation.Owner = ownerRepository.Get(reservation.OwnerId);
            }
        }

        // Retrieves all reservations
        public List<Reservation> GetAll()
        {
            return reservationRepository.GetAll();
        }

        // Retrieves a reservation by ID
        public Reservation Get(int id)
        {
            return reservationRepository.Get(id);
        }

        // Creates a new reservation
        public void Create(Reservation reservation)
        {
            reservationRepository.Create(reservation);
        }

        // Subscribes an observer to the reservation repository
        public void Subscribe(IObserver observer)
        {
            reservationRepository.Subscribe(observer);
        }

        // Unsubscribes an observer from the reservation repository
        public void Unsubscribe(IObserver observer)
        {
            reservationRepository.Unsubscribe(observer);
        }

        // Updates an existing reservation
        public void Update(Reservation reservation)
        {
            reservationRepository.Update(reservation);
        }

        // Deletes a reservation
        public void Delete(Reservation reservation)
        {
            reservationRepository.Delete(reservation);
        }

        // Saves changes made to reservations
        public void Save()
        {
            reservationRepository.Save();
        }

    }
}

