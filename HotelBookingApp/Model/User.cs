using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HotelBookingApp.Model
{
    public class User : HotelBookingApp.Serializer.ISerializable
    {
        private Regex EmailRegex = new Regex(".+[@]");
        private Regex NumberOfJmbgRegex = new Regex("[0-9]{13}");
        private Regex PhoneNumberRegex = new Regex("[0-9]{10}");

        private int _id;
        private string _jmbg;
        private string _email;
        private string _password;
        private string _name;
        private string _surname;
        private string _phoneNumber;
        public bool Blocked { get; set; }
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
        public string Jmbg
        {

            get { return _jmbg; }

            set

            {
                if (value != null)

                {
                    _jmbg = value;
                }
            }

        }
        public string Email
        {

            get { return _email; }

            set
            {
                if (value != null)

                {
                    _email = value;
                }
            }

        }
        public string Password
        {

            get { return _password; }

            set
            {
                if (value != null)

                {
                    _password = value;
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
        public string Surname
        {

            get { return _surname; }

            set
            {
                if (value != null)

                {
                    _surname = value;
                }
            }

        }

        public string PhoneNumber
        {

            get { return _phoneNumber; }

            set
            {
                if (value != null)

                {
                    _phoneNumber = value;
                }
            }

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

        public User()
        {

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
