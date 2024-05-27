using HotelBookingApp.Controller;
using HotelBookingApp.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;


namespace HotelBookingApp.View
{

    public partial class HotelCreateView : Window, INotifyPropertyChanged
    {

        private readonly HotelController hotelController;

        public HotelCreateView()
        {
            InitializeComponent();

            this.DataContext = this;

            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            
            hotelController = new HotelController();
        }

        private string code;
        public string Code
        {
            get => code;

            set
            {
                if (value != code)
                {
                    code = value;

                    OnPropertyChanged();
                }
            }
        }

        private string name;
        public string NameHotel
        {
            get => name;

            set
            {
                if (value != name)
                {
                    name = value;

                    OnPropertyChanged();
                }
            }
        }

        private int constructionYear;
        public int ConstructionYear
        {
            get => constructionYear;

            set
            {
                if (value != constructionYear)
                {
                    constructionYear = value;

                    OnPropertyChanged();
                }
            }
        }

        private int starsNumber;
        public int StarsNumber
        {
            get => starsNumber;

            set
            {
                if (value != starsNumber)
                {
                    starsNumber = value;

                    OnPropertyChanged();
                }
            }
        }

        private string ownerJmbg;
        public string OwnerJmbg
        {
            get => ownerJmbg;

            set
            {
                if (value != ownerJmbg)
                {
                    ownerJmbg = value;

                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void CreateHotel(object sender, RoutedEventArgs e)
        {
            Hotel hotel = new Hotel
            {
                Code = Code,
                Name = NameHotel,
                ConstructionYear = ConstructionYear,
                StarsNumber = StarsNumber,
                JmbgOwner = OwnerJmbg,
                Accepted = false
            };

            hotelController.Create(hotel);

            MessageBox.Show("Your hotel has to be approved by the owner", "Hotel approval");

            this.Close();
        }

    }
}
