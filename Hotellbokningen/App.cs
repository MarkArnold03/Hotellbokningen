using Hotellbokningen.Controllers;
using Hotellbokningen.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotellbokningen
{
    public class App
    {
        public void Run()
        {
            var buildApp = new Build();
            var dbContext = buildApp.BuildApp();

            while (true)
            {
               

                var sel = MainMenu.ShowMenu();
                if (sel == 4)
                {
                    
                    break;
                }
                switch (sel)
                {
                    case 1:

                        while (true)
                        {
                           Console.Clear();

                            // Read the user's choice
                            var roomChoice =  Room.ShowRoomMenu();

                            // Handle the user's choice
                            switch (roomChoice)
                            {
                                case 1:
                                    Console.Clear();
                                    Room.ListRooms();
                                    break;
                                case 2:
                                    Console.Clear();
                                    Room.AddRoom();
                                    break;
                                case 3:
                                    Console.Clear();
                                    Room.UpdateRoom();
                                    break;
                                case 4:
                                    Console.Clear();
                                    Room.DeleteRoom();
                                    break;
                                case 5:
                                    break;
                                default:
                                    Console.WriteLine("Invalid choice.");
                                    break;
                            }

                            if (roomChoice == 5)
                            {
                                Console.Clear();
                                break;
                            }
                        }
                        break;
                    case 2:
                        // Display the guests menu
                        while (true)
                        {
                            Console.Clear();
                           

                            // Read the user's choice
                            var customerChoice =  Customer.ShowCustomerMenu();

                            // Handle the user's choice
                            switch (customerChoice)
                            {
                                case 1:
                                    Console.Clear();
                                    var customer = new Customer();
                                    customer.ListCustomers();
                                    break;
                                case 2:
                                    Console.Clear();
                                    Customer.AddCustomer();
                                    break;
                                case 3:
                                    Console.Clear();
                                    Customer.UpdateCustomer();
                                    break;
                                case 4:
                                    Console.Clear();
                                    Customer.DeleteCustomer();
                                    break;
                                case 5:
                                    break;
                                default:
                                    Console.WriteLine("Invalid choice.");
                                    break;
                            }

                            if (customerChoice == 5)
                            {
                                Console.Clear();
                                break;
                            }
                        }
                        break;
                }
            }
        }

    }
}
