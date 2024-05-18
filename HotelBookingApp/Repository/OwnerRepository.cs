using HotelBookingApp.Model;
using HotelBookingApp.Observer;
using HotelBookingApp.RepositoryInterfaces;
using HotelBookingApp.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelBookingApp.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private const string _filePath = "../../../Data/Owner.csv";

        private readonly List<IObserver> _observers;
        private readonly Serializer<Owner> _serializer;
        private List<Owner> _owners;
        private static IOwnerRepository _instance = null;

        public static IOwnerRepository GetInstance()
        {
            if (_instance == null)
            {
                _instance = new OwnerRepository();
            }
            return _instance;
        }
        private OwnerRepository()
        {
            _serializer = new Serializer<Owner>();
            _owners = new List<Owner>();
            _owners = _serializer.FromCSV(_filePath);
            _observers = new List<IObserver>();
        }
        
        public List<Owner> GetAll()
        {
            return _owners;
        }

        public Owner Get(int id)
        {
            return _owners.Find(o => o.Id == id);
        }
       

        public void Create(Owner owner)
        {
            owner.Id = NextId();
            _owners.Add(owner);
            Save();
        }

        public Owner Update(Owner entity)
        {
            Owner oldEntity = Get(entity.Id);

            if (oldEntity == null)
            {
                return null;
            }

            oldEntity = entity;
            Save();

            return oldEntity;
        }

        public int NextId()
        {
            if (_owners.Count == 0) return 0;
            int newId = _owners[_owners.Count() - 1].Id + 1;
            foreach (Owner a in _owners)
            {
                if (newId == a.Id)
                {
                    newId++;
                }
            }
            return newId;
        }

        public void Save()
        {
            _serializer.ToCSV(_filePath, _owners);
        }

    }

}
