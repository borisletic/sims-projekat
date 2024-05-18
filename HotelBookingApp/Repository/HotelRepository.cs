using HotelBookingApp.Model;
using HotelBookingApp.Observer;
using HotelBookingApp.RepositoryInterfaces;
using HotelBookingApp.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;


namespace HotelBookingApp.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private const string _filePath = "../../../Data/Hotel.csv";

        private readonly List<IObserver> _observers;
        private readonly Serializer<Hotel> _serializer;
        private List<Hotel> _hotels;
        private static IHotelRepository _instance = null;

        public static IHotelRepository GetInstance()
        {
            if (_instance == null)
            {
                _instance = new HotelRepository();
            }
            return _instance;
        }

        private HotelRepository()
        {
            _serializer = new Serializer<Hotel>();
            _hotels = new List<Hotel>();
            _hotels = _serializer.FromCSV(_filePath);
            _observers = new List<IObserver>();
        }
        public void Create(Hotel entity)
        {
            entity.Id = NextId();
            _hotels.Add(entity);
            Save();
        }
        public Hotel Delete(Hotel entity)
        {
            _hotels.Remove(entity);
            Save();
            return entity;
        }

        public Hotel Get(int id)
        {
            return _hotels.Find(a => a.Id == id);
        }
        public List<Hotel> GetAll()
        {
            return _hotels;
        }

        public int NextId()
        {
            if (_hotels.Count == 0) return 0;
            int newId = _hotels[_hotels.Count() - 1].Id + 1;
            foreach (Hotel a in _hotels)
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
            _serializer.ToCSV(_filePath, _hotels);
        }

    }
}
