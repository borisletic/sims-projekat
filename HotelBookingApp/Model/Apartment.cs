using System;


namespace HotelBookingApp.Model
{
    public class Apartment : HotelBookingApp.Serializer.ISerializable
    {
        private int id;
        private string name;
        private string description;
        private int roomNumber;
        private int maxGuestNumber;
        private int hotelId;
        private Hotel hotel;

        public int Id
        {
            get { return id; }

            set
            {
                if(value != 0)
                {
                    id = value;
                }
            }
        }
        public string Name
        {
            get { return name; }

            set
            {
                if(value != null)
                {
                    name = value;
                }
            }
        }
        public string Description
        {
            get { return description; }

            set
            {
                if (value != null)
                {
                    description = value;
                }
            }
        }
        public int RoomNumber
        {
            get { return roomNumber; }

            set
            {
                if(value != 0)
                {
                    roomNumber = value;
                }
            }
        }
        public int MaxGuestNumber
        {
            get { return maxGuestNumber; }

            set
            {
                if (value != 0)
                {
                    maxGuestNumber = value;
                }
            }
        }

        public int HotelId
        {
            get => hotelId;

            set
            {
                if(value != hotelId)
                {
                   hotelId = value;
                }
            }
        }
        public Hotel Hotel
        {
            get => hotel;

            set
            {
                if(value!= hotel)
                {
                    hotel = value;
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
