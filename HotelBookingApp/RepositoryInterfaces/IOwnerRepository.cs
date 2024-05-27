using HotelBookingApp.Model;


namespace HotelBookingApp.RepositoryInterfaces
{
    public interface IOwnerRepository : IRepository<Owner>
    {
        Owner Update(Owner owner);
        void Create(Owner owner);
        void Save();
    }
}