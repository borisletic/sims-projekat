using HotelBookingApp.Controller;
using HotelBookingApp.Model;
using HotelBookingApp.ServiceInterfaces;
using HotelBookingApp.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
               selectedReservation = value;
            }
        }

        private ObservableCollection<Reservation> reservations;
        public ObservableCollection<Reservation> Reservations
        {
            get => reservations;

            set
            {
                reservations = value;
            }
        }
        public ObservableCollection<String> Filters { get; set; }

        private string selectedFilter;
        public string SelectedFilter
        {
            get => selectedFilter;

            set
            {
                selectedFilter = value;
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

            Filters = new ObservableCollection<String>();

            Filters.Add("Waiting");
            Filters.Add("Approved");
            Filters.Add("Rejected");
        }

        private void Filter(object sender, RoutedEventArgs e)
        {
            List<Reservation> filteredReservations = new List<Reservation>();

            if (SelectedFilter == "Waiting")
            {
                filteredReservations = reservationController.GetAll().Where(r => r.Status == Model.Enums.ReservationStatus.Waiting).ToList();
            }

            else if (SelectedFilter == "Approved")
            {
                filteredReservations = reservationController.GetAll().Where(r => r.Status == Model.Enums.ReservationStatus.Approved).ToList();
            }

            else if (SelectedFilter == "Rejected")
            {
                filteredReservations = reservationController.GetAll().Where(r => r.Status == Model.Enums.ReservationStatus.Rejected).ToList();
            }

            Reservations.Clear();

            foreach (var reservation in filteredReservations)
            {
                Reservations.Add(reservation);
            }
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

        private void Clear(object sender, RoutedEventArgs e)
        {
            Reservations.Clear();

            foreach (var reservation in reservationController.GetAll())
            {
                Reservations.Add(reservation);
            }

            myComboBox.Text = "";
        }
    }
}
