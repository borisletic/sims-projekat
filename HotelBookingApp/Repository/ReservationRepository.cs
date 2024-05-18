using HotelBookingApp.Model;
using HotelBookingApp.Observer;
using HotelBookingApp.RepositoryInterfaces;
using HotelBookingApp.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingApp.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private const string _filePath = "../../../Data/Reservation.csv";

        private readonly List<IObserver> _observers;
        private readonly Serializer<Reservation> _serializer;
        private List<Reservation> _reservations;
        private static IReservationRepository _instance = null;

        public static IReservationRepository GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ReservationRepository();
            }
            return _instance;
        }
        private ReservationRepository()
        {
            _reservations = new List<Reservation>();
            _serializer = new Serializer<Reservation>();
            _reservations = _serializer.FromCSV(_filePath);
            _observers = new List<IObserver>();
        }
           

        public void Create(Reservation entity)
        {
            entity.Id = NextId();
            _reservations.Add(entity);
            Save();
            NotifyObservers();
        }
        public void Delete(Reservation entity)
        {
            entity.Deleted = true;
            Save();
            NotifyObservers();
        }
        
        public List<Reservation> GetAll()
        {
            return _reservations.FindAll(r => r.Deleted == false);
        }

        public Reservation Get(int id)
        {
            return _reservations.Find(r => r.Id == id && r.Deleted == false);
        }

        public int NextId()
        {
            if (_reservations.Count == 0)
                return 0;
            int nextId = _reservations[_reservations.Count - 1].Id + 1;
            foreach (Reservation r in _reservations)
            {
                if (nextId == r.Id)
                {
                    nextId++;
                }
            }
            return nextId;
        }
        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }
               
        public Reservation Update(Reservation entity)
        {
            var oldEntity = Get(entity.Id);
            if (oldEntity == null)
            {
                return null;
            }
            oldEntity = entity;
            Save();
            NotifyObservers();
            return oldEntity;
        }

        public void Subscribe(IObserver observer)
        {
            _observers.Add(observer);
        }
        public void Unsubscribe(IObserver observer)
        {
            _observers.Remove(observer);
        }


        public void Save()
        {
            _serializer.ToCSV(_filePath, _reservations);
        }

    }
}
