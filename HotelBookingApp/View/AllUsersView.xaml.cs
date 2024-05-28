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
        public static ObservableCollection<User> Users { get; set; }
        private readonly OwnerController ownerController;
        private readonly AdministratorController administratorController;
        private readonly GuestController guestController;

        private string selectedUser;
        public string SelectedUser
        {
            get => selectedUser;
            set => selectedUser = value;
        }

        public ObservableCollection<string> UserType { get; set; }
        public User ChosenUser { get; set; }

        public AllUsersView()
        {
            InitializeComponent();
            DataContext = this;

            ownerController = new OwnerController();
            administratorController = new AdministratorController();
            guestController = new GuestController();

            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            InitializeData();
        }

        private void InitializeData()
        {
            Users = new ObservableCollection<User>();
            LoadUsers();
            UserType = new ObservableCollection<string> { "Guest", "Owner" };
        }

        private void LoadUsers()
        {
            Users.Clear();
            Users.AddRange(ownerController.GetAll());
            Users.AddRange(administratorController.GetAll());
            Users.AddRange(guestController.GetAll());
        }

        private void CreateOwnerClick(object sender, RoutedEventArgs e)
        {
            new OwnerCreateView().Show();
        }

        private void HotelsClick(object sender, RoutedEventArgs e)
        {
            new HotelView(MainWindow.LogInUser).Show();
            Close();
        }

        private void FilterClick(object sender, RoutedEventArgs e)
        {
            Users.Clear();
            if (SelectedUser == "Owner")
                Users.AddRange(ownerController.GetAll());
            else if (SelectedUser == "Guest")
                Users.AddRange(guestController.GetAll());
        }

        private void ClearClick(object sender, RoutedEventArgs e)
        {
            LoadUsers();
            myTextBox.Text = string.Empty;
        }

        private void SortByName(object sender, RoutedEventArgs e)
        {
            SortUsers(u => u.Name);
        }

        private void SortBySurname(object sender, RoutedEventArgs e)
        {
            SortUsers(u => u.Surname);
        }

        private void SortByNameReversed(object sender, RoutedEventArgs e)
        {
            SortUsers(u => u.Name, true);
        }

        private void SortBySurnameReversed(object sender, RoutedEventArgs e)
        {
            SortUsers(u => u.Surname, true);
        }

        private void SortUsers(Func<User, string> keySelector, bool descending = false)
        {
            var users = new List<User>();
            users.AddRange(ownerController.GetAll());
            users.AddRange(administratorController.GetAll());
            users.AddRange(guestController.GetAll());

            Users.Clear();
            var sortedUsers = descending ? users.OrderByDescending(keySelector) : users.OrderBy(keySelector);
            Users.AddRange(sortedUsers);
        }

        private void Block(object sender, RoutedEventArgs e)
        {
            if (ChosenUser == null) return;
            if (ChosenUser.Blocked)
            {
                MessageBox.Show("This user is already blocked.", "User Blocked");
                return;
            }

            ChosenUser.Blocked = true;
            UpdateUser(ChosenUser);
            ClearClick(sender, e);
        }

        private void Unblock(object sender, RoutedEventArgs e)
        {
            if (ChosenUser == null) return;
            if (!ChosenUser.Blocked)
            {
                MessageBox.Show("This user has not been blocked.", "User Unblocked");
                return;
            }

            ChosenUser.Blocked = false;
            UpdateUser(ChosenUser);
            ClearClick(sender, e);
        }

        private void UpdateUser(User user)
        {
            switch (user)
            {
                case Guest guest:
                    guestController.Update(guest);
                    break;
                case Owner owner:
                    ownerController.Update(owner);
                    break;
                case Administrator admin:
                    administratorController.Update(admin);
                    break;
            }
        }
    }

    public static class ObservableCollectionExtensions
    {
        public static void AddRange<T>(this ObservableCollection<T> collection, IEnumerable<T> items)
        {
            foreach (var item in items)
                collection.Add(item);
        }
    }
}

