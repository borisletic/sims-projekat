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

        // Event for property changed
        public event PropertyChangedEventHandler PropertyChanged;

        // Reservation and apartment controllers
        private readonly ReservationController reservationController;
        private readonly ApartmentController apartmentController;

        // Collection of apartments
        public static ObservableCollection<Apartment> Apartments { get; set; }

        // Property for the selected reservation
        public Reservation SelectedReservation
        {
            get => selectedReservation;
            set
            {
                if (value != selectedReservation)
                {
                    selectedReservation = value;
                    OnPropertyChanged(nameof(SelectedReservation)); // Notify property changed
                }
            }
        }

        // Collection of reservations
        private static ObservableCollection<Reservation> reservations;
        public static ObservableCollection<Reservation> Reservations
        {
            get => reservations;
            set
            {
                reservations = value;
            }
        }

        // Collection of filters
        public ObservableCollection<string> Filters { get; set; }

        // Property for the selected filter
        private string selectedFilter;
        public string SelectedFilter
        {
            get => selectedFilter;
            set
            {
                selectedFilter = value;
                OnPropertyChanged(nameof(SelectedFilter)); // Notify property changed
            }
        }

        // Property for the filter text
        private string text;
        public string Text
        {
            get => text;
            set
            {
                text = value;
                OnPropertyChanged(nameof(Text)); // Notify property changed
            }
        }

        // Constructor
        public ReservationsForOwner()
        {
            InitializeComponent();

            this.DataContext = this; // Set data context to this view

            WindowStartupLocation = WindowStartupLocation.CenterScreen; // Set window startup location

            // Initialize reservation and apartment controllers
            reservationController = new ReservationController();
            apartmentController = new ApartmentController();

            // Initialize reservations collection with reservations for the current owner
            Reservations = new ObservableCollection<Reservation>(reservationController.GetAll().FindAll(r => r.Owner.Id == MainWindow.LogInUser.Id));

            // Initialize filters collection
            Filters = new ObservableCollection<string>
            {
                "Waiting",
                "Approved"
            };
        }

        // Method to invoke property changed event
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Event handler for filtering reservations by hotel name
        private void HotelClick(object sender, RoutedEventArgs e)
        {
            // Filter reservations by hotel name
            var filteredReservations = reservationController.GetAll().FindAll(ap => ap.Owner.Id == MainWindow.LogInUser.Id && ap.Apartment.Hotel.Name.ToLower().Contains(Text.ToLower()));

            Reservations.Clear(); // Clear existing reservations

            foreach (var reservation in filteredReservations)
            {
                Reservations.Add(reservation); // Add filtered reservations
            }
        }

        // Event handler for clicking on reservations
        private void ReservationsClick(object sender, MouseButtonEventArgs e)
        {
            // Check if the selected reservation status is waiting
            if (SelectedReservation.Status != Model.Enums.ReservationStatus.Waiting)
            {
                MessageBox.Show("Your reservation has been processed", "Notification"); // Show notification message
                return;
            }

            var arv = new ApproveReservationView(SelectedReservation); // Open approve reservation view
            arv.Show();
        }

        // Event handler for creating an apartment
        private void CreateApartment(object sender, RoutedEventArgs e)
        {
            var aew = new ApartmentEnterView(); // Open apartment enter view
            aew.Show();
        }

        // Event handler for clearing filters
        private void Clear(object sender, RoutedEventArgs e)
        {
            Reservations.Clear(); // Clear reservations

            foreach (var reservation in reservationController.GetAll().FindAll(r => r.Owner.Id == MainWindow.LogInUser.Id))
            {
                Reservations.Add(reservation); // Add filtered reservations
            }

            OnPropertyChanged(nameof(Reservations)); // Notify property changed
            myTextBox.Text = ""; // Clear text box
        }

        // Event handler for applying filter
        private void Filter(object sender, RoutedEventArgs e)
        {
            List<Reservation> filter;

            // Apply filter based on selected filter
            if (SelectedFilter == "Waiting")
            {
                filter = reservationController.GetAll().Where(r => r.Owner.Id == MainWindow.LogInUser.Id && r.Status == Model.Enums.ReservationStatus.Waiting).ToList();
            }
            else
            {
                filter = reservationController.GetAll().Where(r => r.Owner.Id == MainWindow.LogInUser.Id && r.Status == Model.Enums.ReservationStatus.Approved).ToList();
            }

            Reservations.Clear(); // Clear existing reservations

            foreach (var reservation in filter)
            {
                Reservations.Add(reservation); // Add filtered reservations
            }
        }
    }
}


