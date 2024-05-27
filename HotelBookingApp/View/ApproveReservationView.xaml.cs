using HotelBookingApp.Controller;
using HotelBookingApp.Model;
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

            this.DataContext = this;

            SelectedReservation = reservation;

            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            
            reservationController = new ReservationController();
        }

        

        private void ApproveReservation(object sender, RoutedEventArgs e)
        {
            SelectedReservation.Status = Model.Enums.ReservationStatus.Approved;

            reservationController.Update(SelectedReservation);

            Update();

            this.Close();
        }

        private void RejectReservation(object sender, RoutedEventArgs e)
        {
            SelectedReservation.Status = Model.Enums.ReservationStatus.Rejected;

            SelectedReservation.Comment = "The apartment is available on this application, so the guest could make a reservation, but someone made an appointment for the same apartment over the phone, and the owner still cannot confirm the reservation.";

            reservationController.Update(SelectedReservation);

            Update();

            this.Close();
        }

        public void Update()
        {
            ReservationsForOwner.Reservations.Clear();

            foreach (Reservation reservation in reservationController.GetAll().FindAll(r => r.Owner.Id == MainWindow.LogInUser.Id))
            {
                ReservationsForOwner.Reservations.Add(reservation);
            }
        }
    }
}
