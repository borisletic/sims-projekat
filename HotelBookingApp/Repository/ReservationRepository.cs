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

        // Singleton pattern: ensuring only one instance of ReservationRepository is created
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

            // Load reservations from CSV file
            reservations = serializer.FromCSV(filePath);

            observers = new List<IObserver>();
        }

        // Creates a new reservation entity in the repository
        public void Create(Reservation entity)
        {
            entity.Id = NextId(); // Generate ID for the new reservation

            reservations.Add(entity); // Add the new reservation to the list
            Save(); // Save changes to file

            NotifyObservers(); // Notify observers of the change
        }

        // Deletes a reservation entity from the repository
        public void Delete(Reservation entity)
        {
            entity.Deleted = true; // Mark the reservation as deleted
            Save(); // Save changes to file

            NotifyObservers(); // Notify observers of the change
        }

        // Retrieves all non-deleted reservations from the repository
        public List<Reservation> GetAll()
        {
            return reservations.FindAll(r => !r.Deleted);
        }

        // Retrieves a reservation by its ID
        public Reservation Get(int id)
        {
            return reservations.Find(r => r.Id == id && !r.Deleted);
        }

        // Generates the next available ID for a new reservation entity
        public int NextId()
        {
            if (reservations.Count == 0)
                return 0;

            int nextId = reservations[reservations.Count - 1].Id + 1;

            // Ensure the generated ID is unique among existing reservations
            foreach (Reservation reservation in reservations)
            {
                if (nextId == reservation.Id)
                {
                    nextId++;
                }
            }

            return nextId;
        }

        // Notifies observers of changes to reservations
        public void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update();
            }
        }

        // Updates an existing reservation entity in the repository
        public Reservation Update(Reservation entity)
        {
            var oldEntity = Get(entity.Id);

            if (oldEntity == null)
            {
                return null;
            }

            oldEntity = entity; // Update existing reservation entity
            Save(); // Save changes to file

            NotifyObservers(); // Notify observers of the change

            return oldEntity;
        }

        // Subscribes an observer to receive notifications
        public void Subscribe(IObserver observer)
        {
            observers.Add(observer);
        }

        // Unsubscribes an observer from receiving notifications
        public void Unsubscribe(IObserver observer)
        {
            observers.Remove(observer);
        }

        // Saves the current state of the repository to the file
        public void Save()
        {
            serializer.ToCSV(filePath, reservations);
        }
    }
}
