using HotelBookingApp.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
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
                .Where(reservation => reservation.OwnerId == MainWindow.LogInUser.Id)
                .Select(hotel => hotel.Name)
                .ToList();

            Hotels = new ObservableCollection<string>(hotels);

            Hotels.Clear();

            foreach (var hotel in hotels)
            {
                Hotels.Add(hotel);
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
                Hotel = hotelController.GetAll().Find(hotel => hotel.Name == SelectedHotel)
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
