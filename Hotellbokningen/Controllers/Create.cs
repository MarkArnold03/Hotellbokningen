using Hotellbokningen.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Hotellbokningen.Data.Room;

namespace Hotellbokningen.Controllers
{
    public class Create : ICrud
    {
        public HotelDatabase dbContext { get; set; }
        public Create(HotelDatabase context)
        {
            dbContext = context;
        }

       
        public void Run()
        {
            
           Console.Write("Enter customer name: ");
           string customerName = Console.ReadLine();
           Console.Write("Enter room type  (single, double): ");
            RoomType type;
            if (!Enum.TryParse(Console.ReadLine(), out type))
            {
                Console.WriteLine("Invalid room type. Please enter 'single' or 'double'.");
                return;
            }
            Console.Write("Enter number of nights: ");
           int numNights = int.Parse(Console.ReadLine());
           Console.Write("Enter bed size (single, double, queen, king): ");

           using (var context = new HotelDatabase())
           {
                HotelBooking booking = new HotelBooking
                {
                      //  Name = customerName,
                        //RoomType = roomType,
                        //NumNights = numNights,
                };
                context.Bookings.Add(booking);
                context.SaveChanges();
                Console.WriteLine("Booking created successfully.");
           }

            
        }

                //public static RoomType ReadRoomType()
               // {
          
                 //   string line = Console.ReadLine();

                   // if (Enum.TryParse(line, out RoomType roomType))
                    //{
               
                     //   return roomType;
                    //}
                    //else
                    //{
                
                    //    return RoomType.Single;
                    //}
      //  }

    }
}
