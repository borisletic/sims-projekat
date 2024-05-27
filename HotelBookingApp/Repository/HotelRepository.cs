using HotelBookingApp.Model;
using HotelBookingApp.Observer;
using HotelBookingApp.RepositoryInterfaces;
using HotelBookingApp.Serializer;
using System.Collections.Generic;
using System.Linq;


namespace HotelBookingApp.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private const string filePath = "../../../Data/Hotel.csv";

        private readonly List<IObserver> observers;
        private readonly Serializer<Hotel> serializer;
        private List<Hotel> hotels;
        private static IHotelRepository instance = null;

        public static IHotelRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new HotelRepository();
            }
            return instance;
        }

        private HotelRepository()
        {
            serializer = new Serializer<Hotel>();
            hotels = new List<Hotel>();
            hotels = serializer.FromCSV(filePath);
            observers = new List<IObserver>();
        }
        public void Create(Hotel entity)
        {
            entity.Id = NextId();
            hotels.Add(entity);
            Save();
        }
        public Hotel Delete(Hotel entity)
        {
            hotels.Remove(entity);
            Save();
            return entity;
        }

        public Hotel Get(int id)
        {
            return hotels.Find(a => a.Id == id);
        }
        public List<Hotel> GetAll()
        {
            return hotels;
        }

        public int NextId()
        {
            if (hotels.Count == 0) return 0;
            int newId = hotels[hotels.Count() - 1].Id + 1;
            foreach (Hotel a in hotels)
            {
                if (newId == a.Id)
                {
                    newId++;
                }
            }
            return newId;
        }
        
        public Hotel Update(Hotel entity)
        {
            var oldEntity = Get(entity.Id);

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
            serializer.ToCSV(filePath, hotels);
        }

    }
}
