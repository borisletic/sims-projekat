using HotelBookingApp.Observer;
using HotelBookingApp.Model;
using System;
using System.Collections.Generic;

namespace HotelBookingApp.ServiceInterfaces
{
    public interface IHotelService
    {       
        List<Apartment> GetAllApartments();
        List<Hotel> GetAll();
        void Update(Hotel hotel);
        void Delete(Hotel hotel);
        void Create(Hotel hotel);
    }
}