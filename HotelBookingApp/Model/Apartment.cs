using System;


namespace HotelBookingApp.Model
{
    // Apartment class implementing ISerializable interface from HotelBookingApp.Serializer namespace
    public class Apartment : HotelBookingApp.Serializer.ISerializable
    {
        // Private fields to store apartment information
        private int id;
        private string name;
        private string description;
        private int roomNumber;
        private int maxGuestNumber;
        private int hotelId;
        private Hotel hotel;

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

        // Public property for HotelId with a validation in the setter
        public int HotelId
        {
            get => hotelId;
            set
            {
                if (value != hotelId)
                {
                    hotelId = value;
                }
            }
        }

        // Public property for Hotel with a validation in the setter
        public Hotel Hotel
        {
            get => hotel;
            set
            {
                if (value != hotel)
                {
                    hotel = value;
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

        // Public property for Description with a validation in the setter
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

        // Public property for RoomNumber with a validation in the setter
        public int RoomNumber
        {
            get { return roomNumber; }
            set
            {
                if (value != 0)
                {
                    roomNumber = value;
                }
            }
        }

        // Public property for MaxGuestNumber with a validation in the setter
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

        // Default constructor
        public Apartment()
        {
        }

        // Parameterized constructor to initialize all properties
        public Apartment(int id, string name, string description, int roomNumber, int maxGuestNumber, Hotel hotel)
        {
            Id = id;
            Name = name;
            Description = description;
            RoomNumber = roomNumber;
            MaxGuestNumber = maxGuestNumber;
            Hotel = hotel;
        }

        // Method to convert apartment data to a CSV string array
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

        // Method to populate apartment data from a CSV string array
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

