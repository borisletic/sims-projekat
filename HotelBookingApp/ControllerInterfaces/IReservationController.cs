using HotelBookingApp.Model;
using HotelBookingApp.Observer;
using System.Collections.Generic;


namespace HotelBookingApp.ControllerInterfaces
{
    public interface IReservationController
    {

        void BindApartment();
        void BindOwner();
        void BindGuest();
        List<Reservation> GetAll();
        Reservation Get(int id);
        void Create(Reservation reservation);
        void Subscribe(IObserver observer);
        void Unsubscribe(IObserver observer);
        void Update(Reservation reservation);
        void Delete(Reservation reservation);
        void Save();

    }
}
