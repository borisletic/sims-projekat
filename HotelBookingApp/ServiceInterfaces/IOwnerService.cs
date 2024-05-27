using HotelBookingApp.Model;


namespace HotelBookingApp.ServiceInterfaces
{
    public interface IOwnerService : IService<Owner>
    {
        void Create(Owner owner);
        Owner GetByEmailAndPassword(string email, string password);      
    }
}