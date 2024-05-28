using HotelBookingApp.Model;
using HotelBookingApp.Repository;
using HotelBookingApp.RepositoryInterfaces;
using HotelBookingApp.ServiceInterfaces;
using System;
using System.Collections.Generic;


namespace HotelBookingApp.Service
{
    public class ApartmentService : IApartmentService
    {
        private readonly IApartmentRepository apartmentRepository;
        private readonly IHotelRepository hotelRepository;

        // Constructor injection of the apartment and hotel repositories
        public ApartmentService()
        {
            apartmentRepository = ApartmentRepository.GetInstance();
            hotelRepository = HotelRepository.GetInstance();

            // Bind each apartment to its corresponding hotel
            BindHotel();
        }

        // Binds each apartment to its corresponding hotel
        public void BindHotel()
        {
            foreach (var a in GetAll())
            {
                Hotel hotel = hotelRepository.Get(a.HotelId);
                a.Hotel = hotel;

                // Check if the key already exists before adding
                if (!hotel.Apartments.ContainsKey(a.Id))
                {
                    hotel.Apartments.Add(a.Id, a);
                }
                else
                {
                    // Handle the case where the key already exists
                    // For example, log a warning or update the existing value
                    Console.WriteLine($"Duplicate key detected: {a.Id}");
                    // Optionally update existing entry
                    // hotel.Apartments[a.Id] = a;
                }
            }
        }

        // Retrieves all apartments
        public List<Apartment> GetAll()
        {
            return apartmentRepository.GetAll();
        }

        // Retrieves an apartment by ID
        public Apartment Get(int id)
        {
            return apartmentRepository.Get(id);
        }

        // Creates a new apartment
        public void Create(Apartment entity)
        {
            apartmentRepository.Create(entity);
        }

        // Deletes an apartment
        public void Delete(Apartment entity)
        {
            apartmentRepository.Delete(entity);
        }

        // Updates an existing apartment
        public Apartment Update(Apartment entity)
        {
            return apartmentRepository.Update(entity);
        }

        // Explicitly implemented Update method from IService interface
        void IService<Apartment>.Update(Apartment entity)
        {
            Update(entity);
        }

        // Saves changes made to apartments
        public void Save()
        {
            apartmentRepository.Save();
        }

    }
}

