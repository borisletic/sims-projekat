using HotelBookingApp.Model;
using System.Windows;
using HotelBookingApp.Controller;
using System.Linq;

namespace HotelBookingApp.View
{
    public partial class OwnerCreateView : Window
    {
        // Define controllers for owner, administrator, and guest
        private readonly OwnerController ownerController;
        private readonly AdministratorController administratorController;
        private readonly GuestController guestController;

        // Constructor
        public OwnerCreateView()
        {
            InitializeComponent(); // Initialize components

            this.DataContext = this; // Set data context to this view

            WindowStartupLocation = WindowStartupLocation.CenterScreen; // Set window startup location

            // Initialize controllers
            ownerController = new OwnerController();
            administratorController = new AdministratorController();
            guestController = new GuestController();
        }

        // Properties for owner details
        public string JMBG { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string NameO { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }

        // Event handler for creating a new owner
        private void CreateOwner(object sender, RoutedEventArgs e)
        {
            // Check if the email or JMBG already exists
            var existingOwner = ownerController.GetAll().FirstOrDefault(o => o.Email == Email || o.Jmbg == JMBG);

            if (existingOwner != null)
            {
                MessageBox.Show("Try again. Email or JMBG already exists", "Alert"); // Show error message if owner already exists
                return;
            }

            // Create a new owner object
            var owner = new Owner
            {
                Jmbg = JMBG,
                Email = Email,
                Password = Password,
                Name = NameO,
                Surname = Surname,
                PhoneNumber = PhoneNumber
            };

            ownerController.Create(owner); // Add the new owner to the database through the controller

            // Add the new owner to the Users collection in AllUsersView
            AllUsersView.Users.Add(owner);

            this.Close(); // Close the window
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            // Not used, you can remove this method if not needed
        }
    }
}

