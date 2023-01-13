using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Hotellbokningen.Data
{
    public class DataInitializer
    {
        public void MigrateAndSeed(HotelDatabase dbContext)
        {
            dbContext.Database.Migrate();
            RoomData(dbContext);
            CustomerData(dbContext);
           // dbContext.SaveChanges();
        }

        private void RoomData(HotelDatabase dbContext)
        {

            if (!dbContext.Rooms.Any(r => r.RoomId== 1))
            {
                dbContext.Rooms.Add(new Room
                {
                    //RoomId =1,
                    RoomNumber = 101,
                    Type = Room.RoomType.Single,
                    ExtraBeds = 0,
                    
                });
            }
            if (!dbContext.Rooms.Any(r => r.RoomId == 2))
            {
                dbContext.Rooms.Add(new Room
                {
                    RoomNumber = 102,
                    Type = Room.RoomType.Double,
                    ExtraBeds = 0,

                });
            }
            if (!dbContext.Rooms.Any(r => r.RoomId == 3))
            {
                dbContext.Rooms.Add(new Room
                {
                    //RoomId = 3,
                    RoomNumber = 103,
                    Type = Room.RoomType.Double,
                    ExtraBeds = 1,

                });
            }
            if (!dbContext.Rooms.Any(r => r.RoomId == 4))
            {
                dbContext.Rooms.Add(new Room
                {
                    //RoomId = 4,
                    RoomNumber = 104,
                    Type = Room.RoomType.Double,
                    ExtraBeds = 2,

                });
            }
            dbContext.SaveChanges();

            // var rooms = new List<Room>
            // {
            //  new Room { RoomId = 1, RoomNumber = 101, Type = Room.RoomType.Single, ExtraBeds = 0 },
            //new Room { RoomId = 2, RoomNumber = 102, Type = Room.RoomType.Double, ExtraBeds = 0 },
            //new Room { RoomId = 3, RoomNumber = 103, Type = Room.RoomType.Double, ExtraBeds = 1 },
            //new Room { RoomId = 4, RoomNumber = 104, Type = Room.RoomType.Double, ExtraBeds = 2 }
            //};

            //var customer = new List<Customer>
            //{
            //  new Customer { CustomerId = 1, Name = "John Smith", Email = "john@example.com", PhoneNumber = "123-456-7890" },
            // new Customer { CustomerId = 2, Name = "Jane Doe", Email = "jane@example.com", PhoneNumber = "123-456-7891" },
            //new Customer { CustomerId = 3, Name = "Bob Johnson", Email = "bob@example.com", PhoneNumber = "123-456-7892" },
            //new Customer { CustomerId = 4, Name = "Sally Smith", Email = "sally@example.com", PhoneNumber = "123-456-7893" }
            //};

           // dbContext.Rooms.AddRange(rooms);
            //dbContext.Customers.AddRange(customer);
           
        }
        private void CustomerData(HotelDatabase dbContext)
        {
            if (!dbContext.Customers.Any(c => c.CustomerId == 1))
            {
                dbContext.Customers.Add(new Customer
                {
                    Name = "John Smith",
                    Email = "john@example.com",
                    PhoneNumber = "123-456-7890",

                });
            }
            if (!dbContext.Customers.Any(c => c.CustomerId == 2))
            {
                dbContext.Customers.Add(new Customer
                {
                    Name = "Jane Doe",
                    Email = "jane@example.com",
                    PhoneNumber = "123-456-7891",

                });
            }
            if (!dbContext.Customers.Any(c => c.CustomerId == 3))
            {
                dbContext.Customers.Add(new Customer
                {
                    
                    Name = "Bob Johnson",
                    Email = "bob@example.com",
                    PhoneNumber = "123-456-7892",

                });
            }
            if (!dbContext.Customers.Any(c => c.CustomerId == 4))
            {
                dbContext.Customers.Add(new Customer
                {
                    
                    Name = "Sally Smith",
                    Email = "sally@example.com",
                    PhoneNumber = "123-456-7893",

                });
            }
            dbContext.SaveChanges();
        }

    }
}
