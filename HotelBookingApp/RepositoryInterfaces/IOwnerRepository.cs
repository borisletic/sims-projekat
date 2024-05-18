using System.Collections.Generic;
using HotelBookingApp.Model;


namespace HotelBookingApp.RepositoryInterfaces
{
    public interface IOwnerRepository : IRepository<Owner>
    {
        Owner Update(Owner entity);
        void Create(Owner owner);
        void Save();
    }
}