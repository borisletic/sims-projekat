using HotelBookingApp.Model;
using HotelBookingApp.Observer;
using HotelBookingApp.RepositoryInterfaces;
using HotelBookingApp.Serializer;
using System.Collections.Generic;


namespace HotelBookingApp.Repository
{
    public class AdministratorRepository : IAdministratorRepository
    {
        private const string filePath = "../../../Data/Administrator.csv";

        private Serializer<Administrator> serializer;


        private List<IObserver> observers;

        private List<Administrator> administrators;

        private static IAdministratorRepository instance = null;

        private AdministratorRepository()
        {
            serializer = new Serializer<Administrator>();

            administrators = new List<Administrator>();
            administrators = serializer.FromCSV(filePath);

            observers = new List<IObserver>();
        }

        public static IAdministratorRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new AdministratorRepository();
            }

            return instance;
        }

        
        public List<Administrator> GetAll()
        {
            return administrators;
        }


        public Administrator GetApartmentById(int id)
        {
            return administrators.Find(a => a.Id == id);
        }

        

        public Administrator Get(int id)
        {
            return administrators.Find(a => a.Id == id);
        }

        public Administrator Update(Administrator entity)
        {
            Administrator oldEntity = Get(entity.Id);

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
            serializer.ToCSV(filePath, administrators);
        }


    }
}

