using HotelBookingApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
   
    public partial class ApartmentEnterView : Window
    {

        public static ObservableCollection<string> Hotels { get; set; }

        private readonly HotelController hotelController;
        private readonly ApartmentController apartmentController;

        public Apartment SelectedApartment { get; set; }

        public ApartmentEnterView()
        {
            InitializeComponent();
            this.DataContext = this;

            
            hotelController = new HotelController();
            apartmentController = new ApartmentController();

            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            List<string> hotels = hotelController.GetAll()
                .Where(r => r.OwnerId == MainWindow.LogInUser.Id)
                .Select(h => h.Name)
                .ToList();

            Hotels = new ObservableCollection<string>(hotels);

            Hotels.Clear();

            foreach (var h in hotels)
            {
                Hotels.Add(h);
            }
        }

        public string ApartmentName { get; set; }
        public string RoomNumber { get; set; }
        public string MaxGuestNumber { get; set; }
        public string Description { get; set; }
        public string SelectedHotel { get; set; }

        private void CreateApartment(object sender, RoutedEventArgs e)
        {
            Apartment apart = new Apartment
            {
                Name = ApartmentName,
                RoomNumber = int.Parse(RoomNumber),
                MaxGuestNumber = int.Parse(MaxGuestNumber),
                Description = Description,
                Hotel = hotelController.GetAll().Find(h => h.Name == SelectedHotel)
            };

            apart.HotelId = apart.Hotel.Id;
            apartmentController.Create(apart);

            HotelView.Apartments.Clear();

            foreach (var apartment in apartmentController.GetAll())
            {
                HotelView.Apartments.Add(apartment);
            }

            this.Close();
        }


    }
}
