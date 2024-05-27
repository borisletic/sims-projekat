using HotelBookingApp.Model;
using HotelBookingApp.Observer;

namespace HotelBookingApp.RepositoryInterfaces
{
    public interface IApartmentRepository : IRepository<Apartment>, ISubject
    {
        void Delete(Apartment apartment);

        void Create(Apartment apartment);

        void Save();

        Apartment Update(Apartment apartment);
    }
}