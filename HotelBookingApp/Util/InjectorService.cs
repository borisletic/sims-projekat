using HotelBookingApp.Repository;
using HotelBookingApp.RepositoryInterfaces;
using HotelBookingApp.Service;
using HotelBookingApp.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingApp.Util
{
    public class InjectorService
    {
        public static T CreateInstance<T>()
        {
            Type type = typeof(T);
            if (implementations.ContainsKey(type))
            {
                return (T)implementations[type];
            }
            throw new ArgumentException($"No implementation found for type {type}");
        }

        private static Dictionary<Type, object> implementations = new Dictionary<Type, object>
        {
            {typeof(IOwnerService), new OwnerService() },
            {typeof(IAdministratorService), new AdministratorService() },
            {typeof(IApartmentService), new ApartmentService() },
            {typeof(IGuestService), new GuestService() },
            {typeof(IHotelService), new HotelService() },
            {typeof(IReservationService), new ReservationService() }
        };       
    }
}

