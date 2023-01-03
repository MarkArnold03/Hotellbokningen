using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotellbokningen.Controllers
{
    public static class MainMenu
    {
        public static int ShowMenu()
        {
        Console.WriteLine("1. Rooms");
        Console.WriteLine("2. Customers");
        Console.WriteLine("3. Bookings");
        Console.WriteLine("4. Exit");
        Console.WriteLine();
        Console.Write("Enter menu option: ");
        int option = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();
            return  option;
        }
    }
}
