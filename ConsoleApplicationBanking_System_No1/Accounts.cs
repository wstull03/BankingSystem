using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationBanking_System_No1
{
    class Accounts
    {
        Random random = new Random(DateTime.Now.Millisecond);


        //fields v
        private int accountNumber = 123456789;
        private decimal accountBalance = 0.00m;
        private Clients clients = new Clients();
        public string type = "Account";

        //Properties
        public virtual int AccountNumber
        {
            get { return this.accountNumber; }
            set { this.accountNumber = value; }
        }

        public virtual decimal AccountBalance
        {
            get { return this.accountBalance; }
            set { this.accountBalance = value; }
        }

        public virtual Clients Clients
        {
            get { return this.clients; }
            set { this.clients = value; }
        }


        //methods v

        internal void ListServices()
        {
            //throw new NotImplementedException();
            int counter = 1;
            Console.WriteLine("Select Account Type (Enter 4 to Exit):");

            foreach (Accounts AccountType in Program.AccountTypes)
            {
                Console.WriteLine("{0} - {1}", counter++, AccountType);
            }
        }

        public virtual void viewAccountDetails()
        {
            Console.WriteLine();
            Console.WriteLine(this.clients.FullName + " No. " + this.accountNumber + " " + this.accountBalance);
        }

        public virtual void deposit()
        {
            Console.WriteLine();
            Console.WriteLine("Deposit Amount: ");
            //decimal depositAmount = decimal.Parse(Console.ReadLine());

            decimal depositAmount = 0.00m;

            do
            {

                string depositString = Console.ReadLine();
                decimal.TryParse(depositString, out depositAmount);

            } while (depositAmount == 0.00m);

            this.accountBalance += depositAmount;
            //Console.WriteLine("The new account balance is: " + accountBalance);        
          
            StreamWriter writer = File.AppendText("AccountSummary.txt");
            using (writer)
            {
                writer.WriteLine(DateTime.Now + "\tdeposited\t+" +  depositAmount + "\t" + this.accountBalance );
            }
        }

        public virtual void withdraw()
        {
            Console.WriteLine();
            Console.WriteLine("Withdrawal Amount: ");
            //decimal withdrawalAmount = decimal.Parse(Console.ReadLine());

            decimal withdrawalAmount = 0.00m;

            do
            {

            string withdrawalString = Console.ReadLine();
            decimal.TryParse(withdrawalString, out withdrawalAmount);

            } while (withdrawalAmount == 0.00m);

            this.accountBalance -= withdrawalAmount;
            //Console.WriteLine("The new account balance is: " + accountBalance);

            StreamWriter writer = File.AppendText("AccountSummary.txt");
            using (writer)
            {
                writer.WriteLine(DateTime.Now + "\t\nwithdrew\t-" + withdrawalAmount + "\t" + this.accountBalance);
            }

        }

        public virtual void generateAccountNumber()
        {
            accountNumber = random.Next(1000000000);
        }



        //constructors v
        public Accounts()
        {
            generateAccountNumber();            
        }

        public Accounts (Clients clients, decimal accountBalance)
        {
            this.Clients = clients;
            this.AccountBalance = accountBalance;
            generateAccountNumber();
        }




    }
}
