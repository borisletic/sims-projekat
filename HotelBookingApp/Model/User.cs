using System;


namespace HotelBookingApp.Model
{
    public class User : HotelBookingApp.Serializer.ISerializable
    {        
        private int id;
        private string jmbg;
        private string email;
        private string password;
        private string name;
        private string surname;
        private string phoneNumber;

        public bool Blocked { get; set; }
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

        public User()
        {

        }


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
