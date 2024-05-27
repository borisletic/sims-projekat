using HotelBookingApp.Controller;
using HotelBookingApp.Model;
using HotelBookingApp.Service;
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
    
    public partial class HotelApprovalTableView : Window
    {
        public Hotel SelectedHotel { get; set; }

        public static ObservableCollection<Hotel> Hotels { get; set; }

        private readonly HotelController hotelController;

        public HotelApprovalTableView()
        {
            InitializeComponent();

            this.DataContext = this;

            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            
            hotelController = new HotelController();

            Hotels = new ObservableCollection<Hotel>(hotelController.GetAll().Where(hotel => !hotel.Accepted && MainWindow.LogInUser.Jmbg == hotel.JmbgOwner));
        }

        private void OpenSelectedHotel(object sender, MouseButtonEventArgs e)
        {
            HotelApprovalView hotelapproval = new HotelApprovalView(SelectedHotel);

            hotelapproval.Show();
        }

        private void CloseClick(object sender, RoutedEventArgs e)
        {
            HotelView hotelview = new HotelView(MainWindow.LogInUser);

            hotelview.Show();

            this.Close();
        }
    }
}
