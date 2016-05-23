using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationBanking_System_No1
{
    class Program
    {

        public static List<Accounts> AccountTypes { get; set; } = new List<Accounts>();

        static void Main(string[] args)
        {

            Clients clients = new Clients();
            Accounts accounts = new Accounts();
            System.Threading.Thread.Sleep(1);

            StreamWriter writer = new StreamWriter("AccountSummary.txt");

            using (writer)
            {              
                writer.WriteLine("BANKING SYSTEM");
                writer.WriteLine("**************");
                writer.WriteLine(clients.FullName + " " + accounts.type + " " + "No."+ accounts.AccountNumber);
                writer.WriteLine();
            }

            Checking checking = new Checking();
            System.Threading.Thread.Sleep(1);
            writer = new StreamWriter("CheckingSummary.txt");

            using (writer)
            {
                writer.WriteLine("BANKING SYSTEM");
                writer.WriteLine("**************");
                writer.WriteLine(clients.FullName + " " + checking.type + " " + "No." + checking.AccountNumber);
                writer.WriteLine();
            }


            Savings savings = new Savings();
            System.Threading.Thread.Sleep(1);
            writer = new StreamWriter("SavingsSummary.txt");

            using (writer)
            {
                writer.WriteLine("BANKING SYSTEM");
                writer.WriteLine("**************");
                writer.WriteLine(clients.FullName + " " + savings.type + " " + "No." + savings.AccountNumber);
                writer.WriteLine();
            }

            Reserve reserve = new Reserve();
            writer = new StreamWriter("ReserveSummary.txt");

            using (writer)
            {
                writer.WriteLine("BANKING SYSTEM");
                writer.WriteLine("**************");
                writer.WriteLine(clients.FullName + " " + reserve.type + " " + "No." + reserve.AccountNumber);
                writer.WriteLine();
            }

            int userChoice = 0;

            do
            {               
                Console.WriteLine();
                Console.WriteLine("BANKING SYSTEM");
                Console.WriteLine("**************");
                Console.WriteLine("1 - View Client Information\n2 - View Account Balance\n3 - Deposit Funds\n4 - Withdraw Funds\n5 - Exit");
                int.TryParse(Console.ReadLine(), out userChoice);

                switch (userChoice)
                {

                    case 1:
                        
                        clients.viewClientInformation();
                        break;

                    case 2:

                        int accountBalanceSelection = 0;

                        do
                        {
                            Console.WriteLine();
                            //Console.WriteLine("1 - Checking\n2 - Savings\n3 - Reserve\n9 - Exit");
                            accounts.ListServices();

                            while(!int.TryParse(Console.ReadLine(), out accountBalanceSelection))
                            {
                                Console.WriteLine("Please enter a number");
                            }

                            try
                            {
                                Accounts selectedService = (Accounts)AccountTypes[accountBalanceSelection - 1];
                                Console.WriteLine();
                                selectedService.viewAccountDetails();
                                Console.WriteLine();
                            }
                            catch (Exception)
                            {                               
                                continue;                             
                            }

                        } while (accountBalanceSelection != 4);

                        break;

                    case 3:

                        int depositSelection = 0;

                        do
                        {
                            Console.WriteLine();
                            //Console.WriteLine("1 - Checking\n2 - Savings\n3 - Reserve\n9 - Exit");
                            accounts.ListServices();

                            while (!int.TryParse(Console.ReadLine(), out depositSelection))
                            {
                                Console.WriteLine("Please enter a number");
                            }

                            try
                            {
                                Accounts selectedService = (Accounts)AccountTypes[depositSelection - 1];
                                Console.WriteLine();
                                selectedService.deposit();
                                Console.WriteLine();
                            }
                            catch (Exception)
                            {
                                continue;
                            }

                        } while (depositSelection != 4);

                        break;

                    case 4:

                        int withdrawSelection = 0;

                        do
                        {
                            Console.WriteLine();
                            //Console.WriteLine("1 - Checking\n2 - Savings\n3 - Reserve\n9 - Exit");
                            accounts.ListServices();

                            while (!int.TryParse(Console.ReadLine(), out withdrawSelection))
                            {
                                Console.WriteLine("Please enter a number");
                            }

                            try
                            {
                                Accounts selectedService = (Accounts)AccountTypes[withdrawSelection - 1];
                                Console.WriteLine();
                                selectedService.withdraw();
                                Console.WriteLine();
                            }
                            catch (Exception)
                            {
                                continue;
                            }

                        } while (withdrawSelection != 4);

                        break;

                    case 5:

                        Console.WriteLine();
                        Console.WriteLine("Goodbye");
                        Console.WriteLine();
                        break;

                    default:

                        break;

                }

            } while (userChoice != 5);

        }
    }
}
