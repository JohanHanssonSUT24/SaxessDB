using SaxessDB.Data;
using SaxessDB.Models;

namespace SaxessDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new SaxessDbContext();
            bool menuBool = true;
           

            while (menuBool)
            {
                Console.WriteLine("Välkommen till Saxess!");
                Console.WriteLine("[1] Bokningar");
                Console.WriteLine("[2] Personal");
                Console.WriteLine("[3] Lägg till behandling");
                Console.WriteLine("[4] Prislista");
                Console.WriteLine("[5] Avsluta program");
                Console.WriteLine();
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        //Method for Bookings
                        break;
                    case "2":
                        //Method for staff
                        break;
                    case "3":
                        //Add treatment
                        DataManager.AddMember(context);
                        break;
                    case "4":
                        //Prices
                        DataManager.Prices(context);
                        break;
                    case "5":
                        menuBool = false;
                        break;
                }
            }
        }
    }
}
