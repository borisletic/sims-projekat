using HotelBookingApp.Controller;
using HotelBookingApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;


namespace HotelBookingApp.View
{
    public partial class ApartmentFilterCondition : Window, INotifyPropertyChanged
    {
        public ObservableCollection<string> Apartments { get; } = new ObservableCollection<string>
        {
            "Room",
            "People",
            "Room and people"
        };

        private readonly ApartmentController apartmentController;

        private string selectedApartment;
        public string SelectedApartment
        {
            get => selectedApartment;
            set
            {
                selectedApartment = value;
                OnPropertyChanged();
            }
        }

        private string condition;
        public string Condition
        {
            get => condition;
            set
            {
                condition = value;
                OnPropertyChanged();
            }
        }

        public ApartmentFilterCondition()
        {
            InitializeComponent();
            DataContext = this;

            apartmentController = new ApartmentController();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            var apartments = new List<Apartment>();

            switch (SelectedApartment)
            {
                case "Room":
                    apartments = apartmentController.GetAll().Where(ap => ap.RoomNumber == Convert.ToInt32(Condition)).ToList();
                    break;
                case "People":
                    apartments = apartmentController.GetAll().Where(ap => ap.MaxGuestNumber == Convert.ToInt32(Condition)).ToList();
                    break;
                case "Room and people":
                    var conditions = Condition.Split(' ');
                    var roomNumber = Convert.ToInt32(conditions[0]);
                    var maxGuestNumber = Convert.ToInt32(conditions[2]);
                    apartments = conditions[1] == "&" ?
                        apartmentController.GetAll().Where(a => a.RoomNumber == roomNumber && a.MaxGuestNumber == maxGuestNumber).ToList() :
                        apartmentController.GetAll().Where(a => a.RoomNumber == roomNumber || a.MaxGuestNumber == maxGuestNumber).ToList();
                    break;
            }

            HotelView.Apartments.Clear();
            foreach (var apartment in apartments)
            {
                HotelView.Apartments.Add(apartment);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

