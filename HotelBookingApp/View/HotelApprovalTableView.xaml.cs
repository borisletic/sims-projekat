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
