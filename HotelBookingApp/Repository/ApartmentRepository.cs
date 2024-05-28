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

            // Load apartments from CSV file
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

        // Deletes an apartment from the repository
        public Apartment Delete(Apartment entity)
        {
            apartments.Remove(entity);
            Save(); // Save changes to file

            return entity;
        }

        // Creates a new apartment in the repository
        public Apartment Create(Apartment entity)
        {
            entity.Id = NextId(); // Assign a unique ID
            apartments.Add(entity);
            Save(); // Save changes to file

            return entity;
        }

        // Retrieves all apartments from the repository
        public List<Apartment> GetAll()
        {
            return apartments;
        }

        // Retrieves an apartment by ID
        public Apartment Get(int id)
        {
            return apartments.Find(a => a.Id == id);
        }

        // Generates the next available ID for a new apartment
        public int NextId()
        {
            if (apartments.Count == 0) return 0;

            int newId = apartments.Max(a => a.Id) + 1;

            return newId;
        }

        // Updates an existing apartment in the repository
        public Apartment Update(Apartment entity)
        {
            var oldEntity = Get(entity.Id);

            if (oldEntity == null)
            {
                return null; // Apartment not found
            }

            oldEntity = entity; // Update existing apartment
            Save(); // Save changes to file

            return oldEntity;
        }

        // Unsubscribes an observer from receiving updates
        public void Unsubscribe(IObserver observer)
        {
            observers.Remove(observer);
        }

        // Subscribes an observer to receive updates
        public void Subscribe(IObserver observer)
        {
            observers.Add(observer);
        }

        // Notifies all observers of changes
        public void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update();
            }
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


        // Saves the current state of the repository to the file
        public void Save()
        {
            serializer.ToCSV(filePath, apartments);
        }
    }
}

