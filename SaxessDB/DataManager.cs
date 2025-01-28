using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using SaxessDB.Data;
using SaxessDB.Models;


namespace SaxessDB
{
    public class DataManager
    {
        public static void AddMember(SaxessDbContext context)
        {

            Console.WriteLine("--ADD NEW TREATMENT--");
            Console.WriteLine("Type in name of treatment: ");
            string treatmentName = Console.ReadLine();
            Console.WriteLine("Enter price");
            decimal treatmentPrice = decimal.Parse(Console.ReadLine());
            var newTreatment = new Treatment
            {
                Type = treatmentName,
                Price = treatmentPrice
            };
            context.Treatments.Add(newTreatment);
            context.SaveChanges();
        }
        public static void Prices(SaxessDbContext context)
        {
            IQueryable<Treatment> treatment = context.Treatments;
            var prices = treatment.ToList();
            foreach (var treat in treatment)
            {
                Console.WriteLine($"{treat.Type} - {treat.Price}");
            }
            Console.WriteLine();
        }
        public static void AddBooking(SaxessDbContext context)
        {
            //using (var context = new SaxessDbContext())
            

                Console.WriteLine("Vilken dag vill du boka: (yyyy-mm-dd) ");
                DateTime addBookingTime = Convert.ToDateTime(Console.ReadLine());

                var newBooking = new Booking
                {
                    TimeSlot = addBookingTime
                };

                context.Bookings.Add(newBooking);
                context.SaveChanges();
                Console.WriteLine("Bokning tillagd!");
            
        }
    }
}