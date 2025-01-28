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

    }
}
