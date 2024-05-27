using HotelBookingApp.ControllerInterfaces;
using HotelBookingApp.Model;
using HotelBookingApp.Observer;
using HotelBookingApp.Service;
using System.Collections.Generic;


namespace HotelBookingApp.Controller
{
    class ReservationController : IReservationController
    {

        private ReservationService reservationService;

        public ReservationController()
        {
            reservationService = new ReservationService();
        }

        
        public void BindApartment()
        {
            reservationService.BindApartment();
        }

        
        public void BindOwner()
        {
            reservationService.BindOwner();
        }

        
        public void BindGuest()
        {
            reservationService.BindGuest();
        }

        
        public List<Reservation> GetAll()
        {
            return reservationService.GetAll();
        }

        
        public Reservation Get(int id)
        {
            return reservationService.Get(id);
        }

        
        public void Create(Reservation reservation)
        {
            reservationService.Create(reservation);
        }

        
        public void Subscribe(IObserver observer)
        {
            reservationService.Subscribe(observer);
        }

        
        public void Unsubscribe(IObserver observer)
        {
            reservationService.Unsubscribe(observer);
        }

        
        public void Update(Reservation reservation)
        {
            reservationService.Update(reservation);
        }

        
        public void Delete(Reservation reservation)
        {
            reservationService.Delete(reservation);
        }

        
        public void Save()
        {
            reservationService.Save();
        }



    }
}
