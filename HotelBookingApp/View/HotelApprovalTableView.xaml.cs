using HotelBookingApp.Controller;
using HotelBookingApp.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;


namespace HotelBookingApp.View
{
    public partial class HotelApprovalTableView : Window
    {
        // Define property for selected hotel
        public Hotel SelectedHotel { get; set; }

        // Define collection of hotels
        public static ObservableCollection<Hotel> Hotels { get; } = new ObservableCollection<Hotel>();

        // Define controller for hotels
        private readonly HotelController hotelController;

        // Constructor
        public HotelApprovalTableView()
        {
            InitializeComponent();
            DataContext = this; // Set data context to this view
            WindowStartupLocation = WindowStartupLocation.CenterScreen; // Set window startup location

            hotelController = new HotelController(); // Initialize hotel controller
            LoadUnapprovedHotels(); // Load unapproved hotels
        }

        // Method to load unapproved hotels
        private void LoadUnapprovedHotels()
        {
            Hotels.Clear(); // Clear existing hotels
            // Retrieve unapproved hotels for the logged-in user and add them to the collection
            var unapprovedHotels = hotelController.GetAll().Where(hotel => !hotel.Accepted && MainWindow.LogInUser.Jmbg == hotel.JmbgOwner);
            foreach (var hotel in unapprovedHotels)
            {
                Hotels.Add(hotel);
            }
        }

        // Event handler for close button click
        private void CloseClick(object sender, RoutedEventArgs e)
        {
            var hotelView = new HotelView(MainWindow.LogInUser); // Create a new instance of HotelView
            hotelView.Show(); // Show the HotelView
            Close(); // Close the current window
        }

        // Event handler for opening selected hotel
        private void OpenSelectedHotel(object sender, MouseButtonEventArgs e)
        {
            if (SelectedHotel != null) // Check if a hotel is selected
            {
                var hotelApproval = new HotelApprovalView(SelectedHotel); // Create a new instance of HotelApprovalView with the selected hotel
                hotelApproval.Show(); // Show the HotelApprovalView
            }
        }
    }
}


