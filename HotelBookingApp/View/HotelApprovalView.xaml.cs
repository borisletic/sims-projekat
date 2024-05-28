using HotelBookingApp.Controller;
using HotelBookingApp.Model;
using System.Windows;


namespace HotelBookingApp.View
{
    public partial class HotelApprovalView : Window
    {
        // Define controller for hotels
        private readonly HotelController hotelController;

        // Define property for selected hotel
        public Hotel SelectedHotel { get; set; }

        // Constructor
        public HotelApprovalView(Hotel hotel)
        {
            InitializeComponent();
            DataContext = this; // Set data context to this view
            WindowStartupLocation = WindowStartupLocation.CenterScreen; // Set window startup location
            SelectedHotel = hotel; // Set selected hotel
            hotelController = new HotelController(); // Initialize hotel controller
        }

        // Event handler for rejecting a hotel
        private void RejectHotel(object sender, RoutedEventArgs e)
        {
            hotelController.Delete(SelectedHotel); // Delete the selected hotel
            MessageBox.Show("Your hotel has been rejected", "Hotels"); // Show a message box indicating rejection
            HotelApprovalTableView.Hotels.Remove(SelectedHotel); // Remove the rejected hotel from the list
            Close(); // Close the window
        }

        // Event handler for approving a hotel
        private void ApproveHotel(object sender, RoutedEventArgs e)
        {
            SelectedHotel.Accepted = true; // Set the hotel's acceptance status to true
            SelectedHotel.Owner = (Owner)MainWindow.LogInUser; // Set the hotel's owner
            SelectedHotel.OwnerId = MainWindow.LogInUser.Id; // Set the owner ID
            hotelController.Update(SelectedHotel); // Update the hotel in the database
            Close(); // Close the window
        }
    }
}

