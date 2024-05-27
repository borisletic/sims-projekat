using HotelBookingApp.Model;
using HotelBookingApp.Observer;
using HotelBookingApp.RepositoryInterfaces;
using HotelBookingApp.Serializer;
using System.Collections.Generic;


namespace HotelBookingApp.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private const string filePath = "../../../Data/Reservation.csv";

        private readonly List<IObserver> observers;
        private readonly Serializer<Reservation> serializer;

        private List<Reservation> reservations;

        private static IReservationRepository instance = null;

        public static IReservationRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new ReservationRepository();
            }

            return instance;
        }
        private ReservationRepository()
        {         
            serializer = new Serializer<Reservation>();

            reservations = new List<Reservation>();
            reservations = serializer.FromCSV(filePath);

            observers = new List<IObserver>();
        }
           

        public void Create(Reservation entity)
        {
            entity.Id = NextId();

            reservations.Add(entity);
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
            return reservations.FindAll(r => r.Deleted == false);
        }

        public Reservation Get(int id)
        {
            return reservations.Find(r => r.Id == id && r.Deleted == false);
        }

        public int NextId()
        {
            if (reservations.Count == 0)
                return 0;

            int nextId = reservations[reservations.Count - 1].Id + 1;

            foreach (Reservation reservation in reservations)
            {
                if (nextId == reservation.Id)
                {
                    nextId++;
                }
            }

            return nextId;
        }
        public void NotifyObservers()
        {
            foreach (var observer in observers)
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
            observers.Add(observer);
        }
        public void Unsubscribe(IObserver observer)
        {
            observers.Remove(observer);
        }


        public void Save()
        {
            serializer.ToCSV(filePath, reservations);
        }

    }
}
