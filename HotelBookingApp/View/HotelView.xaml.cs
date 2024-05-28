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
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly HotelController hotelController;
        private readonly ApartmentController apartmentController;

        public static ObservableCollection<Apartment> Apartments { get; set; }

        public ObservableCollection<string> Hotels { get; set; }

        private string selectedHotel;
        public string SelectedHotel
        {
            get => selectedHotel;
            set
            {
                selectedHotel = value;
                if (selectedHotel == "Apartments")
                {
                    var afc = new ApartmentFilterCondition();
                    afc.Show();
                }
            }
        }

        public User LoggedUser { get; set; }

        public HotelView(User user)
        {
            InitializeComponent();
            DataContext = this;
            hotelController = new HotelController();
            apartmentController = new ApartmentController();

            Apartments = new ObservableCollection<Apartment>(apartmentController.GetAll().Where(a => a.Hotel.Accepted));

            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            Hotels = new ObservableCollection<string>
            {
                "Code",
                "Name",
                "Construction year",
                "Number of stars",
                "Apartments"
            };

            LoggedUser = user;

            UpdateVisibility();
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

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
            OnPropertyChanged(nameof(Visibility));
        }

        private void SortByStar(object sender, RoutedEventArgs e)
        {
            var sortedApartments = apartmentController.GetAll().OrderBy(ap => ap.Hotel.StarsNumber).ToList();
            Apartments.Clear();
            foreach (var apartment in sortedApartments)
            {
                Apartments.Add(apartment);
            }
        }

        private void SortByName(object sender, RoutedEventArgs e)
        {
            var sortedApartments = apartmentController.GetAll().OrderBy(ap => ap.Hotel.Name).ToList();
            Apartments.Clear();
            foreach (var apartment in sortedApartments)
            {
                Apartments.Add(apartment);
            }
        }

        public string Text { get; set; }

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

        public Apartment SelectedApartment { get; set; }

        private void ReservationApartment(object sender, MouseButtonEventArgs e)
        {
            if (LoggedUser is Guest)
            {
                var rav = new ReservationApartmentView(SelectedApartment);
                rav.Show();
            }
        }

        private void ShowReservations(object sender, RoutedEventArgs e)
        {
            var rfo = new ReservationsForOwner();
            rfo.Show();
        }

        private void CreateApartment(object sender, RoutedEventArgs e)
        {
            var aev = new ApartmentEnterView();
            aev.Show();
        }

        private void AddHotel(object sender, RoutedEventArgs e)
        {
            var hcv = new HotelCreateView();
            hcv.Show();
        }

        private void ApproveHotel(object sender, RoutedEventArgs e)
        {
            var hat = new HotelApprovalTableView();
            hat.Show();
        }

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

