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

        public string ApartmentName { get; set; }
        public string RoomNumber { get; set; }
        public string MaxGuestNumber { get; set; }
        public string Description { get; set; }
        public string SelectedHotel { get; set; }

        public ApartmentEnterView()
        {
            InitializeComponent();
            DataContext = this;

            hotelController = new HotelController();
            apartmentController = new ApartmentController();

            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            InitializeHotels();
        }

        private void InitializeHotels()
        {
            Hotels = new ObservableCollection<string>(hotelController.GetAll()
                .Where(hotel => hotel.OwnerId == MainWindow.LogInUser.Id)
                .Select(hotel => hotel.Name)
                .ToList());
        }

        private void CreateApartment(object sender, RoutedEventArgs e)
        {
            var selectedHotel = hotelController.GetAll().FirstOrDefault(hotel => hotel.Name == SelectedHotel);
            if (selectedHotel == null)
            {
                MessageBox.Show("Selected hotel not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var apartment = new Apartment
            {
                Name = ApartmentName,
                RoomNumber = int.Parse(RoomNumber),
                MaxGuestNumber = int.Parse(MaxGuestNumber),
                Description = Description,
                Hotel = selectedHotel,
                HotelId = selectedHotel.Id
            };

            apartmentController.Create(apartment);

            HotelView.Apartments.Clear();
            foreach (var apt in apartmentController.GetAll())
            {
                HotelView.Apartments.Add(apt);
            }

            Close();
        }
    }
}

