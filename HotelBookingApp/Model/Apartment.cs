using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingApp.Model
{
    public class Apartment : HotelBookingApp.Serializer.ISerializable
    {
        private int _id;
        private string _name;
        private string _description;
        private int _roomNumber;
        private int _maxGuestNumber;
        private int _hotelId;
        private Hotel _hotel;

        public int Id
        {
            get { return _id; }

            set
            {
                if(value != 0)
                {
                    _id = value;
                }
            }
        }
        public string Name
        {
            get { return _name; }

            set
            {
                if(value != null)
                {
                    _name = value;
                }
            }
        }
        public string Description
        {
            get { return _description; }

            set
            {
                if (value != null)
                {
                    _description = value;
                }
            }
        }
        public int RoomNumber
        {
            get { return _roomNumber; }

            set
            {
                if(value != 0)
                {
                    _roomNumber = value;
                }
            }
        }
        public int MaxGuestNumber
        {
            get { return _maxGuestNumber; }

            set
            {
                if (value != 0)
                {
                    _maxGuestNumber = value;
                }
            }
        }

        public int HotelId
        {
            get => _hotelId;

            set
            {
                if(value != _hotelId)
                {
                    _hotelId = value;
                }
            }
        }
        public Hotel Hotel
        {
            get => _hotel;

            set
            {
                if(value!= _hotel)
                {
                    _hotel = value;
                }
            }
        }
        public Apartment(int id, string name, string description, int roomNumber, int maxGuestNumber, Hotel hotel)
        {
            Id = id;
            Name = name;
            Description = description;
            RoomNumber = roomNumber;
            MaxGuestNumber = maxGuestNumber;
            Hotel = hotel;
        }
        public Apartment()
        {

        }
        public virtual string[] ToCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                Name,
                Description,
                RoomNumber.ToString(),
                MaxGuestNumber.ToString(),
                HotelId.ToString()
            };

            return csvValues;
        }
        public virtual void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            Name = values[1];
            Description = values[2];
            RoomNumber = Convert.ToInt32(values[3]);
            MaxGuestNumber = Convert.ToInt32(values[4]);
            HotelId = Convert.ToInt32(values[5]);
        }
    }
}
