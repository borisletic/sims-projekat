﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HotelBookingApp.Model
{
    public class Guest : User
    {
        public List<Hotel> Hotels { get; set; }
        public List<Apartment> Apartments { get; set; }

        public Guest() : base()
        {
            Hotels = new List<Hotel>();
            Apartments = new List<Apartment>();
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
