using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A
{
    class CustomerMenu : ManagerMenu, IMenu
    {
        private static List<Customer> customers = new List<Customer>();
        public List<Customer> getListCustomer()
        {
            return customers;
        }

        public void ShowMenu()
        {
            Console.WriteLine(" ------------CUSTOMER MANAGE----------------");
            Console.WriteLine("|      1. Add Customer                      |");
            Console.WriteLine("|      2. Update Customer                   |");
            Console.WriteLine("|      3. Delete Customer                   |");
            Console.WriteLine("|      4. Display All Customers             |");
            Console.WriteLine("|      5. Exit                              |");
            Console.WriteLine(" -------------------------------------------");
        }

        public void SelectMenu()
        {
            int choice;
            do
            {
                ShowMenu();
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        Add();
                        break;

                    case 2:
                        Update();
                        break;

                    case 3:
                        Delete();
                        break;

                    case 4:
                        Display();
                        break;
                    case 5:
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        Console.WriteLine("Please choose again.");
                        break;
                }
                Console.WriteLine();
            } while (choice != 5);
        }

        protected override void Add()
        {
            Console.Clear();
            Console.WriteLine("Adding Customer...");
            Console.Write("Enter the name: ");
            string name = Console.ReadLine();
            Console.Write("Enter the address: ");
            string address = Console.ReadLine();
            Console.Write("Enter the phone number: ");
            string phoneNumber = Console.ReadLine();
            Customer c1 = new Customer(name, address, phoneNumber);
            customers.Add(c1);
            Console.Write("Customer added successfully. ");
        }

        protected override void Delete()
        {
            Console.WriteLine("Enter the ID of the customer to delete: ");
            int IDDelete = int.Parse(Console.ReadLine());
            Customer customerDelete = customers.FirstOrDefault(c => c.ID == IDDelete);
            if (customerDelete != null)
            {
                customers.Remove(customerDelete);
                Console.WriteLine("Customer deleted successfully.");
            }
            else
            {
                Console.WriteLine("Customer not found.");
            }
        }

        protected override void Update()
        {
            Console.WriteLine("Updating Customer...");
            Console.WriteLine("Enter the ID of the customer information to update: ");
            int updateId = int.Parse(Console.ReadLine() + "");
            Customer customerToUpdate = customers.FirstOrDefault(c => c.ID == updateId);
            if (customerToUpdate != null)
            {
                Console.WriteLine("Enter the updated data for the customer information:");
                Console.Write("Name: ");
                customerToUpdate.Name = Console.ReadLine();
                Console.Write("Address: ");
                customerToUpdate.Address = Console.ReadLine();
                Console.Write("Phone Number: ");
                customerToUpdate.PhoneNumber = Console.ReadLine();
                Console.WriteLine("Customer updated successfully.\n");
            }
            else
            {
                Console.WriteLine("The customer was not found.");
            }
        }

        protected override void Display()
        {
            Console.WriteLine("Customer List");
            foreach (var customer in customers)
            {
                Console.WriteLine("Customer Details:");
                Console.WriteLine($"ID: {customer.ID}");
                Console.WriteLine($"Name: {customer.Name}");
                Console.WriteLine($"Address: {customer.Address}");
                Console.WriteLine($"Phone Number: {customer.PhoneNumber}");
                Console.WriteLine("--------------");
            }
        }
    }
}
