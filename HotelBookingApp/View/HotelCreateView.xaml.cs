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
        // Define controller for hotels
        private readonly HotelController hotelController;

        // Constructor
        public HotelCreateView()
        {
            InitializeComponent(); // Initialize components
            DataContext = this; // Set data context to this view
            WindowStartupLocation = WindowStartupLocation.CenterScreen; // Set window startup location
            hotelController = new HotelController(); // Initialize hotel controller
        }

        // Property for hotel code
        private string code;
        public string Code
        {
            get => code;
            set { SetProperty(ref code, value); } // Set property with OnPropertyChanged notification
        }

        // Property for hotel name
        private string nameHotel;
        public string NameHotel
        {
            get => nameHotel;
            set { SetProperty(ref nameHotel, value); } // Set property with OnPropertyChanged notification
        }

        // Property for construction year
        private int constructionYear;
        public int ConstructionYear
        {
            get => constructionYear;
            set { SetProperty(ref constructionYear, value); } // Set property with OnPropertyChanged notification
        }

        // Property for number of stars
        private int starsNumber;
        public int StarsNumber
        {
            get => starsNumber;
            set { SetProperty(ref starsNumber, value); } // Set property with OnPropertyChanged notification
        }

        // Property for owner JMBG
        private string ownerJmbg;
        public string OwnerJmbg
        {
            get => ownerJmbg;
            set { SetProperty(ref ownerJmbg, value); } // Set property with OnPropertyChanged notification
        }

        // Event for property changed
        public event PropertyChangedEventHandler PropertyChanged;

        // Method to invoke property changed event
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Method to set property and notify change
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        // Event handler for creating a hotel
        private void CreateHotel(object sender, RoutedEventArgs e)
        {
            // Create a new hotel object with provided data
            Hotel hotel = new Hotel
            {
                Code = Code,
                Name = NameHotel,
                ConstructionYear = ConstructionYear,
                StarsNumber = StarsNumber,
                JmbgOwner = OwnerJmbg,
                Accepted = false
            };

            hotelController.Create(hotel); // Add the hotel to the database through the controller

            // Show a message box indicating that the hotel needs to be approved by the owner
            MessageBox.Show("Your hotel has to be approved by the owner", "Hotel approval");

            Close(); // Close the window
        }
    }
}


