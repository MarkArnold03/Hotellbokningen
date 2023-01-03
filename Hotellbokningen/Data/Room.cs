using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotellbokningen.Data
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }

        public int RoomNumber { get; set; }
        public RoomType Type { get; set; }
        public int ExtraBeds { get; set; }

        public static implicit operator Room(RoomType v)
        {
            throw new NotImplementedException();
        }

        public static int ShowRoomMenu()
        {
            Console.WriteLine("1. List rooms");
            Console.WriteLine("2. Add room");
            Console.WriteLine("3. Update room");
            Console.WriteLine("4. Delete room");
            Console.WriteLine("5. Back");
            Console.WriteLine();
            Console.Write("Enter menu option: ");
            int option = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            return option;
        }

        public static void ListRooms()
        {
            using (var context = new HotelDatabase())
            {
                // Get a list of rooms from the database
                var rooms = context.Rooms.ToList();

                // Print the list of rooms
                Console.WriteLine("ID\tType\tNumber\tExtra Beds");
                Console.WriteLine("--\t----\t------\t----------");
                foreach (var room in rooms)
                {
                    Console.WriteLine($"{room.RoomId}\t{room.Type}\t{room.RoomNumber}\t{room.ExtraBeds}");
                }
            }
        }

        public static void AddRoom()
        {
            using (var context = new HotelDatabase())
            {
                // Prompt the user for room information
                Console.Write("Enter room type (single or double): ");
                RoomType type;
                if (!Enum.TryParse(Console.ReadLine(), out type))
                {
                    Console.WriteLine("Invalid room type. Please enter 'single' or 'double'.");
                    return;
                }
                Console.Write("Enter room number: ");
                var number = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter number of extra beds (0 for single rooms): ");
                int extraBeds;
                if (!int.TryParse(Console.ReadLine(), out extraBeds))
                {
                    Console.WriteLine("Invalid number of extra beds. Please enter a whole number.");
                    return;
                }

                // Create a new room object
                var room = new Room()
                {
                    Type = type,
                    RoomNumber = number,
                    ExtraBeds = extraBeds
                };


                context.Rooms.Add(room);
                context.SaveChanges();

                Console.WriteLine("Room added successfully.");
            }
        }

        public static void UpdateRoom()
        {
            using (var context = new HotelDatabase())
            {
                // Prompt the user for the ID of the room to update
                Console.Write("Enter the ID of the room to update: ");
                var id = int.Parse(Console.ReadLine());

                // Get the room from the database
                var room = context.Rooms.Find(id);
                if (room == null)
                {
                    Console.WriteLine("Room not found.");
                    return;
                }

                // Prompt the user for updated room information
                Console.Write("Enter room type (single or double): ");
                room.Type = (RoomType)Enum.Parse(typeof(RoomType), Console.ReadLine());
                Console.Write("Enter room number: ");
                room.RoomNumber = int.Parse(Console.ReadLine());
                Console.Write("Enter number of extra beds (0 for single rooms): ");
                room.ExtraBeds = int.Parse(Console.ReadLine());

                // Update the room in the database
                context.Rooms.Update(room);
                context.SaveChanges();

                Console.WriteLine("Room updated successfully.");
            }
        }


        public static void DeleteRoom()
        {
            using (var context = new HotelDatabase())
            {
                // Prompt the user for the ID of the room to delete
                Console.Write("Enter the ID of the room to delete: ");
                var id = int.Parse(Console.ReadLine());

                // Get the room from the database
                var room = context.Rooms.Find(id);
                if (room == null)
                {
                    Console.WriteLine("Room not found.");
                    return;
                }

                // Delete the room from the database
                context.Rooms.Remove(room);
                context.SaveChanges();

                Console.WriteLine("Room deleted successfully.");
            }
        }

        public enum RoomType
        {
            Single,
            Double

        }

    }

}
