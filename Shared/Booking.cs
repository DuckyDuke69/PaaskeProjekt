﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sheltermini.Shared
{
    public class Booking
    {
        private static int lastId = 0;
        public Booking()
        {
            BookingId = ++lastId;
        }
        public   Shelter Shelter { get; set;}
      public  string Startdate { get; set;}
     public   string Slutdate { get; set;}
     public   int NumberOfPeople { get; set;}
      public  int BookingId { get; set;}
      public  string FullName { get; set;} = "";
       public string Email { get; set;}
     public   string Phone { get; set;}
      //  string comment;
/*      public Booking(Shelter shelter, DateTime Startdate, DateTime Slutdate, int numberOfPeople, int bookingId, string name, string email, string phone)
        {
                this.shelter = shelter;
                this.Startdate = Startdate;
                this.Slutdate = Slutdate;
                this.numberOfPeople = numberOfPeople;
                this.bookingId = bookingId;
                this.name = name;
                this.email = email;
                this.phone = phone;
            }
    
            public Shelter Shelter { get => shelter; set => shelter = value; }
            public DateTime Date { get => date; set => date = value; }
            public int NumberOfPeople { get => numberOfPeople; set => numberOfPeople = value; }
            public int BookingId { get => bookingId; set => bookingId = value; }
            public string Name { get => name; set => name = value; }
            public string Email { get => email; set => email = value; }
            public string Phone { get => phone; set => phone = value; } 
*/
    }
}
