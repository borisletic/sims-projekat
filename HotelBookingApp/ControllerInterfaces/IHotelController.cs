using HotelBookingApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingApp.ControllerInterfaces
{
    public interface IHotelController
    {

        List<Hotel> GetAll();
        Hotel Get(int id);
        void Update(Hotel entity);
        void Create(Hotel hotel);
        List<Apartment> GetAllApartments();
        void Delete(Hotel hotel);
        void Save();

    }
}
