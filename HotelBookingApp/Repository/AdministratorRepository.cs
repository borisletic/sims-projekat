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
    public class AdministratorRepository : IAdministratorRepository
    {
        private const string _filePath = "../../../Data/Administrator.csv";

        private Serializer<Administrator> _serializer;


        private List<IObserver> _observers;
        private List<Administrator> _administrators;
        private static IAdministratorRepository _instance = null;

        private AdministratorRepository()
        {
            _serializer = new Serializer<Administrator>();
            _administrators = new List<Administrator>();
            _administrators = _serializer.FromCSV(_filePath);
            _observers = new List<IObserver>();
        }

        public static IAdministratorRepository GetInstance()
        {
            if (_instance == null)
            {
                _instance = new AdministratorRepository();
            }
            return _instance;
        }

        
        public List<Administrator> GetAll()
        {
            return _administrators;
        }


        public Administrator GetApartmentById(int id)
        {
            return _administrators.Find(a => a.Id == id);
        }

        

        public Administrator Get(int id)
        {
            return _administrators.Find(a => a.Id == id);
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
            _serializer.ToCSV(_filePath, _administrators);
        }


    }
}

