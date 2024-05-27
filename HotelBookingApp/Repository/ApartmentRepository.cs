using HotelBookingApp.Model;
using HotelBookingApp.Observer;
using HotelBookingApp.RepositoryInterfaces;
using HotelBookingApp.Serializer;
using System.Collections.Generic;
using System.Linq;


namespace HotelBookingApp.Repository
{
    public class ApartmentRepository : IApartmentRepository
    {
        private const string filePath = "../../../Data/Apartment.csv";

        private readonly Serializer<Apartment> serializer;
        private readonly List<IObserver> observers;

        private List<Apartment> apartments;

        private static IApartmentRepository instance = null;

        private ApartmentRepository()
        {
            serializer = new Serializer<Apartment>();

            apartments = new List<Apartment>();
            apartments = serializer.FromCSV(filePath);

            observers = new List<IObserver>();

        }

        public static IApartmentRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new ApartmentRepository();
            }

            return instance;
        }

        
        public Apartment Delete(Apartment entity)
        {
            apartments.Remove(entity);
            Save();

            return entity;
        }

        public Apartment Create(Apartment entity)
        {
            entity.Id = NextId();

            apartments.Add(entity);
            Save();

            return entity;
        }
        public List<Apartment> GetAll()
        {
            return apartments;
        }

        public Apartment Get(int id)
        {
            return apartments.Find(a => a.Id == id);
        }
       

        public int NextId()
        {
            if (apartments.Count == 0) return 0;

            int newId = apartments[apartments.Count() - 1].Id + 1;

            foreach (Apartment apartment in apartments)
            {
                if (newId == apartment.Id)
                {
                    newId++;
                }
            }

            return newId;
        }
        
        public Apartment Update(Apartment entity)
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

        public void Unsubscribe(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void Subscribe(IObserver observer)
        {
            observers.Add(observer);
        }


        void IApartmentRepository.Create(Apartment entity)
        {
            entity.Id = NextId();

            apartments.Add(entity);
            Save();

            NotifyObservers();
        }

        void IApartmentRepository.Delete(Apartment entity)
        {
            var apartment = Get(entity.Id);

            if (apartment != null)
            {
                apartments.Remove(apartment);
                Save();

                NotifyObservers();
            }
        }


        public void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update();
            }
        }

        public void Save()
        {
            serializer.ToCSV(filePath, apartments);
        }

    }
}
