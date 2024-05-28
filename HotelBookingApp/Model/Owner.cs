using System.Collections.Generic;


namespace HotelBookingApp.Model
{
    // Owner class inheriting from the User class
    public class Owner : User
    {
        // List of hotels owned by the owner
        public List<Hotel> Hotels { get; set; }

        // List of apartments owned by the owner
        public List<Apartment> Apartments { get; set; }

        // Default constructor initializing base User class and the lists
        public Owner() : base()
        {
            Hotels = new List<Hotel>();
            Apartments = new List<Apartment>();
        }

        // Override the ToCSV method to convert Owner data to a CSV string array
        public override string[] ToCSV()
        {
            // Currently, it just calls the base User's ToCSV method
            return base.ToCSV();
        }

        // Override the FromCSV method to populate Owner data from a CSV string array
        public override void FromCSV(string[] values)
        {
            // Currently, it just calls the base User's FromCSV method
            base.FromCSV(values);
        }
    }
}


