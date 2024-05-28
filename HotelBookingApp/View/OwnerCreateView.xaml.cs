using HotelBookingApp.Model;
using System.Windows;
using HotelBookingApp.Controller;
using System.Linq;

namespace HotelBookingApp.View
{
    public partial class OwnerCreateView : Window
    {
        private readonly OwnerController ownerController;
        private readonly AdministratorController administratorController;
        private readonly GuestController guestController;

        public OwnerCreateView()
        {
            InitializeComponent();

            this.DataContext = this;

            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            ownerController = new OwnerController();
            administratorController = new AdministratorController();
            guestController = new GuestController();
        }

        public string JMBG { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string NameO { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }

        private void CreateOwner(object sender, RoutedEventArgs e)
        {
            // Check if the email or JMBG already exists
            var existingOwner = ownerController.GetAll().FirstOrDefault(o => o.Email == Email || o.Jmbg == JMBG);

            if (existingOwner != null)
            {
                MessageBox.Show("Try again. Email or JMBG already exists", "Alert");
                return;
            }

            // Create a new owner
            var owner = new Owner
            {
                Jmbg = JMBG,
                Email = Email,
                Password = Password,
                Name = NameO,
                Surname = Surname,
                PhoneNumber = PhoneNumber
            };

            ownerController.Create(owner);

            // Add the new owner to the Users collection in AllUsersView
            AllUsersView.Users.Add(owner);

            this.Close();
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
