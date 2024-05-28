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

        // Singleton pattern: ensuring only one instance of GuestRepository is created
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

            // Load guests from CSV file
            guests = serializer.FromCSV(filePath);

            observers = new List<IObserver>();
        }

        // Retrieves all guests from the repository
        public List<Guest> GetAll()
        {
            return guests;
        }

        // Retrieves a guest by ID
        public Guest Get(int id)
        {
            return guests.Find(o => o.Id == id);
        }

        // Updates an existing guest in the repository
        public Guest Update(Guest entity)
        {
            Guest oldEntity = Get(entity.Id);

            if (oldEntity == null)
            {
                return null; // Guest not found
            }

            oldEntity = entity; // Update existing guest
            Save(); // Save changes to file

            return oldEntity;
        }

        // Saves the current state of the repository to the file
        public void Save()
        {
            serializer.ToCSV(filePath, guests);
        }
    }
}
