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

        public ObservableCollection<String> Hotels { get; set; }

        private String selectedHotel;
        public String SelectedHotel
        {
            get => selectedHotel;

            set
            {
                selectedHotel = value;

                if (selectedHotel == "Apartments")
                {
                    ApartmentFilterCondition ac = new ApartmentFilterCondition();

                    ac.Show();
                }
            }
        }

        public User LoggedUser { get; set; }
        public HotelView(User user)
        {
            InitializeComponent();

            this.DataContext = this;

            hotelController = new HotelController();
            apartmentController = new ApartmentController();

            Apartments = new ObservableCollection<Apartment>(apartmentController.GetAll().Where(a => a.Hotel.Accepted));

            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            Hotels = new ObservableCollection<String>();

            Hotels.Add("Code");
            Hotels.Add("Name");
            Hotels.Add("Construction year");
            Hotels.Add("Number of stars");
            Hotels.Add("Apartments");

            LoggedUser = user;

            if (LoggedUser is Owner)
            {
                ReservationButton.Visibility = Visibility.Visible;

                CreateApartmentButton.Visibility = Visibility.Visible;

                ApproveHotelButton.Visibility = Visibility.Visible;

                AddHotelButton.Visibility = Visibility.Collapsed;
            }
            else if (LoggedUser is Guest)
            {
                ReservationButton.Visibility = Visibility.Collapsed;

                CreateApartmentButton.Visibility = Visibility.Collapsed;

                ApproveHotelButton.Visibility = Visibility.Collapsed;

                AddHotelButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                ReservationButton.Visibility = Visibility.Collapsed;

                CreateApartmentButton.Visibility = Visibility.Collapsed;

                ApproveHotelButton.Visibility = Visibility.Collapsed;

                AddHotelButton.Visibility = Visibility.Visible;
            }

            OnPropertyChanged(nameof(Visibility));
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void SortByStar(object sender, RoutedEventArgs e)
        {
            var a = apartmentController.GetAll().OrderBy(ap => ap.Hotel.StarsNumber);

            Apartments.Clear();

            foreach (var apartment in a)
            {
                Apartments.Add(apartment);
            }

            OnPropertyChanged(nameof(Apartments));
        }

        private void SortByName(object sender, RoutedEventArgs e)
        {
            var a = apartmentController.GetAll().OrderBy(ap => ap.Hotel.Name);

            Apartments.Clear();

            foreach (var apartment in a)
            {
                Apartments.Add(apartment);
            }

            OnPropertyChanged(nameof(Apartments));
        }

        public String text;
        public String Text
        {
            get => text;

            set
            {
                text = value;
            }
        }

        private void Filter(object sender, RoutedEventArgs e)
        {
            List<Apartment> a = new List<Apartment>();

            if (SelectedHotel == "Code")
            {
                a = apartmentController.GetAll().FindAll(ap => ap.Hotel.Code.ToLower().Contains(Text.ToLower()));
            }

            else if (SelectedHotel == "Name")
            {
                a = apartmentController.GetAll().FindAll(ap => ap.Hotel.Name.ToLower().Contains(Text.ToLower()));
            }

            else if (SelectedHotel == "Construction year")
            {
                a = apartmentController.GetAll().FindAll(ap => ap.Hotel.ConstructionYear.ToString().ToLower().Contains(Text));
            }

            else if (SelectedHotel == "Stars number")
            {
                a = apartmentController.GetAll().FindAll(ap => ap.Hotel.StarsNumber == Convert.ToInt32(Text));
            }

            else if (SelectedHotel == "Apartments")
            {
                ApartmentFilterCondition ac = new ApartmentFilterCondition();

                ac.Show();
            }

            Apartments.Clear();

            foreach (var apartment in a)
            {
                Apartments.Add(apartment);
            }

            OnPropertyChanged(nameof(Apartments));
        }
        private void Clear(object sender, RoutedEventArgs e)
        {
            Apartments.Clear();

            foreach (var apartment in apartmentController.GetAll())
            {
                Apartments.Add(apartment);
            }

            OnPropertyChanged(nameof(Apartments));

            myTextBox.Text = "";
        }

        private Apartment selectedApartment;

        public Apartment SelectedApartment
        {
            get => selectedApartment;

            set
            {
                selectedApartment = value;
            }
        }

        private void ReservationApartment(object sender, MouseButtonEventArgs e)
        {

            if (LoggedUser is Guest)
            {
                ReservationApartmentView rav = new ReservationApartmentView(SelectedApartment);

                rav.Show();
            }
        }

        private void ShowReservations(object sender, RoutedEventArgs e)
        {
            ReservationsForOwner rfo = new ReservationsForOwner();

            rfo.Show();
        }

        private void CreateApartment(object sender, RoutedEventArgs e)
        {
            ApartmentEnterView a = new ApartmentEnterView();

            a.Show();
        }

        private void SignOutButton(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                 "   Are you sure you want to log out?\n\n",
                 "Exit",
                 MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                MainWindow main = new MainWindow();

                main.Show();

                this.Close();
            }

            else
            {
                return;
            }

        }

        private void AddHotel(object sender, RoutedEventArgs e)
        {
            HotelCreateView hcv = new HotelCreateView();

            hcv.Show();
        }

        private void ApproveHotel(object sender, RoutedEventArgs e)
        {
            HotelApprovalTableView hatv = new HotelApprovalTableView();
            hatv.Show();
        }
    }
}
