using HotelBookingApp.Model;
using HotelBookingApp.Observer;
using HotelBookingApp.RepositoryInterfaces;
using HotelBookingApp.Serializer;
using System.Collections.Generic;


namespace HotelBookingApp.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private const string filePath = "../../../Data/Hotel.csv";

        private readonly List<IObserver> observers;
        private readonly Serializer<Hotel> serializer;

        private List<Hotel> hotels;

        private static IHotelRepository instance = null;

        // Singleton pattern: ensuring only one instance of HotelRepository is created
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

            // Load hotels from CSV file
            hotels = serializer.FromCSV(filePath);

            observers = new List<IObserver>();
        }

        // Creates a new hotel entity in the repository
        public void Create(Hotel entity)
        {
            entity.Id = NextId(); // Generate ID for the new hotel

            hotels.Add(entity); // Add the new hotel to the list
            Save(); // Save changes to file
        }

        // Deletes a hotel entity from the repository
        public Hotel Delete(Hotel entity)
        {
            hotels.Remove(entity); // Remove the hotel from the list
            Save(); // Save changes to file

            return entity;
        }

        // Retrieves a hotel entity by its ID
        public Hotel Get(int id)
        {
            return hotels.Find(a => a.Id == id);
        }

        // Retrieves all hotels from the repository
        public List<Hotel> GetAll()
        {
            return hotels;
        }

        // Generates the next available ID for a new hotel entity
        public int NextId()
        {
            if (hotels.Count == 0) return 0; // If no hotels exist, return 0 as the first ID

            int newId = hotels[hotels.Count - 1].Id + 1; // Increment the ID of the last hotel

            // Ensure the generated ID is unique among existing hotels
            foreach (Hotel hotel in hotels)
            {
                if (newId == hotel.Id)
                {
                    newId++;
                }
            }

            return newId;
        }

        // Updates an existing hotel entity in the repository
        public Hotel Update(Hotel entity)
        {
            var oldEntity = Get(entity.Id); // Find the existing hotel entity

            if (oldEntity == null)
            {
                return null; // Hotel not found
            }

            oldEntity = entity; // Update existing hotel entity
            Save(); // Save changes to file

            return oldEntity;
        }

        // Saves the current state of the repository to the file
        public void Save()
        {
            serializer.ToCSV(filePath, hotels);
        }
    }
}

