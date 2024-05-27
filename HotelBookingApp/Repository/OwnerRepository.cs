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
        private const string filePath = "../../../Data/Owner.csv";

        private readonly List<IObserver> observers;
        private readonly Serializer<Owner> serializer;
        private List<Owner> owners;
        private static IOwnerRepository instance = null;

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
            owners = new List<Owner>();
            owners = serializer.FromCSV(filePath);
            observers = new List<IObserver>();
        }
        
        public List<Owner> GetAll()
        {
            return owners;
        }

        public Owner Get(int id)
        {
            return owners.Find(o => o.Id == id);
        }
       

        public void Create(Owner owner)
        {
            owner.Id = NextId();
            owners.Add(owner);
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
            if (owners.Count == 0) return 0;
            int newId = owners[owners.Count() - 1].Id + 1;
            foreach (Owner a in owners)
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
            serializer.ToCSV(filePath, owners);
        }

    }

}
