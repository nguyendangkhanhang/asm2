using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A
{
    class BookMenu : ManagerMenu, IMenu
    {
        private static List<Book> mybook = new List<Book>();
        public List<Book> getListBook()
        {
            return mybook;
        }

        public void ShowMenu()
        {
            Console.WriteLine(" -------------BOOK MANAGE----------------");
            Console.WriteLine("|          1. Add Book                   |");
            Console.WriteLine("|          2. Update Book                |");
            Console.WriteLine("|          3. Delete Book                |");
            Console.WriteLine("|          4. Display All Books          |");
            Console.WriteLine("|          5. Exit                       |");
            Console.WriteLine(" ----------------------------------------");
        }

        public void SelectMenu()
        {
            int choice;
            do
            {
                ShowMenu();
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine() + "");
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
            Console.WriteLine("Adding Book...");
            Console.Write("Enter the title: ");
            string title = Console.ReadLine();
            Console.Write("Enter the author name: ");
            string author = Console.ReadLine();
            mybook.Add(new Book(title, author));
            Console.Write("Book added successfully.\n");
        }

        protected override void Update()
        {
            Console.WriteLine("Updating Book...");
            Console.WriteLine("Enter the ISBN of the book to update: ");
            int updateISBN = int.Parse(Console.ReadLine());
            Book bookToUpdate = mybook.FirstOrDefault(b => b.ISBN == updateISBN);
            if (bookToUpdate != null)
            {
                Console.WriteLine("Enter the updated data for the book:");
                Console.Write("Title: ");
                bookToUpdate.Title = Console.ReadLine();
                Console.Write("Author: ");
                bookToUpdate.Author = Console.ReadLine();
                Console.WriteLine("Book update successfully...");
            }
            else
            {
                Console.WriteLine("The book with the specified ISBN was not found.");
            }
        }

        protected override void Delete()
        {
            Console.WriteLine("Enter the ISBN of the book to delete: ");
            int deleteISBN = int.Parse(Console.ReadLine());
            Book bookToDelete = mybook.FirstOrDefault(b => b.ISBN == deleteISBN);
            if (bookToDelete != null)
            {
                if (!bookToDelete.IsAvailable)
                {
                    Console.WriteLine("The book with the specified ISBN was borrowed");
                    return;
                }
                Console.WriteLine("Are you sure you want to delete the book? Enter 'Y' for yes or 'N' for no: ");
                string confirm = Console.ReadLine();
                if (confirm.ToUpper() == "Y")
                {

                    mybook.Remove(bookToDelete);
                    Console.WriteLine("The book has been deleted successfully.");
                }
                else
                {
                    Console.WriteLine("The book was not deleted.");
                }
            }
            else
            {
                Console.WriteLine("The book with the specified ISBN was not found");
            }
        }

        protected override void Display()
        {
            Console.WriteLine("Library Catalog");
            foreach (var book in mybook)
            {
                Console.WriteLine("Book Details:");
                Console.WriteLine($"Title: {book.Title}");
                Console.WriteLine($"Author: {book.Author}");
                Console.WriteLine($"ISBN: {book.ISBN}");
                Console.WriteLine($"Availability: {(book.IsAvailable ? "Available" : "Not Available")}");
                Console.WriteLine("--------------");
            }
        }
    }
}
