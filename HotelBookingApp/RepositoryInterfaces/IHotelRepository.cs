using HotelBookingApp.Observer;
using HotelBookingApp.Model;


namespace HotelBookingApp.RepositoryInterfaces
{
    public interface IHotelRepository : IRepository<Hotel>
    {
        void Save();

        Hotel Update(Hotel entity);
        
        void Create(Hotel entity);

        Hotel Delete(Hotel entity);
        
    }
}