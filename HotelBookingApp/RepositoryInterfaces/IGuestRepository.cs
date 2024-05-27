using HotelBookingApp.Model;


namespace HotelBookingApp.RepositoryInterfaces
{
    public interface IGuestRepository : IRepository<Guest>
    {
        void Save();

        Guest Update(Guest guest);
        
    }
}