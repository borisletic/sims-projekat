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
        // Define collection of filter conditions
        public ObservableCollection<string> Apartments { get; } = new ObservableCollection<string>
        {
            "Room",
            "People",
            "Room and people"
        };

        // Define controller for apartments
        private readonly ApartmentController apartmentController;

        // Define properties for selected filter condition and search condition
        private string selectedApartment;
        public string SelectedApartment
        {
            get => selectedApartment;
            set
            {
                selectedApartment = value;
                OnPropertyChanged(); // Notify property changed
            }
        }

        private string condition;
        public string Condition
        {
            get => condition;
            set
            {
                condition = value;
                OnPropertyChanged(); // Notify property changed
            }
        }

        // Constructor
        public ApartmentFilterCondition()
        {
            InitializeComponent();
            DataContext = this; // Set data context to this view

            apartmentController = new ApartmentController(); // Initialize apartment controller
            WindowStartupLocation = WindowStartupLocation.CenterScreen; // Set window startup location
        }

        // Event handler for searching apartments based on filter conditions
        private void Search(object sender, RoutedEventArgs e)
        {
            var apartments = new List<Apartment>(); // Initialize list to store filtered apartments

            // Switch based on selected filter condition
            switch (SelectedApartment)
            {
                case "Room":
                    apartments = apartmentController.GetAll().Where(ap => ap.RoomNumber == Convert.ToInt32(Condition)).ToList(); // Filter apartments by room number
                    break;
                case "People":
                    apartments = apartmentController.GetAll().Where(ap => ap.MaxGuestNumber == Convert.ToInt32(Condition)).ToList(); // Filter apartments by maximum guest number
                    break;
                case "Room and people":
                    var conditions = Condition.Split(' '); // Split the condition string into parts
                    var roomNumber = Convert.ToInt32(conditions[0]); // Extract room number
                    var maxGuestNumber = Convert.ToInt32(conditions[2]); // Extract maximum guest number
                    apartments = conditions[1] == "&" ?
                        apartmentController.GetAll().Where(a => a.RoomNumber == roomNumber && a.MaxGuestNumber == maxGuestNumber).ToList() :
                        apartmentController.GetAll().Where(a => a.RoomNumber == roomNumber || a.MaxGuestNumber == maxGuestNumber).ToList(); // Filter apartments based on room and guest number combination
                    break;
            }

            // Update the list of apartments in the HotelView
            HotelView.Apartments.Clear();
            foreach (var apartment in apartments)
            {
                HotelView.Apartments.Add(apartment);
            }
        }

        // Event to handle property changed
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); // Invoke property changed event
        }
    }
}


