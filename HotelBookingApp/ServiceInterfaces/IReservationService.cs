using HotelBookingApp.Observer;
using HotelBookingApp.Model;

namespace HotelBookingApp.ServiceInterfaces
{
    public interface IReservationService : IService<Reservation>
    {       
        void Subscribe(IObserver observer);
        void Unsubscribe(IObserver observer);
        void Create(Reservation entity);
        void Delete(Reservation entity);
    }
}