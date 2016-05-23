using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationBanking_System_No1
{
    class Savings:Accounts
    {
        Random random = new Random(DateTime.Now.Millisecond);

        //fields v
        private int accountNumber = 123456789;
        private decimal accountBalance = 0.00m;
        private Clients clients = new Clients();
        public string type = "Savings";

        //Properties
        public override int AccountNumber
        {
            get { return this.accountNumber; }
            set { this.accountNumber = value; }
        }

        public override decimal AccountBalance
        {
            get { return this.accountBalance; }
            set { this.accountBalance = value; }
        }

        public override Clients Clients
        {
            get { return this.clients; }
            set { this.clients = value; }
        }


        //methods v

        public override string ToString()
        {
            return this.type;
        }

        public override void viewAccountDetails()
        {
            Console.WriteLine();
            Console.WriteLine(this.clients.FullName + " " + this.type + " No. " + this.accountNumber + " " + this.accountBalance);
        }

        public override void deposit()
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

            StreamWriter writer = File.AppendText("SavingsSummary.txt");
            using (writer)
            {
                writer.WriteLine(DateTime.Now + "\tdeposited\t+" + depositAmount + "\t" + this.accountBalance);
            }
        }

        public override void withdraw()
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

            StreamWriter writer = File.AppendText("SavingsSummary.txt");
            using (writer)
            {
                writer.WriteLine(DateTime.Now + "\t\nwithdrew\t-" + withdrawalAmount + "\t" + this.accountBalance);
            }

        }

        public override void generateAccountNumber()
        {
            accountNumber = random.Next(1000000000);
        }



        //constructors v
        public Savings()
        {
            generateAccountNumber();
            Program.AccountTypes.Add((Accounts)this);
        }

        public Savings(Clients clients, decimal accountBalance)
        {
            this.Clients = clients;
            this.AccountBalance = accountBalance;
            generateAccountNumber();
            Program.AccountTypes.Add((Accounts)this);
        }


    }
}
