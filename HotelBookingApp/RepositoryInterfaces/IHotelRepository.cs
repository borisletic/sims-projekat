using HotelBookingApp.Model;


namespace HotelBookingApp.RepositoryInterfaces
{
    public interface IHotelRepository : IRepository<Hotel>
    {
        void Save();

        Hotel Update(Hotel hotel);
        
        void Create(Hotel hotel);

        Hotel Delete(Hotel hotel);
        
    }
}