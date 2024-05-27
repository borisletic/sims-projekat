using System.Collections.Generic;


namespace HotelBookingApp.Model
{
    public class Administrator : User
    {
        public List<Hotel> Hotels { get; set; }
        public List<User> Users { get; set; }

        public Administrator() : base()
        {
            Hotels = new List<Hotel>();
            Users = new List<User>();
        }

        public override string[] ToCSV()
        {
            return base.ToCSV();
        }

        public override void FromCSV(string[] values)
        {
            base.FromCSV(values);
        }
    }
}
