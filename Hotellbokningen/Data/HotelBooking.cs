using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotellbokningen.Data
{
    public class HotelBooking
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int Nights { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public static int ShowBookingsMenu()
        {
            Console.WriteLine("1. Create Bookings");
            Console.WriteLine("2. Show all Bookings");
            Console.WriteLine("3. Update Bookings");
            Console.WriteLine("5. Check in");
            Console.WriteLine("6. Check out");
            Console.WriteLine("7. Back To Main Menu");
            Console.WriteLine();
            Console.Write("Enter menu option: ");
            int option = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            return option;
        }
    }   
}
