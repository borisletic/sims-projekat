using HotelBookingApp.Controller;
using HotelBookingApp.Model;
using System.Linq;
using System.Windows;


namespace HotelBookingApp.View
{
    public partial class ApproveReservationView : Window
    {
        public Reservation SelectedReservation { get; set; }

        private readonly ReservationController reservationController;

        public ApproveReservationView(Reservation reservation)
        {
            InitializeComponent();

            DataContext = this;

            SelectedReservation = reservation;

            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            reservationController = new ReservationController();
        }

        private void ApproveReservation(object sender, RoutedEventArgs e)
        {
            UpdateReservationStatus(Model.Enums.ReservationStatus.Approved);
            Close();
        }

        private void RejectReservation(object sender, RoutedEventArgs e)
        {
            UpdateReservationStatus(Model.Enums.ReservationStatus.Rejected);
            Close();
        }

        private void UpdateReservationStatus(Model.Enums.ReservationStatus status)
        {
            SelectedReservation.Status = status;
            if (status == Model.Enums.ReservationStatus.Rejected)
            {
                SelectedReservation.Comment = "The apartment is available on this application, so the guest could make a reservation, but someone made an appointment for the same apartment over the phone, and the owner still cannot confirm the reservation.";
            }
            reservationController.Update(SelectedReservation);
            UpdateReservationsForOwner();
        }

        private void UpdateReservationsForOwner()
        {
            ReservationsForOwner.Reservations.Clear();
            foreach (var reservation in reservationController.GetAll().Where(r => r.Owner.Id == MainWindow.LogInUser.Id))
            {
                ReservationsForOwner.Reservations.Add(reservation);
            }
        }
    }
}

