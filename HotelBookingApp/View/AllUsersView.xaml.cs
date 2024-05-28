using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using HotelBookingApp.Controller;
using HotelBookingApp.Model;


namespace HotelBookingApp.View
{
    public partial class AllUsersView : Window
    {
        // Define properties and controllers
        public static ObservableCollection<User> Users { get; set; } // Collection of users
        private readonly OwnerController ownerController; // Controller for owner users
        private readonly AdministratorController administratorController; // Controller for administrator users
        private readonly GuestController guestController; // Controller for guest users

        private string selectedUser; // Currently selected user type
        public string SelectedUser
        {
            get => selectedUser;
            set => selectedUser = value;
        }

        public ObservableCollection<string> UserType { get; set; } // Collection of user types
        public User ChosenUser { get; set; } // Currently chosen user

        // Constructor
        public AllUsersView()
        {
            InitializeComponent();
            DataContext = this; // Set the data context to this view

            // Initialize controllers
            ownerController = new OwnerController();
            administratorController = new AdministratorController();
            guestController = new GuestController();

            WindowStartupLocation = WindowStartupLocation.CenterScreen; // Set window startup location

            InitializeData(); // Initialize data for the view
        }

        // Initialize data for the view
        private void InitializeData()
        {
            Users = new ObservableCollection<User>(); // Initialize the collection of users
            LoadUsers(); // Load users from controllers
            UserType = new ObservableCollection<string> { "Guest", "Owner" }; // Initialize user types
        }

        // Load users from controllers
        private void LoadUsers()
        {
            Users.Clear(); // Clear the existing users
            Users.AddRange(ownerController.GetAll()); // Add owner users
            Users.AddRange(administratorController.GetAll()); // Add administrator users
            Users.AddRange(guestController.GetAll()); // Add guest users
        }

        // Event handler for creating a new owner user
        private void CreateOwnerClick(object sender, RoutedEventArgs e)
        {
            new OwnerCreateView().Show(); // Show the owner creation view
        }

        // Event handler for viewing hotels
        private void HotelsClick(object sender, RoutedEventArgs e)
        {
            new HotelView(MainWindow.LogInUser).Show(); // Show the hotel view
            Close(); // Close this view
        }

        // Event handler for filtering users by type
        private void FilterClick(object sender, RoutedEventArgs e)
        {
            Users.Clear(); // Clear existing users
            if (SelectedUser == "Owner")
                Users.AddRange(ownerController.GetAll()); // Add owner users
            else if (SelectedUser == "Guest")
                Users.AddRange(guestController.GetAll()); // Add guest users
        }

        // Event handler for clearing filters
        private void ClearClick(object sender, RoutedEventArgs e)
        {
            LoadUsers(); // Reload all users
            myTextBox.Text = string.Empty; // Clear text box
        }

        // Event handler for sorting users by name
        private void SortByName(object sender, RoutedEventArgs e)
        {
            SortUsers(u => u.Name); // Sort users by name
        }

        // Event handler for sorting users by surname
        private void SortBySurname(object sender, RoutedEventArgs e)
        {
            SortUsers(u => u.Surname); // Sort users by surname
        }

        // Event handler for sorting users by name in reverse order
        private void SortByNameReversed(object sender, RoutedEventArgs e)
        {
            SortUsers(u => u.Name, true); // Sort users by name in reverse order
        }

        // Event handler for sorting users by surname in reverse order
        private void SortBySurnameReversed(object sender, RoutedEventArgs e)
        {
            SortUsers(u => u.Surname, true); // Sort users by surname in reverse order
        }

        // Method to sort users based on a key selector and order
        private void SortUsers(Func<User, string> keySelector, bool descending = false)
        {
            var users = new List<User>(); // Create a list of users
            users.AddRange(ownerController.GetAll()); // Add owner users
            users.AddRange(administratorController.GetAll()); // Add administrator users
            users.AddRange(guestController.GetAll()); // Add guest users

            Users.Clear(); // Clear existing users
            var sortedUsers = descending ? users.OrderByDescending(keySelector) : users.OrderBy(keySelector); // Sort users
            Users.AddRange(sortedUsers); // Add sorted users to collection
        }

        // Event handler for blocking a user
        private void Block(object sender, RoutedEventArgs e)
        {
            if (ChosenUser == null) return; // If no user is chosen, return
            if (ChosenUser.Blocked)
            {
                MessageBox.Show("This user is already blocked.", "User Blocked"); // Show message if user is already blocked
                return;
            }

            ChosenUser.Blocked = true; // Block the user
            UpdateUser(ChosenUser); // Update user in the database
            ClearClick(sender, e); // Clear filters
        }

        // Event handler for unblocking a user
        private void Unblock(object sender, RoutedEventArgs e)
        {
            if (ChosenUser == null) return; // If no user is chosen, return
            if (!ChosenUser.Blocked)
            {
                MessageBox.Show("This user has not been blocked.", "User Unblocked"); // Show message if user is not blocked
                return;
            }

            ChosenUser.Blocked = false; // Unblock the user
            UpdateUser(ChosenUser); // Update user in the database
            ClearClick(sender, e); // Clear filters
        }

        // Update user in the respective controller
        private void UpdateUser(User user)
        {
            switch (user)
            {
                case Guest guest:
                    guestController.Update(guest); // Update guest user
                    break;
                case Owner owner:
                    ownerController.Update(owner); // Update owner user
                    break;
                case Administrator admin:
                    administratorController.Update(admin); // Update administrator user
                    break;
            }
        }
    }

    // Extension method for adding a range of items to an ObservableCollection
    public static class ObservableCollectionExtensions
    {
        public static void AddRange<T>(this ObservableCollection<T> collection, IEnumerable<T> items)
        {
            foreach (var item in items)
                collection.Add(item); // Add each item to the collection
        }
    }
}


