﻿using HotelBookingApp.Controller;
using HotelBookingApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;


namespace HotelBookingApp.View
{
    
    public partial class ApartmentFilterCondition : Window, INotifyPropertyChanged
    {
        public ObservableCollection<string> Apartments { get; set; }

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

        private readonly ApartmentController apartmentController;

        public ApartmentFilterCondition()
        {
            InitializeComponent();

            this.DataContext = this;

            
            apartmentController = new ApartmentController();

            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            Apartments = new ObservableCollection<string>
            {
                "Room",
                "People",
                "Room and people"
            };
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

        

        private void Search(object sender, RoutedEventArgs e)
        {
            List<Apartment> apartments = new List<Apartment>();

            if (SelectedApartment == "Room")
            {
                apartments = apartmentController.GetAll().FindAll(ap => ap.RoomNumber == Convert.ToInt32(Condition));
            }

            else if (SelectedApartment == "People")
            {
                apartments = apartmentController.GetAll().FindAll(ap => ap.MaxGuestNumber == Convert.ToInt32(Condition));
            }

            else
            {
                string[] conditions = Condition.Split(' ');

                if (conditions[1] == "&")
                {
                    apartments = apartmentController.GetAll().FindAll(a => a.RoomNumber == Convert.ToInt32(conditions[0]) && a.MaxGuestNumber == Convert.ToInt32(conditions[2]));
                }

                else
                {
                    apartments = apartmentController.GetAll().FindAll(a => a.RoomNumber == Convert.ToInt32(conditions[0]) || a.MaxGuestNumber == Convert.ToInt32(conditions[2]));
                }

            }

            HotelView.Apartments.Clear();

            foreach (Apartment apart in apartments)
            {
                HotelView.Apartments.Add(apart);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
