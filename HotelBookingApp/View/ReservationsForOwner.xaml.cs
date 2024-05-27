using HotelBookingApp.Controller;
using HotelBookingApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;


namespace HotelBookingApp.View
{

    public partial class ReservationsForOwner : Window, INotifyPropertyChanged
    {
        private Reservation selectedReservation;

        public event PropertyChangedEventHandler PropertyChanged;

        private readonly ReservationController reservationController;
        private readonly ApartmentController apartmentController;

        public static ObservableCollection<Apartment> Apartments { get; set; }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Reservation SelectedReservation
        {
            get => selectedReservation;

            set
            {
                if (value != selectedReservation)
                {
                    selectedReservation = value;
                }
            }
        }

        private static ObservableCollection<Reservation> reservations;
        public static ObservableCollection<Reservation> Reservations
        {
            get => reservations;

            set
            {
                reservations = value;
            }
        }

        public ObservableCollection<String> Filters { get; set; }

        private String selectedFilter;
        public String SelectedFilter
        {
            get => selectedFilter;

            set
            {
                selectedFilter = value;
            }
        }

        public String text;
        public String Text
        {
            get => text;

            set
            {
                text = value;
            }
        }

        public ReservationsForOwner()
        {
            InitializeComponent();

            this.DataContext = this;

            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            reservationController = new ReservationController();
            apartmentController = new ApartmentController();


            Reservations = new ObservableCollection<Reservation>(reservationController.GetAll().FindAll(r => r.Owner.Id == MainWindow.LogInUser.Id));

            Filters = new ObservableCollection<String>();

            Filters.Add("Waiting");
            Filters.Add("Approved");
        }

        private void Filter(object sender, RoutedEventArgs e)
        {
            List<Reservation> filteredReservations = new List<Reservation>();

            if (SelectedFilter == "Waiting")
            {
                filteredReservations = reservationController.GetAll().Where(r => r.Owner.Id == MainWindow.LogInUser.Id && r.Status == Model.Enums.ReservationStatus.Waiting).ToList();
            }

            else
            {
                filteredReservations = reservationController.GetAll().Where(r => r.Owner.Id == MainWindow.LogInUser.Id && r.Status == Model.Enums.ReservationStatus.Approved).ToList();
            }

            Reservations.Clear();

            foreach (var reservation in filteredReservations)
            {
                Reservations.Add(reservation);
            }
        }

        private void HotelClick(object sender, RoutedEventArgs e)
        {
            List<Reservation> filteredReservations = reservationController.GetAll().FindAll(ap => ap.Owner.Id == MainWindow.LogInUser.Id && ap.Apartment.Hotel.Name.ToLower().Contains(Text.ToLower()));

            Reservations.Clear();

            foreach (Reservation reservation in filteredReservations)
            {
                Reservations.Add(reservation);
            }
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            Reservations.Clear();

            foreach (Reservation reservation in reservationController.GetAll().FindAll(r => r.Owner.Id == MainWindow.LogInUser.Id))
            {
                Reservations.Add(reservation);
            }

            OnPropertyChanged(nameof(Reservations));

            myTextBox.Text = "";
        }


        private void ReservationsClick(object sender, MouseButtonEventArgs e)
        {
            if (SelectedReservation.Status != Model.Enums.ReservationStatus.Waiting)
            {
                MessageBox.Show("Your reservation has been processed", "Notification");

                return;
            }

            ApproveReservationView arv = new ApproveReservationView(SelectedReservation);

            arv.Show();
        }

        private void CreateApartment(object sender, RoutedEventArgs e)
        {
            ApartmentEnterView aew = new ApartmentEnterView();

            aew.Show();
        }
    }
}
