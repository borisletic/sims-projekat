using HotelBookingApp.Controller;
using HotelBookingApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;


namespace HotelBookingApp.View
{
    public partial class ReservationShowView : Window, INotifyPropertyChanged
    {
        private Reservation selectedReservation;

        // Event for property changed
        public event PropertyChangedEventHandler PropertyChanged;

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
        private ObservableCollection<Reservation> reservations;
        public ObservableCollection<Reservation> Reservations
        {
            get => reservations;
            set
            {
                reservations = value;
                OnPropertyChanged(nameof(Reservations)); // Notify property changed
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
                Filter(null, null); // Automatically apply filter when the selected filter changes
            }
        }

        // Reservation controller
        private readonly ReservationController reservationController;

        // Constructor
        public ReservationShowView()
        {
            InitializeComponent();

            this.DataContext = this; // Set data context to this view

            WindowStartupLocation = WindowStartupLocation.CenterScreen; // Set window startup location

            reservationController = new ReservationController(); // Initialize reservation controller

            // Initialize reservations collection with reservations for the current guest
            Reservations = new ObservableCollection<Reservation>(reservationController.GetAll().FindAll(r => r.Guest.Id == MainWindow.LogInUser.Id));

            // Initialize filters collection
            Filters = new ObservableCollection<string>
            {
                "Waiting",
                "Approved",
                "Rejected"
            };
        }

        // Method to invoke property changed event
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Event handler for clearing filters
        private void Clear(object sender, RoutedEventArgs e)
        {
            Reservations.Clear(); // Clear reservations

            foreach (var reservation in reservationController.GetAll())
            {
                Reservations.Add(reservation); // Add all reservations back
            }

            myComboBox.Text = ""; // Clear combo box
        }

        // Event handler for canceling reservation
        private void Cancel(object sender, RoutedEventArgs e)
        {
            if (SelectedReservation == null)
            {
                return;
            }

            SelectedReservation.Status = Model.Enums.ReservationStatus.Canceled; // Update reservation status to canceled

            reservationController.Update(SelectedReservation); // Update reservation in the database

            Update(); // Refresh reservations
        }

        // Method to update reservations
        public void Update()
        {
            Reservations.Clear(); // Clear reservations

            foreach (var reservation in reservationController.GetAll().FindAll(r => r.Guest.Id == MainWindow.LogInUser.Id))
            {
                Reservations.Add(reservation); // Add updated reservations
            }
        }

        // Event handler for applying filter
        private void Filter(object sender, RoutedEventArgs e)
        {
            List<Reservation> filter = new List<Reservation>();

            // Apply filter based on selected filter
            if (SelectedFilter == "Waiting")
            {
                filter = reservationController.GetAll().Where(r => r.Status == Model.Enums.ReservationStatus.Waiting).ToList();
            }
            else if (SelectedFilter == "Approved")
            {
                filter = reservationController.GetAll().Where(r => r.Status == Model.Enums.ReservationStatus.Approved).ToList();
            }
            else if (SelectedFilter == "Rejected")
            {
                filter = reservationController.GetAll().Where(r => r.Status == Model.Enums.ReservationStatus.Rejected).ToList();
            }

            Reservations.Clear(); // Clear existing reservations

            foreach (var reservation in filter)
            {
                Reservations.Add(reservation); // Add filtered reservations
            }
        }
    }
}

