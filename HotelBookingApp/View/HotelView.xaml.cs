using HotelBookingApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using HotelBookingApp.Controller;

namespace HotelBookingApp.View
{
    public partial class HotelView : Window, INotifyPropertyChanged
    {
        // Event for property changed
        public event PropertyChangedEventHandler PropertyChanged;

        // Define controllers for hotels and apartments
        private readonly HotelController hotelController;
        private readonly ApartmentController apartmentController;

        // Define collection of apartments
        public static ObservableCollection<Apartment> Apartments { get; set; }

        // Define collection of hotels
        public ObservableCollection<string> Hotels { get; set; }

        // Property for selected hotel
        private string selectedHotel;
        public string SelectedHotel
        {
            get => selectedHotel;
            set
            {
                selectedHotel = value;
                // Open apartment filter condition window if "Apartments" is selected
                if (selectedHotel == "Apartments")
                {
                    var afc = new ApartmentFilterCondition();
                    afc.Show();
                }
            }
        }

        // Property for logged-in user
        public User LoggedUser { get; set; }

        // Constructor
        public HotelView(User user)
        {
            InitializeComponent(); // Initialize components
            DataContext = this; // Set data context to this view
            hotelController = new HotelController(); // Initialize hotel controller
            apartmentController = new ApartmentController(); // Initialize apartment controller

            // Load apartments from the database that belong to accepted hotels
            Apartments = new ObservableCollection<Apartment>(apartmentController.GetAll().Where(a => a.Hotel.Accepted));

            WindowStartupLocation = WindowStartupLocation.CenterScreen; // Set window startup location

            // Initialize collection of hotel filter options
            Hotels = new ObservableCollection<string>
            {
                "Code",
                "Name",
                "Construction year",
                "Number of stars",
                "Apartments"
            };

            LoggedUser = user; // Set logged-in user

            UpdateVisibility(); // Update visibility of UI elements based on user type
        }

        // Method to invoke property changed event
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Method to update visibility of UI elements based on user type
        private void UpdateVisibility()
        {
            switch (LoggedUser)
            {
                case Owner _:
                    ReservationButton.Visibility = Visibility.Visible;
                    CreateApartmentButton.Visibility = Visibility.Visible;
                    ApproveHotelButton.Visibility = Visibility.Visible;
                    AddHotelButton.Visibility = Visibility.Collapsed;
                    break;
                case Guest _:
                    ReservationButton.Visibility = Visibility.Collapsed;
                    CreateApartmentButton.Visibility = Visibility.Collapsed;
                    ApproveHotelButton.Visibility = Visibility.Collapsed;
                    AddHotelButton.Visibility = Visibility.Collapsed;
                    break;
                default:
                    ReservationButton.Visibility = Visibility.Collapsed;
                    CreateApartmentButton.Visibility = Visibility.Collapsed;
                    ApproveHotelButton.Visibility = Visibility.Collapsed;
                    AddHotelButton.Visibility = Visibility.Visible;
                    break;
            }
            OnPropertyChanged(nameof(Visibility)); // Notify property changed
        }

        // Event handler for sorting apartments by star
        private void SortByStar(object sender, RoutedEventArgs e)
        {
            var sortedApartments = apartmentController.GetAll().OrderBy(ap => ap.Hotel.StarsNumber).ToList();
            Apartments.Clear();
            foreach (var apartment in sortedApartments)
            {
                Apartments.Add(apartment);
            }
        }

        // Event handler for sorting apartments by name
        private void SortByName(object sender, RoutedEventArgs e)
        {
            var sortedApartments = apartmentController.GetAll().OrderBy(ap => ap.Hotel.Name).ToList();
            Apartments.Clear();
            foreach (var apartment in sortedApartments)
            {
                Apartments.Add(apartment);
            }
        }

        // Property for filter text
        public string Text { get; set; }

        // Event handler for filtering apartments
        private void Filter(object sender, RoutedEventArgs e)
        {
            List<Apartment> filteredApartments = new List<Apartment>();

            switch (SelectedHotel)
            {
                case "Code":
                    filteredApartments = apartmentController.GetAll().FindAll(ap => ap.Hotel.Code.ToLower().Contains(Text.ToLower()));
                    break;
                case "Name":
                    filteredApartments = apartmentController.GetAll().FindAll(ap => ap.Hotel.Name.ToLower().Contains(Text.ToLower()));
                    break;
                case "Construction year":
                    filteredApartments = apartmentController.GetAll().FindAll(ap => ap.Hotel.ConstructionYear.ToString().ToLower().Contains(Text));
                    break;
                case "Stars number":
                    filteredApartments = apartmentController.GetAll().FindAll(ap => ap.Hotel.StarsNumber == Convert.ToInt32(Text));
                    break;
                case "Apartments":
                    var afc = new ApartmentFilterCondition();
                    afc.Show();
                    break;
            }

            Apartments.Clear();
            foreach (var apartment in filteredApartments)
            {
                Apartments.Add(apartment);
            }
        }

        // Event handler for clearing filters
        private void Clear(object sender, RoutedEventArgs e)
        {
            Apartments.Clear();
            foreach (var apartment in apartmentController.GetAll())
            {
                Apartments.Add(apartment);
            }
            Text = "";
            OnPropertyChanged(nameof(Apartments));
            myTextBox.Text = "";
        }

        // Property for selected apartment
        public Apartment SelectedApartment { get; set; }

        // Event handler for apartment reservation
        private void ReservationApartment(object sender, MouseButtonEventArgs e)
        {
            if (LoggedUser is Guest)
            {
                var rav = new ReservationApartmentView(SelectedApartment);
                rav.Show();
            }
        }

        // Event handler for showing reservations (for owner)
        private void ShowReservations(object sender, RoutedEventArgs e)
        {
            var rfo = new ReservationsForOwner();
            rfo.Show();
        }

        // Event handler for creating a new apartment
        private void CreateApartment(object sender, RoutedEventArgs e)
        {
            var aev = new ApartmentEnterView();
            aev.Show();
        }

        // Event handler for adding a new hotel
        private void AddHotel(object sender, RoutedEventArgs e)
        {
            var hcv = new HotelCreateView();
            hcv.Show();
        }

        // Event handler for approving hotels
        private void ApproveHotel(object sender, RoutedEventArgs e)
        {
            var hat = new HotelApprovalTableView();
            hat.Show();
        }

        // Event handler for signing out
        private void SignOutButton(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show(
                "Are you sure you want to log out?",
                "Exit",
                MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                var main = new MainWindow();
                main.Show();
                Close();
            }
        }
    }
}


