using System.Collections.Generic;

namespace HotelBookingApp.ServiceInterfaces
{
    public interface IService<T>
    {
        List<T> GetAll();
        T Get(int id);
        void Update(T entity);
        void Save();
    }
}