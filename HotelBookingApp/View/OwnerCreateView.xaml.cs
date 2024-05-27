using HotelBookingApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HotelBookingApp.ServiceInterfaces;
using HotelBookingApp.Util;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using HotelBookingApp.Controller;

namespace HotelBookingApp.View
{

    public partial class OwnerCreateView : Window
    {

        private readonly OwnerController ownerController;
        private readonly AdministratorController administratorController;
        private readonly GuestController guestController;

        public OwnerCreateView()
        {
            InitializeComponent();

            this.DataContext = this;

            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            ownerController = new OwnerController();
            administratorController = new AdministratorController();
            guestController = new GuestController();
        }

        public string JMBG { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ApartmentName { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }

        private void CreateOwner(object sender, RoutedEventArgs e)
        {
            var tmp = ownerController.GetAll().Find(o => o.Email == Email || o.Jmbg == JMBG);

            if (tmp != null)
            {
                MessageBox.Show("Try again. Email or JMBG already exists", "Alert");

                return;
            }

            Owner owner = new Owner
            {
                Jmbg = JMBG,
                Email = Email,
                Password = Password,
                Name = ApartmentName,
                Surname = Surname,
                PhoneNumber = PhoneNumber
            };

            ownerController.Create(owner);

            AllUsersView.Users.Add(owner);

            this.Close();
        }

    }
}
