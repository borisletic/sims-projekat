using HotelBookingApp.Model;
using HotelBookingApp.Observer;

namespace HotelBookingApp.RepositoryInterfaces
{
    public interface IApartmentRepository : IRepository<Apartment>, ISubject
    {
        void Delete(Apartment entity);

        void Create(Apartment entity);

        void Save();

        Apartment Update(Apartment entity);
    }
}