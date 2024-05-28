using System;


namespace HotelBookingApp.Model
{
    // User class implementing ISerializable interface from HotelBookingApp.Serializer namespace
    public class User : HotelBookingApp.Serializer.ISerializable
    {
        // Private fields to store user information
        private int id;
        private string jmbg;
        private string email;
        private string password;
        private string name;
        private string surname;
        private string phoneNumber;

        // Public property to indicate if the user is blocked
        public bool Blocked { get; set; }

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

        // Public property for JMBG with a validation in the setter
        public string Jmbg
        {
            get { return jmbg; }
            set
            {
                if (value != null)
                {
                    jmbg = value;
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

        // Public property for Surname with a validation in the setter
        public string Surname
        {
            get { return surname; }
            set
            {
                if (value != null)
                {
                    surname = value;
                }
            }
        }

        // Public property for PhoneNumber with a validation in the setter
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (value != null)
                {
                    phoneNumber = value;
                }
            }
        }

        // Public property for Email with a validation in the setter
        public string Email
        {
            get { return email; }
            set
            {
                if (value != null)
                {
                    email = value;
                }
            }
        }

        // Public property for Password with a validation in the setter
        public string Password
        {
            get { return password; }
            set
            {
                if (value != null)
                {
                    password = value;
                }
            }
        }

        // Default constructor
        public User()
        {
        }

        // Parameterized constructor to initialize all properties
        public User(int id, string jmbg, string email, string password, string name, string surname, string phoneNumber)
        {
            Id = id;
            Jmbg = jmbg;
            Email = email;
            Password = password;
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
        }

        // Method to convert user data to a CSV string array
        public virtual string[] ToCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                Jmbg,
                Email,
                Password,
                Name,
                Surname,
                PhoneNumber,
                Blocked.ToString()
            };
            return csvValues;
        }

        // Method to populate user data from a CSV string array
        public virtual void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            Jmbg = values[1];
            Email = values[2];
            Password = values[3];
            Name = values[4];
            Surname = values[5];
            PhoneNumber = values[6];
            Blocked = bool.Parse(values[7]);
        }
    }
}

