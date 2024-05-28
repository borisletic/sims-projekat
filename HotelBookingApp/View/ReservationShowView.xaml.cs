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

        public event PropertyChangedEventHandler PropertyChanged;

        public Reservation SelectedReservation
        {
            get => selectedReservation;
            set
            {
                if (value != selectedReservation)
                {
                    selectedReservation = value;
                    OnPropertyChanged(nameof(SelectedReservation));
                }
            }
        }

        private ObservableCollection<Reservation> reservations;
        public ObservableCollection<Reservation> Reservations
        {
            get => reservations;
            set
            {
                reservations = value;
                OnPropertyChanged(nameof(Reservations));
            }
        }

        public ObservableCollection<string> Filters { get; set; }

        private string selectedFilter;
        public string SelectedFilter
        {
            get => selectedFilter;
            set
            {
                selectedFilter = value;
                OnPropertyChanged(nameof(SelectedFilter));
                Filter(null, null); // Automatically apply filter when the selected filter changes
            }
        }

        private readonly ReservationController reservationController;

        public ReservationShowView()
        {
            InitializeComponent();

            this.DataContext = this;

            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            reservationController = new ReservationController();

            Reservations = new ObservableCollection<Reservation>(reservationController.GetAll().FindAll(r => r.Guest.Id == MainWindow.LogInUser.Id));

            Filters = new ObservableCollection<string>
            {
                "Waiting",
                "Approved",
                "Rejected"
            };
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            Reservations.Clear();

            foreach (var reservation in reservationController.GetAll())
            {
                Reservations.Add(reservation);
            }

            myComboBox.Text = "";
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            if (SelectedReservation == null)
            {
                return;
            }

            SelectedReservation.Status = Model.Enums.ReservationStatus.Canceled;

            reservationController.Update(SelectedReservation);

            Update();
        }

        public void Update()
        {
            Reservations.Clear();

            foreach (var reservation in reservationController.GetAll().FindAll(r => r.Guest.Id == MainWindow.LogInUser.Id))
            {
                Reservations.Add(reservation);
            }
        }

        private void Filter(object sender, RoutedEventArgs e)
        {
            List<Reservation> filter = new List<Reservation>();

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

            Reservations.Clear();

            foreach (var reservation in filter)
            {
                Reservations.Add(reservation);
            }
        }
    }
}
