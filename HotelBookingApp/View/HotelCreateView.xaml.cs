using HotelBookingApp.Controller;
using HotelBookingApp.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;


namespace HotelBookingApp.View
{
    public partial class HotelCreateView : Window, INotifyPropertyChanged
    {
        private readonly HotelController hotelController;

        public HotelCreateView()
        {
            InitializeComponent();
            DataContext = this;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            hotelController = new HotelController();
        }

        private string code;
        public string Code
        {
            get => code;
            set { SetProperty(ref code, value); }
        }

        private string nameHotel;
        public string NameHotel
        {
            get => nameHotel;
            set { SetProperty(ref nameHotel, value); }
        }

        private int constructionYear;
        public int ConstructionYear
        {
            get => constructionYear;
            set { SetProperty(ref constructionYear, value); }
        }

        private int starsNumber;
        public int StarsNumber
        {
            get => starsNumber;
            set { SetProperty(ref starsNumber, value); }
        }

        private string ownerJmbg;
        public string OwnerJmbg
        {
            get => ownerJmbg;
            set { SetProperty(ref ownerJmbg, value); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        private void CreateHotel(object sender, RoutedEventArgs e)
        {
            Hotel hotel = new Hotel
            {
                Code = Code,
                Name = NameHotel,
                ConstructionYear = ConstructionYear,
                StarsNumber = StarsNumber,
                JmbgOwner = OwnerJmbg,
                Accepted = false
            };

            hotelController.Create(hotel);

            MessageBox.Show("Your hotel has to be approved by the owner", "Hotel approval");

            Close();
        }
    }
}

