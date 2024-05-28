using HotelBookingApp.Model;
using HotelBookingApp.Observer;
using HotelBookingApp.RepositoryInterfaces;
using HotelBookingApp.Serializer;
using System.Collections.Generic;


namespace HotelBookingApp.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private const string filePath = "../../../Data/Owner.csv";

        private readonly List<IObserver> observers;
        private readonly Serializer<Owner> serializer;

        private List<Owner> owners;

        private static IOwnerRepository instance = null;

        // Singleton pattern: ensuring only one instance of OwnerRepository is created
        public static IOwnerRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new OwnerRepository();
            }

            return instance;
        }

        private OwnerRepository()
        {
            serializer = new Serializer<Owner>();

            // Load owners from CSV file
            owners = serializer.FromCSV(filePath);

            observers = new List<IObserver>();
        }

        // Retrieves all owners from the repository
        public List<Owner> GetAll()
        {
            return owners;
        }

        // Retrieves an owner by their ID
        public Owner Get(int id)
        {
            return owners.Find(o => o.Id == id);
        }

        // Creates a new owner entity in the repository
        public void Create(Owner owner)
        {
            owner.Id = NextId(); // Generate ID for the new owner

            owners.Add(owner); // Add the new owner to the list
            Save(); // Save changes to file
        }

        // Updates an existing owner entity in the repository
        public Owner Update(Owner entity)
        {
            Owner oldEntity = Get(entity.Id);

            if (oldEntity == null)
            {
                return null;
            }

            oldEntity = entity; // Update existing owner entity
            Save(); // Save changes to file

            return oldEntity;
        }

        // Generates the next available ID for a new owner entity
        public int NextId()
        {
            if (owners.Count == 0) return 0; // If no owners exist, return 0 as the first ID

            int newId = owners[owners.Count - 1].Id + 1; // Increment the ID of the last owner

            // Ensure the generated ID is unique among existing owners
            foreach (Owner owner in owners)
            {
                if (newId == owner.Id)
                {
                    newId++;
                }
            }

            return newId;
        }

        // Saves the current state of the repository to the file
        public void Save()
        {
            serializer.ToCSV(filePath, owners);
        }

    }
}

