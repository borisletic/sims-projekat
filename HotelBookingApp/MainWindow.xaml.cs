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
        // Controller instances for different types of users
        private readonly OwnerController _ownerController;
        private readonly GuestController _guestController;
        private readonly AdministratorController _administratorController;

        // Static property to store the currently logged-in user
        public static User LogInUser { get; set; }

        // Properties for user input (email and password)
        public string Email { get; set; }
        public string Password { get; set; }

        // Counter to track login failure attempts
        private int failureNumber = 0;

        // Constructor
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this; // Set data context to this window

            // Initialize controller instances
            _ownerController = new OwnerController();
            _guestController = new GuestController();
            _administratorController = new AdministratorController();

            WindowStartupLocation = WindowStartupLocation.CenterScreen; // Set window startup location
        }

        // Event handler for login button click
        private void LogIn(object sender, RoutedEventArgs e)
        {
            Email = emailBox.Text; // Get email from the email text box
            Password = passwordBox.Password; // Get password from the password text box

            // Validate email and password format
            bool isEmailValid = ValidateEmail(Email);
            bool isPasswordValid = ValidatePassword(Password);
            bool isValid = isEmailValid && isPasswordValid;

            // If email or password is invalid, show error message
            if (!isValid)
            {
                emailErrorText.Text = "Invalid email or password format";
                emailErrorText.Visibility = Visibility.Visible;
                failureNumber++;

                // If there are three or more failed attempts, close the program
                if (failureNumber >= 3)
                {
                    MessageBox.Show("Three failed attempts. Closing the program.", "Error");
                    Close();
                    return;
                }
            }
            else
            {
                emailErrorText.Visibility = Visibility.Collapsed; // Hide error message
            }

            // If email and password are valid, attempt login
            if (isValid)
            {
                // Attempt login for owner user
                LogInUser = _ownerController.GetByEmailAndPassword(Email, Password);
                if (LogInUser != null)
                {
                    if (LogInUser.Blocked)
                    {
                        MessageBox.Show("User is blocked", "Warning!");
                        return;
                    }
                    OpenHotelView(LogInUser); // Open HotelView for owner user
                    return;
                }

                // Attempt login for guest user
                LogInUser = _guestController.GetByEmailAndPassword(Email, Password);
                if (LogInUser != null)
                {
                    if (LogInUser.Blocked)
                    {
                        MessageBox.Show("User is blocked", "Warning!");
                        return;
                    }
                    OpenHotelView(LogInUser); // Open HotelView for guest user
                    return;
                }

                // Attempt login for administrator user
                LogInUser = _administratorController.GetByEmailAndPassword(Email, Password);
                if (LogInUser != null)
                {
                    if (LogInUser.Blocked)
                    {
                        MessageBox.Show("User is blocked", "Warning!");
                        return;
                    }
                    OpenAllUsersView(); // Open AllUsersView for administrator user
                    return;
                }
            }
        }

        // Method to open HotelView
        private void OpenHotelView(User user)
        {
            HotelView hv = new HotelView(user);
            hv.Show();
            Close();
        }

        // Method to open AllUsersView
        private void OpenAllUsersView()
        {
            AllUsersView auv = new AllUsersView();
            auv.Show();
            Close();
        }

        // Method to validate password format
        private bool ValidatePassword(string password)
        {
            return password.Length >= 3;
        }

        // Method to validate email format using regex
        private bool ValidateEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }
    }
}

