using System.Collections.Generic;


namespace HotelBookingApp.Model
{
    // Administrator class inheriting from the User class
    public class Administrator : User
    {
        // List of hotels managed by the administrator
        public List<Hotel> Hotels { get; set; }

        // List of users managed by the administrator
        public List<User> Users { get; set; }

        // Default constructor initializing base User class and the lists
        public Administrator() : base()
        {
            Hotels = new List<Hotel>();
            Users = new List<User>();
        }

        // Override the ToCSV method to convert Administrator data to a CSV string array
        public override string[] ToCSV()
        {
            // Currently, it just calls the base User's ToCSV method
            return base.ToCSV();
        }

        // Override the FromCSV method to populate Administrator data from a CSV string array
        public override void FromCSV(string[] values)
        {
            
            base.FromCSV(values);
        }
    }
}

