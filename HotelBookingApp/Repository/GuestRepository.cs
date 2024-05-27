using HotelBookingApp.Model;
using HotelBookingApp.Observer;
using HotelBookingApp.RepositoryInterfaces;
using HotelBookingApp.Serializer;
using System.Collections.Generic;


namespace HotelBookingApp.Repository
{
    public class GuestRepository : IGuestRepository
    {
        private const string filePath = "../../../Data/Guest.csv";

        private readonly Serializer<Guest> serializer;
        private List<IObserver> observers;
        private List<Guest> guests;
        private static IGuestRepository instance = null;

        public static IGuestRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new GuestRepository();
            }
            return instance;
        }

        private GuestRepository()
        {
            serializer = new Serializer<Guest>();
            guests = new List<Guest>();
            guests = serializer.FromCSV(filePath);
            observers = new List<IObserver>();
        }

        public List<Guest> GetAll()
        {
            return guests;
        }

        public Guest Get(int id)
        {
            return guests.Find(o => o.Id == id);
        }

        
        public Guest Update(Guest entity)
        {
            Guest oldEntity = Get(entity.Id);
            if (oldEntity == null)
            {
                return null;
            }
            oldEntity = entity;
            Save();
            return oldEntity;
        }

        public void Save()
        {
            serializer.ToCSV(filePath, guests);
        }

    }
}
