using MenuClass;
using MenuRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoldBadgeChallenges
{
    class ProgramUI
    {
        private MenuRepository _menuRepository = new MenuRepository();
        

        public void Run()
        {
            SeedingMenuList();
            Main();
        }
       

        public void Main()
        {

            bool running = true;
            while(running)
            {
                Console.Clear();

                Console.WriteLine("Select a option and press enter\n" +
                    "1. Create a new menu item\n" +
                    "2. Show menu list\n" +
                    "3. Delete menu listing\n" +
                    "4. Exit");

                int userInput = int.Parse(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        CreateNewMenuOptionListing();
                        break;
                    case 2:
                        ShowMenuList();
                        break;
                    case 3:
                        DeleteMenuListing();
                        break;
                    case 4:
                        Console.WriteLine("GoodBye!");
                        Thread.Sleep(1000);
                        return;
                    default:
                        Console.WriteLine("Invaild input try again");
                        Thread.Sleep(1000);
                        break;
                }
            }

        }

        private void SeedingMenuList()
        {
            Menu menuListing1 = new Menu();
            menuListing1.FoodName = "Fries";
            menuListing1.FoodNumber = 1;
            menuListing1.FoodInfo = "Deep fried potatos";
            menuListing1.FoodId = 1;
            menuListing1.FoodPrice = 1.99M;

            Menu menuListing2 = new Menu();
            menuListing2.FoodName = "Spicy fries";
            menuListing2.FoodNumber = 2;
            menuListing2.FoodInfo = "Deep fried potatos with spicy seasoning added";
            menuListing2.FoodId = 2;
            menuListing2.FoodPrice = 2.99M;

            _menuRepository.CreateNewMenuOption(menuListing1);
            _menuRepository.CreateNewMenuOption(menuListing2);
        }


        public void SimpleTextCopyAndPaste()
        {
            Console.WriteLine("Please press enter to continue");
            Console.ReadLine();
        }



        private void CreateNewMenuOptionListing()
        {
            Console.Clear();

            Menu menuOptionInfo = new Menu();

            // Food name
            Console.WriteLine("Please enter a name for this item");
            menuOptionInfo.FoodName = Console.ReadLine();
            // Food number
            Console.WriteLine("Please enter a number for this item to be listed as on the menu");
            menuOptionInfo.FoodNumber = Int32.Parse(Console.ReadLine());
            // Food ID
            if (_menuRepository.MenuList().Count > 0)
            {
                foreach (Menu menuOption in _menuRepository.MenuList())
                {
                    Console.WriteLine("ID in use. " + menuOption.FoodId);
                }
            }
            else
            {
                Console.WriteLine("No ID's in use");
            }
            Console.WriteLine("Please enter a internal ID for this item");
            var userIDInput = int.Parse(Console.ReadLine());
            foreach(Menu menuOption in _menuRepository.MenuList())
            {
                if (userIDInput == menuOption.FoodId)
                {
                    Console.WriteLine("this ID is taken");
                    SimpleTextCopyAndPaste();
                    CreateNewMenuOptionListing();
                }
                else
                {
                    Console.WriteLine("New ID made");
                    menuOptionInfo.FoodId = userIDInput;
                }
            }
            // Food info
            Console.WriteLine("Please give a brief description of this item");
            menuOptionInfo.FoodInfo = Console.ReadLine();
            // Food price
            Console.WriteLine("Please give this item a price");
            menuOptionInfo.FoodPrice = decimal.Parse(Console.ReadLine());

           _menuRepository.CreateNewMenuOption(menuOptionInfo);

            SimpleTextCopyAndPaste();

        }

        private void ShowMenuList()
        {
            Console.Clear();
            if(_menuRepository.MenuList().Count > 0)
            {
                foreach(Menu menuList in _menuRepository.MenuList())
                {
                    Console.WriteLine("            ");
                    Console.WriteLine(menuList.FoodName);
                    Console.WriteLine(menuList.FoodNumber);
                    Console.WriteLine(menuList.FoodInfo);
                    Console.WriteLine(menuList.FoodPrice);
                    Console.WriteLine("            ");

                }
                SimpleTextCopyAndPaste();
            }
            else
            {
                Console.WriteLine("There are no menu options please add some");
                SimpleTextCopyAndPaste();
            }
        }

        private void DeleteMethodHelper()
        {
            Console.Clear();
            if (_menuRepository.MenuList().Count > 0)
            {
                foreach (Menu menuList in _menuRepository.MenuList())
                {
                    Console.WriteLine("ID # " + menuList.FoodId + " " + menuList.FoodName + "  #" + menuList.FoodNumber);

                }
            }
            else
            {
                Console.WriteLine("There are no menu options to delete");
                SimpleTextCopyAndPaste();
            }
        }
        private void DeleteMenuListing()
        {
            DeleteMethodHelper();

            Console.WriteLine("Which of these menu options would you like to delete?\n" +
                "Please use their ID number");
            int userInput = int.Parse(Console.ReadLine());

            bool delete = _menuRepository.RemoveMenuOption(userInput);
            if (delete)
            {
                Console.WriteLine("Menu option was successfully deleted");
                SimpleTextCopyAndPaste();
            }
            else
            {
                Console.WriteLine("Menu option could not be deleted");
                SimpleTextCopyAndPaste();
            }
        }
    }
}
