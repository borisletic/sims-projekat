using HotelBookingApp.Model;

namespace HotelBookingApp.ServiceInterfaces
{
    public interface IApartmentService : IService<Apartment>
    {
        void Create(Apartment entity);
    }
}