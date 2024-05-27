using HotelBookingApp.Controller;
using HotelBookingApp.Model;
using HotelBookingApp.Repository;
using HotelBookingApp.View;
using System.Text.RegularExpressions;
using System.Windows;


namespace HotelBookingApp
{

    public partial class MainWindow : Window
    {

        private readonly OwnerController _ownerController;
        private readonly GuestController _guestController;
        private readonly AdministratorController _administratorController;

        public static User LogInUser { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        private int failureNumber = 0;

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;

            
            _ownerController = new OwnerController();
            _guestController = new GuestController();
            _administratorController = new AdministratorController();

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void LogIn(object sender, RoutedEventArgs e)
        {
            Email = emailBox.Text;
            Password = passwordBox.Password;

            bool isEmailValid = ValidateEmail(Email);
            bool isPasswordValid = ValidatePassword(Password);
            bool isValid = isEmailValid && isPasswordValid;

            if (!isValid)
            {
                emailErrorText.Text = "Invalid email or password format";

                emailErrorText.Visibility = Visibility.Visible;

                failureNumber++;

                if (failureNumber >= 3)
                {
                    MessageBox.Show("Three failed attempts. Closing the program.", "Error");

                    Close();

                    return;
                }
            }
            else
            {
                emailErrorText.Visibility = Visibility.Collapsed;
            }

            if (isValid)
            {
                LogInUser = _ownerController.GetByEmailAndPassword(Email, Password);

                if (LogInUser != null)
                {
                    if (LogInUser.Blocked)
                    {
                        MessageBox.Show("User is blocked", "Warning!");

                        return;
                    }

                    HotelView hv = new HotelView(LogInUser);

                    hv.Show();

                    Close();

                    return;
                }

                LogInUser = _guestController.GetByEmailAndPassword(Email, Password);

                if (LogInUser != null)
                {
                    if (LogInUser.Blocked)
                    {
                        MessageBox.Show("User is blocked", "Warning!");

                        return;
                    }

                    HotelView hv = new HotelView(LogInUser);

                    hv.Show();

                    Close();

                    return;
                }

                LogInUser = _administratorController.GetByEmailAndPassword(Email, Password);

                if (LogInUser != null)
                {
                    if (LogInUser.Blocked)
                    {
                        MessageBox.Show("User is blocked", "Warning!");
                        return;
                    }

                    AllUsersView auv = new AllUsersView();

                    auv.Show();

                    Close();

                    return;
                }
            }
        }

        private void ApartmentView(object sender, RoutedEventArgs e)
        {
            Guest guest = GuestRepository.GetInstance().Get(0);
        }

        private void HotelView(object sender, RoutedEventArgs e)
        {
            Guest guest = GuestRepository.GetInstance().Get(0);

            HotelView hv = new HotelView(guest);

            hv.Show();
        }

        private bool ValidatePassword(string password)
        {
            return password.Length >= 3;
        }

        bool ValidateEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";

            Regex regex = new Regex(pattern);

            return regex.IsMatch(email);
        }



    }
}
