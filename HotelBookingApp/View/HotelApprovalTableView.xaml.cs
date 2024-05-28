using HotelBookingApp.Controller;
using HotelBookingApp.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;


namespace HotelBookingApp.View
{
    public partial class HotelApprovalTableView : Window
    {
        public Hotel SelectedHotel { get; set; }

        public static ObservableCollection<Hotel> Hotels { get; } = new ObservableCollection<Hotel>();

        private readonly HotelController hotelController;

        public HotelApprovalTableView()
        {
            InitializeComponent();
            DataContext = this;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            hotelController = new HotelController();
            LoadUnapprovedHotels();
        }

        private void LoadUnapprovedHotels()
        {
            Hotels.Clear();
            var unapprovedHotels = hotelController.GetAll().Where(hotel => !hotel.Accepted && MainWindow.LogInUser.Jmbg == hotel.JmbgOwner);
            foreach (var hotel in unapprovedHotels)
            {
                Hotels.Add(hotel);
            }
        }

        private void CloseClick(object sender, RoutedEventArgs e)
        {
            var hotelView = new HotelView(MainWindow.LogInUser);
            hotelView.Show();
            Close();
        }

        private void OpenSelectedHotel(object sender, MouseButtonEventArgs e)
        {
            if (SelectedHotel != null)
            {
                var hotelApproval = new HotelApprovalView(SelectedHotel);
                hotelApproval.Show();
            }
        }
    }
}

