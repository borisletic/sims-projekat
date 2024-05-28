using HotelBookingApp.Controller;
using HotelBookingApp.Model;
using System;
using System.ComponentModel;
using System.Windows;

namespace HotelBookingApp.View
{
    public partial class ReservationApartmentView : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private DateTime startDay;
        public DateTime StartDay
        {
            get { return startDay; }
            set
            {
                startDay = value;
                OnPropertyChanged(nameof(StartDay));
            }
        }

        public Apartment SelectedApartment { get; set; }

        private readonly ReservationController reservationController;

        public ReservationApartmentView(Apartment apartment)
        {
            InitializeComponent();

            StartDay = DateTime.Now;

            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            reservationController = new ReservationController();

            SelectedApartment = apartment;
        }

        private void MakeReservation(object sender, RoutedEventArgs e)
        {
            // Check if the selected date is null
            if (StartDatePicker.SelectedDate == null)
            {
                MessageBox.Show("You have to fill the date", "Warning");
                return;
            }

            // Create a new reservation
            Reservation reservation = new Reservation
            {
                StartDate = StartDatePicker.SelectedDate.Value,
                Status = Model.Enums.ReservationStatus.Waiting,
                GuestId = MainWindow.LogInUser.Id,
                Guest = (Guest)MainWindow.LogInUser,
                Apartment = SelectedApartment,
                ApartmentId = SelectedApartment.Id,
                Owner = SelectedApartment.Hotel.Owner,
                OwnerId = SelectedApartment.Hotel.OwnerId
            };

            // Save the reservation
            reservationController.Create(reservation);

            Close();

            // Open the ReservationShowView
            ReservationShowView rsv = new ReservationShowView();
            rsv.Show();
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

