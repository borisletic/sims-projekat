using HotelBookingApp.Controller;
using HotelBookingApp.Model;
using System.Linq;
using System.Windows;


namespace HotelBookingApp.View
{
    public partial class ApproveReservationView : Window
    {
        // Define property for selected reservation
        public Reservation SelectedReservation { get; set; }

        // Define controller for reservations
        private readonly ReservationController reservationController;

        // Constructor
        public ApproveReservationView(Reservation reservation)
        {
            InitializeComponent();

            DataContext = this; // Set data context to this view

            SelectedReservation = reservation; // Set selected reservation

            WindowStartupLocation = WindowStartupLocation.CenterScreen; // Set window startup location

            reservationController = new ReservationController(); // Initialize reservation controller
        }

        // Event handler for approving a reservation
        private void ApproveReservation(object sender, RoutedEventArgs e)
        {
            UpdateReservationStatus(Model.Enums.ReservationStatus.Approved); // Update reservation status to Approved
            Close(); // Close the window after updating
        }

        // Event handler for rejecting a reservation
        private void RejectReservation(object sender, RoutedEventArgs e)
        {
            UpdateReservationStatus(Model.Enums.ReservationStatus.Rejected); // Update reservation status to Rejected
            Close(); // Close the window after updating
        }

        // Method to update reservation status
        private void UpdateReservationStatus(Model.Enums.ReservationStatus status)
        {
            SelectedReservation.Status = status; // Set reservation status
            // Add comment if status is Rejected
            if (status == Model.Enums.ReservationStatus.Rejected)
            {
                SelectedReservation.Comment = "The apartment is available on this application, so the guest could make a reservation, but someone made an appointment for the same apartment over the phone, and the owner still cannot confirm the reservation.";
            }
            reservationController.Update(SelectedReservation); // Update reservation in the database
            UpdateReservationsForOwner(); // Update reservations for the owner
        }

        // Method to update reservations for the owner
        private void UpdateReservationsForOwner()
        {
            ReservationsForOwner.Reservations.Clear(); // Clear existing reservations
            // Add reservations for the owner to the list
            foreach (var reservation in reservationController.GetAll().Where(r => r.Owner.Id == MainWindow.LogInUser.Id))
            {
                ReservationsForOwner.Reservations.Add(reservation);
            }
        }
    }
}


