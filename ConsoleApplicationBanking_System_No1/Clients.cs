using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationBanking_System_No1
{
    class Clients
    {   
          
                  
        //fields v
        private string fullName = "Liam Stull";        
        private int memberID = 101;


        //Properties
        public virtual string FullName
        {
            get { return this.fullName; }
            set { this.fullName = value; }
        }

        public virtual int MemberID
        {
            get { return this.memberID; }
            set { this.memberID = value; }
        }


        //methods v
        public void viewClientInformation()
        {
            Console.WriteLine();
            Console.WriteLine(this.fullName + " Member ID: " + this.memberID);
        }



        //constructors v
        public Clients()
        {
        }

        public Clients(string fullName, int memberID)
        {
            this.FullName = fullName;
            this.MemberID = memberID;
        }



    }
}
