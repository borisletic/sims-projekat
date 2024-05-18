using HotelBookingApp.Model;

namespace HotelBookingApp.ServiceInterfaces
{
    public interface IGuestService : IService<Guest>
    {
        Guest GetByEmailAndPassword(string email, string password);
    }
}