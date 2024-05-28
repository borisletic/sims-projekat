using HotelBookingApp.Model;
using HotelBookingApp.Observer;
using HotelBookingApp.RepositoryInterfaces;
using HotelBookingApp.Serializer;
using System.Collections.Generic;


namespace HotelBookingApp.Repository
{

    public class AdministratorRepository : IAdministratorRepository
    {
        // File path for storing administrator data
        private const string filePath = "../../../Data/Administrator.csv";

        // Serializer instance for handling data serialization
        private Serializer<Administrator> serializer;

        // List of observers for observing changes in the repository
        private List<IObserver> observers;

        // List to hold administrator objects
        private List<Administrator> administrators;

        // Singleton instance of the repository
        private static IAdministratorRepository instance = null;

        // Private constructor to prevent external instantiation
        private AdministratorRepository()
        {
            serializer = new Serializer<Administrator>();

            // Load administrator data from CSV file
            administrators = serializer.FromCSV(filePath);

            // Initialize list of observers
            observers = new List<IObserver>();
        }

        // Method to retrieve the singleton instance of the repository
        public static IAdministratorRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new AdministratorRepository();
            }

            return instance;
        }

        // Method to retrieve all administrators
        public List<Administrator> GetAll()
        {
            return administrators;
        }

        // Method to retrieve an administrator by ID
        public Administrator Get(int id)
        {
            return administrators.Find(a => a.Id == id);
        }

        //public Administrator GetApartmentById(int id)
        //{
        //    return administrators.Find(a => a.Id == id);
        //}

        // Method to update an existing administrator
        public Administrator Update(Administrator entity)
        {
            // Find the old entity based on ID
            Administrator oldEntity = Get(entity.Id);

            // If old entity does not exist, return null
            if (oldEntity == null)
            {
                return null;
            }

            // Replace old entity with new entity and save changes
            oldEntity = entity;
            Save();

            return oldEntity;
        }

        // Method to save changes to the repository
        public void Save()
        {
            serializer.ToCSV(filePath, administrators);
        }
    }
}
