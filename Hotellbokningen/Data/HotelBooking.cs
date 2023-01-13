using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Hotellbokningen.Data
{
    public class HotelBooking
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int CustomerId { get; set; }
        public Customer CustomerBooking { get; set; }
        public Room RoomBooking { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

        public static int ShowBookingsMenu()
        {
            Console.WriteLine("1. Create Bookings");
            Console.WriteLine("2. Show all Bookings");
            Console.WriteLine("3. Back To Main Menu");
            Console.WriteLine();
            Console.Write("Enter menu option: ");
            int option = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            return option;
        }

        public static void CreateBooking(HotelDatabase dbContext)
        {
            var bookingToCreate = new HotelBooking();

            Console.Clear();
            Console.WriteLine(" How many days are you staying?");
            int numberOfDays = Convert.ToInt32(Console.ReadLine());

            bookingToCreate.DateStart = new DateTime(2001, 01, 01, 23, 59, 59);
            while (bookingToCreate.DateStart < DateTime.Now.Date)
            {
                Console.WriteLine("\n From which date would you like your booking to start from? (yyyy-mm-dd)");
                bookingToCreate.DateStart = Convert.ToDateTime(Console.ReadLine());
            }

            if (numberOfDays == 1) bookingToCreate.DateEnd = bookingToCreate.DateStart;
            else if (numberOfDays > 1) bookingToCreate.DateEnd = bookingToCreate.DateStart.AddDays(numberOfDays);

            List<DateTime> newBookingAllDates = new List<DateTime>();
            for (var dt = bookingToCreate.DateStart; dt <= bookingToCreate.DateEnd; dt = dt.AddDays(1))
            {
                newBookingAllDates.Add(dt);
            }

            List<Room> availableRooms = new List<Room>();

            foreach (var room in dbContext.Rooms.ToList())
            {
                bool roomIsFree = true;
                foreach (var booking in dbContext.Bookings.Include(b => b.RoomBooking).Where(b => b.RoomBooking == room))
                {
                    for (var dt = booking.DateStart; dt <= booking.DateEnd; dt = dt.AddDays(1))
                    {
                        if (newBookingAllDates.Contains(dt))
                        {
                            roomIsFree = false;

                        }
                    }

                    if (!roomIsFree)
                    {
                        break;
                    }
                }


                if (roomIsFree)
                {
                    availableRooms.Add(room);
                }
            }

            
            Console.Clear();
            Console.WriteLine(" Your booking details");
            Console.WriteLine(" ==================================================================");
            Console.WriteLine(" Start\t\tEnd\t\tNo. of days");
            Console.WriteLine($" {bookingToCreate.DateStart.ToShortDateString()}\t{bookingToCreate.DateEnd.ToShortDateString()}\t{numberOfDays}");

            if (availableRooms.Count() < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\n There are no rooms available for these dates. Please try another date");
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.WriteLine(" Press any key to continue");
                Console.ReadLine();
                return; 
            }
            else
            {
                
                Console.WriteLine("\n\n\n These rooms are available for booking");
                Console.WriteLine("\n Id\tRoomNummber\t\tRoomType\t\tExtraBeds");
                Console.WriteLine(" ==================================================================");

                foreach (var room in availableRooms.OrderBy(r => r.RoomId))
                {
                    Console.WriteLine($" {room.RoomId}\t\t{room.RoomNumber}\t\t{room.Type}\t\t{room.ExtraBeds}");
                    Console.WriteLine(" ------------------------------------------------------------------");
                }
            }

            
            Console.WriteLine("\n Please choose a room");
            int roomBooking = Convert.ToInt32(Console.ReadLine());
            bookingToCreate.RoomBooking = dbContext.Rooms.Where(c => c.RoomId == roomBooking).FirstOrDefault();

            Console.WriteLine("\n Choose the customer staying");
            foreach(var customer in dbContext.Customers)
            {
                Console.WriteLine($"{customer.CustomerId} {customer.Name} {customer.Email} {customer.PhoneNumber}");
            }
            var customerBooking = Convert.ToInt32(Console.ReadLine());
            bookingToCreate.CustomerBooking = dbContext.Customers.Where(c => c.CustomerId == customerBooking).FirstOrDefault();


            dbContext.Add(bookingToCreate);
            dbContext.SaveChanges();

           
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            Console.WriteLine(" Booking successful!");
            Console.WriteLine(" ==============================================================================");
            Console.WriteLine(" Start\t\tEnd\t\tNo. of days");
            Console.WriteLine($" {bookingToCreate.DateStart.ToShortDateString()}\t{bookingToCreate.DateEnd.ToShortDateString()}\t{numberOfDays}");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("\n Press any key to continue");
            Console.ReadLine();
        }

        public static void ShowBookings(HotelDatabase dbContext)
        {

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" \t\t\t\tBOOKING INFO ");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("\n\tCustomer\t\tFrom\t\tTo\t\tRoom ID");
            Console.WriteLine("       ---------------------------------------------------------- ");

            if (dbContext.Bookings.Count() == 0)
            {
                Console.WriteLine("\nNo bookings found");
            }
               
            else
            {
                var bookingData = dbContext.Bookings.Include(r => r.RoomBooking).Include(g => g.CustomerBooking);

                foreach (var booking in bookingData.OrderBy(b => b.Id))
                    Console.WriteLine($"\n\t{booking.CustomerBooking.Name}\t\t{booking.DateStart.ToShortDateString()}\t{booking.DateEnd.ToShortDateString()}\t  {booking.RoomBooking.RoomId}");

            }

            Console.ReadLine();
        }


    }
}
