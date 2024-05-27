using System.Collections.Generic;


namespace HotelBookingApp.RepositoryInterfaces
{
    public interface IRepository<T>
    {
        public List<T> GetAll();

        public T Get(int id);
    }
}