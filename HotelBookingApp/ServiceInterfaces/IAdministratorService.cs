using HotelBookingApp.Model;

namespace HotelBookingApp.ServiceInterfaces
{
    public interface IAdministratorService : IService<Administrator>
    {
        Administrator GetByEmailAndPassword(string email, string password);
    }
}