using System.Collections.Generic;


namespace HotelBookingApp.Model
{
    // Guest class inheriting from the User class
    public class Guest : User
    {
        // List of hotels associated with the guest
        public List<Hotel> Hotels { get; set; }

        // List of apartments associated with the guest
        public List<Apartment> Apartments { get; set; }

        // Default constructor initializing base User class and the lists
        public Guest() : base()
        {
            Hotels = new List<Hotel>();
            Apartments = new List<Apartment>();
        }

        // Override the ToCSV method to convert Guest data to a CSV string array
        public override string[] ToCSV()
        {
            // Currently, it just calls the base User's ToCSV method
            return base.ToCSV();
        }

        // Override the FromCSV method to populate Guest data from a CSV string array
        public override void FromCSV(string[] values)
        {
            // Currently, it just calls the base User's FromCSV method
            base.FromCSV(values);
        }
    }
}

