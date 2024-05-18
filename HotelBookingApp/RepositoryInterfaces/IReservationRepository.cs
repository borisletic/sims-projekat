using HotelBookingApp.Observer;
using HotelBookingApp.Model;


namespace HotelBookingApp.RepositoryInterfaces
{
    public interface IReservationRepository : IRepository<Reservation>, ISubject
    {
        void Save();

        void Create(Reservation reservation);
        
        Reservation Update(Reservation reservation);

        void Delete(Reservation reservation);

    }
}