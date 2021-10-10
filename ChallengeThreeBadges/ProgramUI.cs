using BadgesClass;
using BadgesRepositroy;
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

        private BadgesRepo _badgesRepo = new BadgesRepo();
        public void Run()
        {
            SeedingBadgesList();
            Main();
        }

        public void Main()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();

                Console.WriteLine("Select a option and press enter\n" +
                    "1. Create a new badge\n" +
                    "2. Show badges list\n" +
                    "3. Edit badges \n" +
                    "4. Exit");

                int userInput = int.Parse(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        CreateNewBadges();
                        break;
                    case 2:
                        ListAllBadges();
                        break;
                    case 3:
                        EditBadges();
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
        public void SeedingBadgesList()
        {
            List<string> tierOneDoors = new List<string>();
            tierOneDoors.Add("Front door");
            tierOneDoors.Add("Tier 1 rooms");
            Badges tierOneBadges = new Badges(1150, tierOneDoors, "Tier 1 doors");

            List<string> topTierDoors = new List<string>();
            topTierDoors.Add("All computer room doors");
            topTierDoors.Add("All tier doors");
            topTierDoors.Add("All admin doors");
            topTierDoors.Add("Room 5600");
            Badges topTierBadges = new Badges(5600, topTierDoors, "Top Tier doors");

            _badgesRepo.CreateNewBadge(tierOneBadges);
            _badgesRepo.CreateNewBadge(topTierBadges);
        }
        
        public void SimpleTextCopyAndPaste()
        {
            Console.WriteLine("Please press enter to continue");
            Console.ReadLine();
        }



        public void CreateNewBadges()
        {
            Console.Clear();

            Badges newBadges = new Badges();

            Console.WriteLine("Please enter a ID for this badge");
            newBadges.BadgeId = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter a name for this badge");
            newBadges.BadgeName = Console.ReadLine();

            Door:
            Console.WriteLine("Please the door name this badge needs to access");
            newBadges.DoorCodeNames.Add(Console.ReadLine());

            Console.WriteLine("Would you like to add another door to this badge?");
            Console.WriteLine("Please press y to add another door or enter to return to main menu");
            ConsoleKeyInfo info = Console.ReadKey();
            if (info.Key == ConsoleKey.Enter)
            {
                _badgesRepo.CreateNewBadge(newBadges);
                Main();
            }
            if (info.Key == ConsoleKey.Y)
            {
                Console.Clear();
                goto Door;
            }
            
        }

        public void ListAllBadges()
        {
            Console.Clear();

            Dictionary<int, List<string>> badgeList = _badgesRepo.GetListOfBadges();

            foreach(var badges in badgeList)
            {
                int IDs = badges.Key;
                List<string> doorValue = badges.Value;

                Console.WriteLine("This badge ID " + IDs);
                Console.WriteLine($"This badge accesses  { string.Join(", ", doorValue)}");
                Console.WriteLine("__________________________________________");
            }
            SimpleTextCopyAndPaste();
        }

        public void EditBadges()
        {
            Console.Clear();
            ListAllBadges();

            Console.WriteLine("Please enter the ID of the badge you would like to update");
            int oldBadges = int.Parse(Console.ReadLine());
            

            List<string> oldDoorCodeNames = _badgesRepo.CheckKeys(oldBadges);
            Console.Clear();
            Console.WriteLine($"This badge accesses  { string.Join(", ", oldDoorCodeNames)}");
            Console.WriteLine("What would you like to change about this badge?\n" +
                "1. Remove a door code off\n" +
                "2. Add a door\n" +
                "3. Return to menu");
            int userInput = int.Parse(Console.ReadLine());
            bool inputCorrect = false;

            while(inputCorrect == false)
            {
                switch (userInput)
                {
                    case 1:
                        inputCorrect = true;
                        Console.WriteLine("Please enter the name of a door you would like to remove");
                        var doorCodeNameToRemove = Console.ReadLine();
                        bool doorRemoved = _badgesRepo.RemoveDoorCodeNames(oldBadges, doorCodeNameToRemove);
                        if (doorRemoved)
                        {
                            Console.WriteLine(doorRemoved + "  Has been removed");
                            Console.WriteLine($"This badge now accesses  { string.Join(", ", oldDoorCodeNames)}");
                            SimpleTextCopyAndPaste();
                        }
                        else
                        {
                            Console.WriteLine("That door is does not exist");
                            Console.WriteLine("Would you like to try again?\n" +
                                "Please press y for yes or n to return to menu");
                            ConsoleKeyInfo info = Console.ReadKey();
                            if (info.Key == ConsoleKey.N)
                            {
                                Main();
                            }
                            if (info.Key == ConsoleKey.Y)
                            {
                                Console.Clear();
                                Console.WriteLine($"This badge accesses  { string.Join(", ", oldDoorCodeNames)}");
                                goto case 1;
                            }
                        }
                        break;
                    case 2:
                        inputCorrect = true;
                        Console.WriteLine("Please enter a name for a door you would like to add");
                        var doorCodeNameToAdd = Console.ReadLine();
                        _badgesRepo.AddDoorCodeNames(oldBadges, doorCodeNameToAdd);
                        Console.WriteLine(doorCodeNameToAdd +" Is now on this badge");
                        SimpleTextCopyAndPaste();
                        Main();
                        break;
                    case 3:
                        inputCorrect = true;
                        Main();
                        break;
                    default:
                        Console.WriteLine("Invaild input");
                        userInput = int.Parse(Console.ReadLine());
                        break;
                }
            }

        }
    }
}
