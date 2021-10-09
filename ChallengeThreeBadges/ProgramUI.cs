using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChallengeThreeBadges
{
    class ProgramUI
    {
        public void Run()
        {

        }

        public void Main()
        {
            bool running = true;
            while (running)
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
                       
                        break;
                    case 2:
                      
                        break;
                    case 3:
                        
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
    }
}
