using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotellbokningen.Data
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<Booking> Bookings { get; set; }

        public HotelDatabase dbContext { get; set; } = new HotelDatabase();
        public static int ShowCustomerMenu()
        {
            Console.WriteLine("1. List Customer");
            Console.WriteLine("2. Add Customer");
            Console.WriteLine("3. Update Customer");
            Console.WriteLine("4. DeleteCustomer");
            Console.WriteLine("5. Back");
            Console.WriteLine();
            Console.Write("Enter menu option: ");
            int option = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            return option;
        }

        public  void ListCustomers()
        {
            
                var customers = dbContext.Customers;
                foreach (var customer in customers)
                {
                    Console.WriteLine($"ID: {customer.CustomerId} | Name: {customer.Name} | Email: {customer.Email} | Phone: {customer.PhoneNumber}");
                }
            
        }

        public static void AddCustomer()
        {
            using (var context = new HotelDatabase())
            {
                Console.Write("Enter Customer name: ");
                var name = Console.ReadLine();
                Console.Write("Enter customer email: ");
                var email = Console.ReadLine();
                Console.Write("Enter customer phone number: ");
                var phone = Console.ReadLine();

                var customer = new Customer
                {
                    Name = name,
                    Email = email,
                    PhoneNumber = phone
                };

                context.Add(customer);
                context.SaveChanges();
            }
        }

        public static void UpdateCustomer()
        {
            using (var context = new HotelDatabase())
            {
                Console.Write("Enter Customer ID: ");
                var id = int.Parse(Console.ReadLine());
                var customer = context.Customers.Find(id);
                if (customer == null)
                {
                    Console.WriteLine("Customer not found.");
                    return;
                }

                Console.Write("Enter updated name: ");
                customer.Name = Console.ReadLine();
                Console.Write("Enter updated email: ");
                customer.Email = Console.ReadLine();
                Console.Write("Enter updated phone: ");
                customer.PhoneNumber = Console.ReadLine();

                context.Customers.Update(customer);
                context.SaveChanges();
            }
        }

        public static void DeleteCustomer()
        {
            using (var context = new HotelDatabase())
            {
                Console.Write("Enter Customer ID: ");
                var id = int.Parse(Console.ReadLine());
                var customer = context.Customers.Find(id);
                if (customer == null)
                {
                    Console.WriteLine("Customer not found.");
                    return;
                }

                // Check if the guest has any bookings
                var bookings = context.HotelBookings.Where(b => b.CustomerId == customer.CustomerId).ToList();
                if (bookings.Any())
                {
                    Console.WriteLine("Cannot delete customer because they have bookings.");
                    return;
                }

                context.Customers.Remove(customer);
                context.SaveChanges();
            }
        }

    }
}
