using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HotelBookingApp.Model
{
    public class Hotel : HotelBookingApp.Serializer.ISerializable
    {
        private Regex NumberOfStarsRegex = new Regex("[2-7]{1}");
        private Regex JmbgOfTheOwnerRegex = new Regex("[0-9]{13}");

        private int _id;
        private string _code;
        private string _name;
        private int _constructionYear;
        Dictionary<int, Apartment> _apartments = new Dictionary<int, Apartment>();
        private int _starsNumber;
        private string _jmbgOwner;
        private int _ownerId;
        private Owner _owner;
        public bool Accepted { get; set; }
        public int Id
        {
            get { return _id; }

            set
            {

                if (value != 0)
                {
                    _id = value;
                }
            }
        }
        public string Code
        {
            get { return _code; }

            set

            {
                if (value != null)
                {
                    _code = value;
                }
            }
        }
        public string Name
        {
            get { return _name; }

            set
            {
                if (value != null)
                {
                    _name = value;
                }
            }
        }

        public Dictionary<int, Apartment> Apartments
        {
            get { return _apartments; }

            set
            {
                if(value != null)
                {
                    _apartments = value;
                }
            }
        }

        public int ConstructionYear
        {
            get { return _constructionYear; }

            set
            {
                if (value != 0)
                {
                    _constructionYear = value;
                }
            }
        }
        public int StarsNumber
        {
            get { return _starsNumber; }

            set
            {
                if(value != 0)
                {
                    _starsNumber = value;
                }
            }
        }

        public string JmbgOwner
        {
            get { return _jmbgOwner; }

            set
            {
                if (value != null)
                {
                    _jmbgOwner = value;
                }
            }
        }
        public int OwnerId
        {
            get => _ownerId;

            set
            {
                if (value != _ownerId)
                {
                    _ownerId = value;
                }
            }
        }

        public Owner Owner
        {
            get => _owner;

            set
            {
                if (value != _owner)
                {
                    _owner = value;
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
            _apartments = new Dictionary<int, Apartment>();
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
