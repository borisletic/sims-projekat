using HotelBookingApp.Controller;
using HotelBookingApp.Model;
using System;
using System.ComponentModel;
using System.Windows;

namespace HotelBookingApp.View
{
 
    public partial class ReservationApartmentView : Window
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
            if (StartDatePicker.SelectedDate == null)
            {
                MessageBox.Show("You have to fill the date", "Warning");

                return;
            }

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

            reservationController.Create(reservation);

            Close();

            ReservationShowView rsv = new ReservationShowView();

            rsv.Show();
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
