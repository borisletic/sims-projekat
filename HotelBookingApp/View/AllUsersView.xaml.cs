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

            set
            {
                selectedUser = value;
            }
        }

        public AllUsersView()
        {
            InitializeComponent();

            this.DataContext = this;

            
            ownerController = new OwnerController();
            administratorController = new AdministratorController();
            guestController = new GuestController();

            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            Init();
        }

        private void Init()
        {
            Users = new ObservableCollection<User>();

            foreach (var user in ownerController.GetAll())
            {
                Users.Add(user);
            }

            foreach (var user in administratorController.GetAll())
            {
                Users.Add(user);
            }

            foreach (var user in guestController.GetAll())
            {
                Users.Add(user);
            }

            UserType = new ObservableCollection<string>
            {
                "Guest",
                "Owner"
            };
        }

        private void CreateOwnerClick(object sender, RoutedEventArgs e)
        {
            OwnerCreateView owner = new OwnerCreateView();

            owner.Show();
        }

        private void HotelsClick(object sender, RoutedEventArgs e)
        {
            HotelView hotel = new HotelView(MainWindow.LogInUser);

            hotel.Show();

            this.Close();
        }

        public ObservableCollection<string> UserType { get; set; }

        private void FilterClick(object sender, RoutedEventArgs e)
        {
            if (SelectedUser == "Owner")
            {
                Users.Clear();

                foreach (var user in ownerController.GetAll())
                {
                    Users.Add(user);
                }
            }
            else if (SelectedUser == "Guest")
            {
                Users.Clear();

                foreach (var user in guestController.GetAll())
                {
                    Users.Add(user);
                }
            }
        }

        private void ClearClick(object sender, RoutedEventArgs e)
        {
            Users.Clear();

            foreach (var user in ownerController.GetAll())
            {
                Users.Add(user);
            }

            foreach (var user in administratorController.GetAll())
            {
                Users.Add(user);
            }

            foreach (var user in guestController.GetAll())
            {
                Users.Add(user);
            }

            myTextBox.Text = "";
        }

        private void SortByName(object sender, RoutedEventArgs e)
        {
            List<User> users = new List<User>();

            users.AddRange(ownerController.GetAll());
            users.AddRange(administratorController.GetAll());
            users.AddRange(guestController.GetAll());

            Users.Clear();

            foreach (var user in users.OrderBy(user => user.Name).ToList())
            {
                Users.Add(user);
            }
        }

        private void SortBySurname(object sender, RoutedEventArgs e)
        {
            List<User> users = new List<User>();

            users.AddRange(ownerController.GetAll());
            users.AddRange(administratorController.GetAll());
            users.AddRange(guestController.GetAll());

            Users.Clear();

            foreach (var user in users.OrderBy(user => user.Surname).ToList())
            {
                Users.Add(user);
            }
        }

        public User ChosenUser { get; set; }

        private void Block(object sender, RoutedEventArgs e)
        {
            if (ChosenUser == null)
            {
                return;
            }

            if (ChosenUser.Blocked)
            {
                MessageBox.Show("This user is already blocked.", "User Blocked");

                return;
            }

            ChosenUser.Blocked = true;

            if (ChosenUser is Guest)
            {
                guestController.Update((Guest)ChosenUser);
            }

            else if (ChosenUser is Owner)
            {
                ownerController.Update((Owner)ChosenUser);
            }

            else
            {
                administratorController.Update((Administrator)ChosenUser);
            }

            ClearClick(sender, e);
        }

        private void Unblock(object sender, RoutedEventArgs e)
        {
            if (ChosenUser == null)
            {
                return;
            }

            if (!ChosenUser.Blocked)
            {
                MessageBox.Show("This user has not been blocked.", "User Unblocked");

                return;
            }

            ChosenUser.Blocked = false;

            if (ChosenUser is Guest)
            {
                guestController.Update((Guest)ChosenUser);
            }

            else if (ChosenUser is Owner)
            {
                ownerController.Update((Owner)ChosenUser);
            }

            else
            {
                administratorController.Update((Administrator)ChosenUser);
            }

            ClearClick(sender, e);
        }

        private void SortByNameReversed(object sender, RoutedEventArgs e)
        {
            List<User> users = new List<User>();

            users.AddRange(ownerController.GetAll());
            users.AddRange(administratorController.GetAll());
            users.AddRange(guestController.GetAll());

            Users.Clear();

            foreach (var user in users.OrderByDescending(user => user.Name).ToList())
            {
                Users.Add(user);
            }
        }

        private void SortBySurnameReversed(object sender, RoutedEventArgs e)
        {
            List<User> users = new List<User>();

            users.AddRange(ownerController.GetAll());
            users.AddRange(administratorController.GetAll());
            users.AddRange(guestController.GetAll());

            Users.Clear();

            foreach (var user in users.OrderByDescending(user => user.Surname).ToList())
            {
                Users.Add(user);
            }
        }

    }
}
