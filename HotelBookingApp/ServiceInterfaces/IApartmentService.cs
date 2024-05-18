using HotelBookingApp.Model;
using HotelBookingApp.Observer;

namespace HotelBookingApp.ServiceInterfaces
{
    public interface IApartmentService : IService<Apartment>
    {
        void Create(Apartment entity);
    }
}