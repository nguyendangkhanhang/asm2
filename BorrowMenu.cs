using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A
{
    class BorrowMenu : IMenu
    {
        private static List<Borrow> borrows = new List<Borrow>();
        private List<Customer> customers = (new CustomerMenu()).getListCustomer();
        private List<Book> books = (new BookMenu()).getListBook();
        public void ShowMenu()
        {
            Console.WriteLine("-----BORROW MENU OPTIONS-----");
            Console.WriteLine("| 1. Borrow Book            |");
            Console.WriteLine("| 2. Display Borrowed Books |");
            Console.WriteLine("| 3. Return Book            |");
            Console.WriteLine("| 4. Exit                   |");
            Console.WriteLine(" ----------------------------");
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
                        BorrowBook();
                        break;

                    case 2:
                        DisplayBorrowBook();
                        break;

                    case 3:
                        ReturnBook();
                        break;
                    case 4:
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        Console.WriteLine("Please choose again.");
                        break;
                }
                Console.WriteLine();
            } while (choice != 4);
        }
        private void BorrowBook()
        {
            Console.WriteLine("Borrowing Book...");
            Console.Write("Enter Customer ID: ");
            int customerId = int.Parse(Console.ReadLine());
            Console.Write("Enter Book ISBN: ");
            int bookISBN = int.Parse(Console.ReadLine());
            Customer customer = customers.FirstOrDefault(c => c.ID == customerId);
            Book book = books.FirstOrDefault(b => b.ISBN == bookISBN && b.IsAvailable);

            if (customer == null)
            {
                Console.WriteLine("Invalid customer ID or name.");
                return;
            }

            if (book == null)
            {
                Console.WriteLine("Book not found or not available.");
                return;
            }
            Borrow borrow = new Borrow(customer, book);
            borrows.Add(borrow);
            Console.WriteLine($"{book.Title} has been borrowed by {customer.Name}.\n");
        }
        private void DisplayBorrowBook()
        {
            Console.WriteLine("Borrowed Books:");
            foreach (var borrowed in borrows)
            {
                Console.WriteLine($"Customer ID: {borrowed.Customer.ID} | Customer Name: {borrowed.Customer.Name} | Book Title: {borrowed.Book.Title}");
            }
        }
        //private void ReturnBook()
        //{
        //    Console.WriteLine("Returning Book...");
        //    Console.Write("Enter Customer ID: ");
        //    int returnCustomerId = int.Parse(Console.ReadLine());
        //    Console.Write("Enter Customer Name: ");
        //    string returnCustomerName = Console.ReadLine();
        //    Console.Write("Enter Book Title: ");
        //    string returnBookTitle = Console.ReadLine();


        //    Borrow returnBorrow = borrows.FirstOrDefault(b => b.Customer.ID == returnCustomerId && b.Customer.Name == returnCustomerName && b.Book.Title == returnBookTitle);

        //    if (returnBorrow != null)
        //    {
        //        Console.WriteLine($"{returnBookTitle} has been returned.");
        //        returnBorrow.Book.IsAvailable = true;
        //        borrows.Remove(returnBorrow);
        //    }
        //    else
        //    {
        //        Console.WriteLine("Invalid customer ID, name, or book title.");
        //    }

        //}

        private void ReturnBook()
        {
            Console.WriteLine("Returning Book...");
            Console.Write("Enter Customer ID: ");
            int returnCustomerId = int.Parse(Console.ReadLine());
            //Console.Write("Enter Customer Name: ");
            //string returnCustomerName = Console.ReadLine();
            Console.Write("Enter Book ISBN: ");
            int returnBookISBN = int.Parse(Console.ReadLine());

            Customer customer = customers.FirstOrDefault(c => c.ID == returnCustomerId);
            Book book = books.FirstOrDefault(b => b.ISBN == returnBookISBN);
            Borrow returnBorrow = new Borrow(customer, book);

            if (returnBorrow != null)
            {
                Console.WriteLine($"{book.Title} has been returned.");
                returnBorrow.Book.IsAvailable = true;
                borrows.Remove(returnBorrow);
            }
            else
            {
                Console.WriteLine("Invalid customer ID, name, or book title.");
            }
        }
    }
}
