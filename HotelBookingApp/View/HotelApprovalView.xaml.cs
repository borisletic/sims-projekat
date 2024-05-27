using HotelBookingApp.Controller;
using HotelBookingApp.Model;
using HotelBookingApp.ServiceInterfaces;
using HotelBookingApp.Util;
using System;
using System.Collections.Generic;
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
    
    public partial class HotelApprovalView : Window
    {
        private readonly HotelController hotelController;

        public Hotel SelectedHotel { get; set; }

        public HotelApprovalView(Hotel hotel)
        {
            InitializeComponent();

            this.DataContext = this;

            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            SelectedHotel = hotel;

            
            hotelController = new HotelController();
        }

        private void ApproveHotel(object sender, RoutedEventArgs e)
        {
            SelectedHotel.Accepted = true;

            SelectedHotel.Owner = (Owner)MainWindow.LogInUser;
            SelectedHotel.OwnerId = MainWindow.LogInUser.Id;

            hotelController.Update(SelectedHotel);

            Close();
        }

        private void RejectHotel(object sender, RoutedEventArgs e)
        {
            hotelController.Delete(SelectedHotel);

            MessageBox.Show("Your hotel has been rejected", "Hotels");
            HotelApprovalTableView.Hotels.Remove(SelectedHotel);

            Close();
        }
    }
}
