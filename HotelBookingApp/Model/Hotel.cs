using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace HotelBookingApp.Model
{
    public class Hotel : HotelBookingApp.Serializer.ISerializable
    {
        private Regex NumberOfStarsRegex = new Regex("[2-7]{1}");
        private Regex JmbgOfTheOwnerRegex = new Regex("[0-9]{13}");

        private int id;
        private string code;
        private string name;
        private int constructionYear;
        Dictionary<int, Apartment> apartments = new Dictionary<int, Apartment>();
        private int starsNumber;
        private string jmbgOwner;
        private int ownerId;
        private Owner owner;
        public bool Accepted { get; set; }
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

        public Dictionary<int, Apartment> Apartments
        {
            get { return apartments; }

            set
            {
                if(value != null)
                {
                    apartments = value;
                }
            }
        }

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
        public int StarsNumber
        {
            get { return starsNumber; }

            set
            {
                if(value != 0)
                {
                    starsNumber = value;
                }
            }
        }

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
        public Hotel()
        {
            apartments = new Dictionary<int, Apartment>();
        }

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
