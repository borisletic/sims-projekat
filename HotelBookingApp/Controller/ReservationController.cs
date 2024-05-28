using HotelBookingApp.ControllerInterfaces;
using HotelBookingApp.Model;
using HotelBookingApp.Observer;
using HotelBookingApp.Service;
using System.Collections.Generic;


namespace HotelBookingApp.Controller
{
    // Controller responsible for handling reservation-related operations
    class ReservationController : IReservationController
    {

        private ReservationService reservationService;

        // Constructor to initialize the ReservationService
        public ReservationController()
        {
            reservationService = new ReservationService();
        }

        // Bind reservation to an apartment
        public void BindApartment()
        {
            reservationService.BindApartment();
        }

        // Bind reservation to an owner
        public void BindOwner()
        {
            reservationService.BindOwner();
        }

        // Bind reservation to a guest
        public void BindGuest()
        {
            reservationService.BindGuest();
        }

        // Get all reservations
        public List<Reservation> GetAll()
        {
            return reservationService.GetAll();
        }

        // Get reservation by id
        public Reservation Get(int id)
        {
            return reservationService.Get(id);
        }

        // Create a new reservation
        public void Create(Reservation reservation)
        {
            reservationService.Create(reservation);
        }

        // Subscribe to updates on reservations
        public void Subscribe(IObserver observer)
        {
            reservationService.Subscribe(observer);
        }

        // Unsubscribe from updates on reservations
        public void Unsubscribe(IObserver observer)
        {
            reservationService.Unsubscribe(observer);
        }

        // Update reservation information
        public void Update(Reservation reservation)
        {
            reservationService.Update(reservation);
        }

        // Delete a reservation
        public void Delete(Reservation reservation)
        {
            reservationService.Delete(reservation);
        }

        // Save changes made to reservations
        public void Save()
        {
            reservationService.Save();
        }
    }
}

