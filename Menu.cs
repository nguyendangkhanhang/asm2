using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A
{
    class Menu : IMenu
    {
        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine(" -------MENU OPTIONS--------");
            Console.WriteLine("|   1. Customer Manage      |");
            Console.WriteLine("|   2. Book Manage          |");
            Console.WriteLine("|   3. Borrow               |");
            Console.WriteLine("|   4. Exit                 |");
            Console.WriteLine(" --------------------------- ");
        }
        public void SelectMenu()
        {
            while (true)
            {
                int option;
                do
                {
                    ShowMenu();
                    Console.Write("Enter option: ");
                    option = Convert.ToInt32(Console.ReadLine());
                } while (option < 1 || option > 4);

                IMenu seMenu = null;
                switch (option)
                {
                    case 1:
                        Console.Clear();
                        seMenu = new CustomerMenu();
                        seMenu.SelectMenu();
                        break;
                    case 2:
                        Console.Clear();
                        seMenu = new BookMenu();
                        seMenu.SelectMenu();
                        break;
                    case 3:
                        Console.Clear();
                        seMenu = new BorrowMenu();
                        seMenu.SelectMenu();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
