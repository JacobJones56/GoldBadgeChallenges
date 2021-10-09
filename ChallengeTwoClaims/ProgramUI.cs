using ClaimsClass;
using ClaimsRepositroy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChallengeTwoClaims
{
    class ProgramUI
    {
        private ClaimsRepository _claimsRepository = new ClaimsRepository();

        public void Run()
        {
            SeedingClaimsList();
            Main();
        }
        
        public void Main()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();

                Console.WriteLine("Select a option and press enter\n" +
                    "1. Create a new claim\n" +
                    "2. View list of claims\n" +
                    "3. View one claim\n" +
                    "4. Exit");

                int userInput = int.Parse(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        CreateNewClaim();
                        break;
                    case 2:
                        ViewClaims();
                        break;
                    case 3:
                        ViewOneClaim();
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
        public void SeedingClaimsList()
        {
            DateTime date1 = new DateTime(2021, 12, 21);
            DateTime date2 = new DateTime(2021, 12, 31); 
            DateTime date3 = new DateTime(2021, 1, 12);
            DateTime date4 = new DateTime(2021, 12, 1);
           
            Claim testClaim = new Claim(1, "Car", "Crash", 560.00m, date1, date2, true);
            Claim testClaim2 = new Claim(2, "Home", "break in", 56.00m, date3, date4, false);

            _claimsRepository.CreateNewClaim(testClaim);
            _claimsRepository.CreateNewClaim(testClaim2);
        }
        public void SimpleTextCopyAndPaste()
        {
            Console.WriteLine("Please press enter to continue");
            Console.ReadLine();
        }
        private void CreateNewClaim()
        {
            Console.Clear();

            Claim newClaim = new Claim();

            // Type
            Console.WriteLine("Please enter the type of claim this is");
            newClaim.ClaimType = Console.ReadLine();
            // Description
            Console.WriteLine("Please enter details of this claim");
            newClaim.Description = Console.ReadLine();
            // Amount
            Console.WriteLine("Please enter the amount this claim will cost");
            newClaim.ClaimAmount = decimal.Parse(Console.ReadLine());
            // Date of the accident
            Console.WriteLine("Please enter the date of the accident (00/00/00)");
            newClaim.DateOfAccident = DateTime.Parse(Console.ReadLine());
           
            
            // Date of claim
            Console.WriteLine("Please enter the date of the claim (00/00/00)");
            newClaim.DateOfClaim = DateTime.Parse(Console.ReadLine());
    
            TimeSpan dateRange = newClaim.DateOfClaim - newClaim.DateOfAccident;

            if(dateRange.TotalDays <= 30)
            {
                newClaim.IsVaild = true;
            }
            else
            {
                newClaim.IsVaild = false;
            }
     
            _claimsRepository.CreateNewClaim(newClaim);

            SimpleTextCopyAndPaste();
        }
        private void ViewClaims()
        {
            Console.Clear();
            if (_claimsRepository.ClaimList().Count > 0)
            {
               
                foreach (Claim claimList in _claimsRepository.ClaimList())
                {
                    Console.WriteLine($"Claim ID { claimList.ClaimID}");
                    Console.WriteLine($"Type{ claimList.ClaimType}");
                    Console.WriteLine($"Description { claimList.Description}");
                    Console.WriteLine($"Amount ${ claimList.ClaimAmount}");
                    Console.WriteLine($"Date of Accident { claimList.DateOfAccident.ToString("d")}");
                    Console.WriteLine($"Date of claim { claimList.DateOfClaim.ToString("d")}");
                    Console.WriteLine($"Claim is valid {claimList.IsVaild}");
                    Console.WriteLine("_______________________________________");



                }
                SimpleTextCopyAndPaste();
            }
            else
            {
                Console.WriteLine("There are no claims please add some");
                SimpleTextCopyAndPaste();
            }
        }
        private void ViewOneClaim()
        {
            Console.Clear();
            var currentClaim = _claimsRepository.PeekClaim();
            Console.WriteLine($"Claim ID { currentClaim.ClaimID}");
            Console.WriteLine($"Type { currentClaim.ClaimType}");
            Console.WriteLine($"Description { currentClaim.Description}");
            Console.WriteLine($"Amount ${ currentClaim.ClaimAmount}");
            Console.WriteLine($"Date of Accident { currentClaim.DateOfAccident.ToString("d")}");
            Console.WriteLine($"Date of claim { currentClaim.DateOfClaim.ToString("d")}");
            Console.WriteLine($"Claim is valid {currentClaim.IsVaild}");
            Console.WriteLine("_______________________________________");

            Console.WriteLine("To process this claim press y otherwise any other key to exit to main menu");
            ConsoleKeyInfo info = Console.ReadKey();
            if (info.Key == ConsoleKey.Enter)
            {
                Main();
            }
            if (info.Key == ConsoleKey.Y)
            {
                _claimsRepository.RemoveClaim(currentClaim);
                Console.WriteLine("\nClaim has been processed");
                SimpleTextCopyAndPaste();
            }


        }
    }


}
