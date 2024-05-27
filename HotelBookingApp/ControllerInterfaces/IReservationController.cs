using HotelBookingApp.Model;
using HotelBookingApp.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
