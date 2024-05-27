using HotelBookingApp.Controller;
using HotelBookingApp.Model;
using HotelBookingApp.ServiceInterfaces;
using HotelBookingApp.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public void Update()
        {
            ReservationsForOwner.Reservations.Clear();
            foreach (Reservation reservation in reservationController.GetAll().FindAll(r => r.Owner.Id == MainWindow.LogInUser.Id))
            {
                ReservationsForOwner.Reservations.Add(reservation);
            }
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
    }
}
