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
        // Define properties and controllers
        public static ObservableCollection<string> Hotels { get; set; } // Collection of hotel names
        private readonly HotelController hotelController; // Controller for hotels
        private readonly ApartmentController apartmentController; // Controller for apartments

        // Define properties for apartment creation form
        public Apartment SelectedApartment { get; set; } // Currently selected apartment
        public string ApartmentName { get; set; } // Name of the apartment
        public string RoomNumber { get; set; } // Room number
        public string MaxGuestNumber { get; set; } // Maximum number of guests
        public string Description { get; set; } // Description of the apartment
        public string SelectedHotel { get; set; } // Currently selected hotel

        // Constructor
        public ApartmentEnterView()
        {
            InitializeComponent();
            DataContext = this; // Set the data context to this view

            // Initialize controllers
            hotelController = new HotelController();
            apartmentController = new ApartmentController();

            WindowStartupLocation = WindowStartupLocation.CenterScreen; // Set window startup location

            InitializeHotels(); // Initialize hotel list
        }

        // Initialize hotel list
        private void InitializeHotels()
        {
            // Retrieve hotels owned by the logged-in user and populate the Hotels collection with their names
            Hotels = new ObservableCollection<string>(hotelController.GetAll()
                .Where(hotel => hotel.OwnerId == MainWindow.LogInUser.Id) // Filter hotels by owner ID
                .Select(hotel => hotel.Name) // Select hotel names
                .ToList()); // Convert to list
        }

        // Event handler for creating a new apartment
        private void CreateApartment(object sender, RoutedEventArgs e)
        {
            // Find the selected hotel
            var selectedHotel = hotelController.GetAll().FirstOrDefault(hotel => hotel.Name == SelectedHotel);
            if (selectedHotel == null)
            {
                MessageBox.Show("Selected hotel not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error); // Show error message if hotel is not found
                return;
            }

            // Create a new apartment object
            var apartment = new Apartment
            {
                Name = ApartmentName,
                RoomNumber = int.Parse(RoomNumber),
                MaxGuestNumber = int.Parse(MaxGuestNumber),
                Description = Description,
                Hotel = selectedHotel,
                HotelId = selectedHotel.Id
            };

            // Add the apartment to the database
            apartmentController.Create(apartment);

            // Update the list of apartments in the HotelView
            HotelView.Apartments.Clear();
            foreach (var apt in apartmentController.GetAll())
            {
                HotelView.Apartments.Add(apt);
            }

            Close(); // Close the window after creating the apartment
        }
    }
}


