using HotelBookingApp.Controller;
using HotelBookingApp.Model;
using System;
using System.ComponentModel;
using System.Windows;

namespace HotelBookingApp.View
{
    public partial class ReservationApartmentView : Window, INotifyPropertyChanged
    {
        // Event for property changed
        public event PropertyChangedEventHandler PropertyChanged;

        // Property for start day of reservation
        private DateTime startDay;
        public DateTime StartDay
        {
            get { return startDay; }
            set
            {
                startDay = value;
                OnPropertyChanged(nameof(StartDay)); // Notify property changed
            }
        }

        // Property for the selected apartment
        public Apartment SelectedApartment { get; set; }

        // Reservation controller for handling reservations
        private readonly ReservationController reservationController;

        // Constructor
        public ReservationApartmentView(Apartment apartment)
        {
            InitializeComponent();

            StartDay = DateTime.Now; // Set the start day to current date

            WindowStartupLocation = WindowStartupLocation.CenterScreen; // Set window startup location

            reservationController = new ReservationController(); // Initialize reservation controller

            SelectedApartment = apartment; // Set the selected apartment
        }

        // Method for making a reservation
        private void MakeReservation(object sender, RoutedEventArgs e)
        {
            // Check if the selected date is null
            if (StartDatePicker.SelectedDate == null)
            {
                MessageBox.Show("You have to fill the date", "Warning"); // Show warning message
                return;
            }

            // Create a new reservation object
            Reservation reservation = new Reservation
            {
                StartDate = StartDatePicker.SelectedDate.Value, // Set start date
                Status = Model.Enums.ReservationStatus.Waiting, // Set status
                GuestId = MainWindow.LogInUser.Id, // Set guest ID
                Guest = (Guest)MainWindow.LogInUser, // Set guest
                Apartment = SelectedApartment, // Set apartment
                ApartmentId = SelectedApartment.Id, // Set apartment ID
                Owner = SelectedApartment.Hotel.Owner, // Set owner
                OwnerId = SelectedApartment.Hotel.OwnerId // Set owner ID
            };

            // Save the reservation
            reservationController.Create(reservation);

            Close(); // Close the window

            // Open the ReservationShowView
            ReservationShowView rsv = new ReservationShowView();
            rsv.Show();
        }

        // Method to invoke property changed event
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

