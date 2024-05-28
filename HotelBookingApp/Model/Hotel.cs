using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace HotelBookingApp.Model
{
    // Hotel class implementing ISerializable interface from HotelBookingApp.Serializer namespace
    public class Hotel : HotelBookingApp.Serializer.ISerializable
    {
        // Private fields to store hotel information
        private int id;
        private string code;
        private string name;
        private int constructionYear;
        private Dictionary<int, Apartment> apartments = new Dictionary<int, Apartment>();
        private int starsNumber;
        private string jmbgOwner;
        private int ownerId;
        private Owner owner;

        // Public property to indicate if the hotel is accepted
        public bool Accepted { get; set; }

        // Public property for Id with a validation in the setter
        public int Id
        {
            get { return id; }
            set
            {
                if (value != 0)
                {
                    id = value;
                }
            }
        }

        // Public property for Code with a validation in the setter
        public string Code
        {
            get { return code; }
            set
            {
                if (value != null)
                {
                    code = value;
                }
            }
        }

        // Public property for Name with a validation in the setter
        public string Name
        {
            get { return name; }
            set
            {
                if (value != null)
                {
                    name = value;
                }
            }
        }

        // Public property for Apartments with a validation in the setter
        public Dictionary<int, Apartment> Apartments
        {
            get { return apartments; }
            set
            {
                if (value != null)
                {
                    apartments = value;
                }
            }
        }

        // Public property for ConstructionYear with a validation in the setter
        public int ConstructionYear
        {
            get { return constructionYear; }
            set
            {
                if (value != 0)
                {
                    constructionYear = value;
                }
            }
        }

        // Public property for StarsNumber with a validation in the setter
        public int StarsNumber
        {
            get { return starsNumber; }
            set
            {
                if (value != 0)
                {
                    starsNumber = value;
                }
            }
        }

        // Public property for JmbgOwner with a validation in the setter
        public string JmbgOwner
        {
            get { return jmbgOwner; }
            set
            {
                if (value != null)
                {
                    jmbgOwner = value;
                }
            }
        }

        // Public property for OwnerId with a validation in the setter
        public int OwnerId
        {
            get => ownerId;
            set
            {
                if (value != ownerId)
                {
                    ownerId = value;
                }
            }
        }

        // Public property for Owner with a validation in the setter
        public Owner Owner
        {
            get => owner;
            set
            {
                if (value != owner)
                {
                    owner = value;
                }
            }
        }

        // Default constructor initializing the apartments dictionary
        public Hotel()
        {
            apartments = new Dictionary<int, Apartment>();
        }

        // Parameterized constructor to initialize all properties
        public Hotel(int id, string code, string name, Dictionary<int, Apartment> apartments, int constructionYear, int starsNumber, string jmbgOwner, int ownerId, Owner owner)
        {
            Id = id;
            Code = code;
            Name = name;
            Apartments = apartments;
            ConstructionYear = constructionYear;
            StarsNumber = starsNumber;
            JmbgOwner = jmbgOwner;
            OwnerId = ownerId;
            Owner = owner;
        }

        // Method to convert hotel data to a CSV string array
        public virtual string[] ToCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                Code,
                Name,
                ConstructionYear.ToString(),
                StarsNumber.ToString(),
                JmbgOwner,
                OwnerId.ToString(),
                Accepted.ToString()
            };
            return csvValues;
        }

        // Method to populate hotel data from a CSV string array
        public virtual void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            Code = values[1];
            Name = values[2];
            ConstructionYear = Convert.ToInt32(values[3]);
            StarsNumber = Convert.ToInt32(values[4]);
            JmbgOwner = values[5];
            OwnerId = Convert.ToInt32(values[6]);
            Accepted = Convert.ToBoolean(values[7]);
        }
    }
}

