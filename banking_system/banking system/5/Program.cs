using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace oop_group
{
    class Program
    {

        static void Main(string[] args)
        {


            int n;
            do
            {
                Console.Write("\n\n\n\t***************** WELCOME TO OUR BANKING SYSTEM*******************");
                Console.Write("\n\t[1] Add Client");
                Console.Write("\n\t[2] Open New Account");
                Console.Write("\n\t[3] Deposit Money");
                Console.Write("\n\t[4] Withdraw Money");
                Console.Write("\n\t[5] Transfer Money");
                Console.Write("\n\t[6] Search For Client ");
                Console.Write("\n\t[7] Search For Account");
                Console.Write("\n\t[8] Display List Of Clients");
                Console.Write("\n\t[9] Display List Of Accounts");
                Console.Write("\n\t[10] Display date");
                Console.Write("\n\t[11] Close Account");
                Console.Write("\n\t[12] Exit");
                Console.Write("\n\tplease, select your choice");
                n = Convert.ToInt32(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        MainSystem.AddClient();
                        break;
                    case 2:
                        MainSystem.Add_Acount();
                        break;
                    case 3:
                        MainSystem.Deposit();
                        break;
                    case 4:
                        MainSystem.Withdraw();
                        break;
                    case 5:
                        MainSystem.Transfare();
                        break;
                    case 6:
                        MainSystem.SearchClient();
                        break;
                    case 7:
                        MainSystem.SearchAccount();
                        break;
                    case 8:
                        MainSystem.DisplayOpClients();
                        break;
                    case 9:
                        MainSystem.DisplayOfAcounts();
                        break;
                    case 10:
                        MainSystem.SearchForAcuontDt();
                        break;
                    case 11:
                        MainSystem.CloseAccount();
                        break;
                    case 12:
                        break;

                }

            } while (n != 12);
        }
    }
    class account
    {
        protected decimal Balance;
        protected long AccountID;
        protected string Dt;



        public account()
        {

        }

        public account(long accountID, decimal balance, string dt)
        {
            AccountID = accountID;
            Balance = balance; // is better to be proparty 
            Dt = dt;
        }

        public void PrintInfoaccount()
        {
            Console.WriteLine("Balance: " + Balance);
            Console.WriteLine("Account ID:" + AccountID);
        }

    }


    class bussiness : account
    {
        // private readonly string accountID;

        public bussiness()
        {

        }
        public bussiness(long accountID, decimal balance, string dt) : base(accountID, balance, dt)
        {


        }
        public void DisplayOfAcounts(ArrayList BussinessAccount)
        {

            Console.WriteLine(" ~~~~~~Bussiness Account~~~~~~~~~");
            foreach (bussiness opjcet9 in BussinessAccount)
            {

                opjcet9.PrintInfo_account();

            }



        }
        public long get_id(bussiness opject7)
        {
            return opject7.AccountID;
        }




        public bussiness Add_Acount(long AccountIDbussiness)
        {

            Console.Write("Enter amount of balance , please: ");
            decimal Account_Balance = Convert.ToDecimal(Console.ReadLine());

            string dt = DateTime.Now.ToString().Remove(10);

            bussiness object4 = new bussiness(AccountIDbussiness, Account_Balance, dt);
            return object4;


        }
        public void Withdraw(ArrayList BussinessAccount)
        {
            Console.Write("Enter money that you want to Withdraw: ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter ID: ");
            string search = Console.ReadLine();
            int counter = 3; // num of trying
                             //بحث في لست الحساب التجاري  
            while (counter > 0)
            {
                if (search.Length == 10)
                {
                    foreach (bussiness i in BussinessAccount)
                    {
                        if (Convert.ToInt64(search) == i.AccountID)
                        {//لابد ان يكون  المبلغ المراد سحبه في حدود الميلون
                            if (amount <= 1000000)
                            {
                                // نتأكد اننا لم نسحب اكثر من سالب مليون 
                                if (i.Balance - amount >= -1000000)
                                {//ادا تاأكدنا  اننا لم نسحب اكثر من سالب ملييون نبدأ السحب بطرح رصيد الحساب من العدد المراد سحبه 

                                    i.Balance -= amount;
                                    Console.WriteLine("\n\nWithdraw successfully! in BussinessAccount");
                                    counter = 0;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("You Can not Winthdraw more than 1,000,000.");
                                    counter = 0;
                                    break;

                                }

                            }
                            else
                            {
                                Console.WriteLine("You Can not Winthdraw more than 1,000,000.");
                                counter = 0;
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Acount is not found!!");
                            counter = 0;
                            break;
                        }
                    }

                }

                else
                {

                    Console.WriteLine($"Wrong ID, please try again. you just have {counter} chances!");
                    search = Console.ReadLine();
                    counter--;

                }
            }
        }
        public void Deposit(ArrayList BussinessAccount)
        {
            Console.WriteLine("Enter money: ");
            decimal mony = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter ID: ");
            string search = Console.ReadLine();
            int counter = 3; // num of trying  
            while (counter > 0)
            {
                if (search.Length == 10)
                {
                    foreach (bussiness i in BussinessAccount)
                    {
                        if (Convert.ToInt64(search) == i.AccountID)
                        {
                            i.Balance += mony;
                            Console.WriteLine("\n\nDeposited successfully!");
                            counter = 0;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Acount is not found!!");
                            counter = 0;
                            break;
                        }
                    }
                }
                else
                {

                    Console.WriteLine($"Wrong ID, please try again. you just have {counter} chances!");
                    search = Console.ReadLine();
                    counter--;

                }
            }
        }


        // البحث عن الحساب
        public void SearchAccount(ArrayList BussinessAccount, long AccountIDbussiness)
        {
            Console.Write("Enter The ID of The Account: ");
            string searchingAccountID = Console.ReadLine();
            bool isFound = false;
            if (searchingAccountID.Length == 10)
            {
                foreach (bussiness account in BussinessAccount)
                {
                    if (account.AccountID == Convert.ToInt64(searchingAccountID))
                    {
                        account.PrintInfo_account();
                        isFound = true;
                    }
                }

                if (isFound == false)
                {
                    Console.WriteLine("This Account is NOT FOUND!");

                }
            }

            else
            {
                Console.WriteLine("Wrong Account ID.");
            }

        }

        public void SearchForAcuontDt(ArrayList BussinessAccount, long AccountIDbussiness)
        {
            // Read client ID from user
            Console.Write("\nEnter date in the following format (DD/MM/YYYY): ");
            string ttd = Console.ReadLine();
            bool isFound = false;

            // Search for ID in ArrayList

            foreach (bussiness opjcet5 in BussinessAccount)
            {
                if (opjcet5.Dt == ttd)
                {
                    opjcet5.PrintInfo_account();
                    isFound = true;
                }
            }

            if (isFound == false)
                Console.WriteLine("This Acuont is not found !!!");

        }
        public void CloseAccount(ArrayList BussinessAccount)
        {
            Console.Write("Enter The ID of The Account: ");
            string searchDelete = Console.ReadLine();
            bool isFound = false;
            if (searchDelete.Length == 10)
            {
                foreach (bussiness account in BussinessAccount)
                {
                    if (account.AccountID == Convert.ToInt64(searchDelete))
                    {
                        if (account.Balance > 0)
                        {
                            Console.WriteLine("Please Withdraw all money that you deposite before close the account.");
                            //MainSystem.Withdraw();
                            BussinessAccount.Remove(account);
                            Console.WriteLine("Account was deleted.");
                            isFound = true;
                            break;
                        }
                        if (account.Balance < 0)
                        {
                            Console.WriteLine("Please deposite all money before close the account.");
                            //MainSystem.Deposit();
                            Console.WriteLine(account.Balance);
                            isFound = true;
                            break;
                        }
                        else
                        {
                            BussinessAccount.RemoveAt(BussinessAccount.IndexOf(account));
                            Console.WriteLine("Account was delete.");
                            isFound = true;
                            break;
                        }
                    }

                }

                if (isFound == false)
                {
                    Console.WriteLine("This Account is NOT FOUND!" + "\a");

                }
            }

            else
            {
                Console.WriteLine("Wrong Account ID.");
            }
        }
        //التحويل
        public void Transfare(ArrayList BussinessAccount)
        {
            Console.WriteLine("Enter money to transfer: ");
            long mony = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("enter ID of first account");
            string search1 = Console.ReadLine();
            Console.WriteLine("enter ID of second account");
            string search2 = Console.ReadLine();
            bool x = true;
            bool y = true;
            int counter1 = 3; // num of trying
            int counter2 = 3;
            if (search1 != search2)
            {
                while (counter1 > 0 || counter2 > 0)
                {
                    if (search1.Length == 10 && search2.Length == 10)//اذا كانت عملية الادخال للاي دي للحسابين صحيحة
                    {
                        foreach (bussiness i in BussinessAccount)//بيدور عن الاي دي الاول في الحساب التجاري
                        {
                            if (Convert.ToInt64(search1) == i.AccountID)
                            {
                                x = false;
                                foreach (bussiness j in BussinessAccount)//بيدور عن الاي دي الثاني في الحساب التجاري
                                {
                                    if (Convert.ToInt64(search2) == j.AccountID)
                                    {
                                        if (i.Balance > -1000000 && mony < 1000000)
                                        {
                                            i.Balance -= mony;
                                            j.Balance += mony;
                                            Console.WriteLine("\n\ntransfere successfully!");
                                            counter1 = 0;
                                            counter2 = 0;
                                            break;
                                        }
                                        else
                                        {

                                            Console.WriteLine("You Can not transfer more than 1,000,000.");
                                            counter1 = 0;
                                            counter2 = 0;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        {
                                            Console.WriteLine("operation is filled!");
                                            counter1 = 0;
                                            counter2 = 0;
                                            break;
                                        }
                                    }
                                }
                            }
                        }

                        if (x == true)
                        {
                            Console.WriteLine("the first account is not found!");
                            counter1 = 0;
                            counter2 = 0;
                        }

                    }
                    else if (search1.Length != 10 && search2.Length == 10)//اذا كانت عملية الادخال للاي دي للحساب الاول خاطئة وللثاني صحيحة
                    {
                        Console.WriteLine($"The ID ({search1}) is wrong, please try again. you just have {counter1} chances!");
                        search1 = Console.ReadLine();
                        counter1--;
                    }
                    else if (search2.Length != 10 && search1.Length == 10)//اذا كانت عملية الادخال للاي دي للحساب الثاني خاطئة وللاول صحيحة
                    {
                        Console.WriteLine($"The ID ({search2}) is wrong, please try again. you just have {counter2} chances!");
                        search2 = Console.ReadLine();
                        counter2--;
                    }
                    else//اذا كانت عملية الادخال للاي دي لكلا الحسابين خاطئة
                    {
                        Console.WriteLine($"The ID ({search1}) and ID ({search2}) are wrong, please try again. you just have {counter1} chances!");
                        Console.WriteLine("Enter the first ID:");
                        search1 = Console.ReadLine();
                        Console.WriteLine("Enter the second ID:");
                        search2 = Console.ReadLine();
                        counter1--;
                        counter2--;
                    }

                }
            }
            else
            {
                Console.WriteLine("ERROR OPREATION!!!");
            }

        }
        public void PrintInfo_account()
        {
            base.PrintInfoaccount();
        }

    }
    class current : account
    {
        //private readonly string accountID;

        public current()
        {

        }
        public current(long accountID, decimal balance, string dt) : base(accountID, balance, dt)
        {

        }
        public current Add_Acount(long AccountIDcurrent)
        {
            Console.Write("Enter amount of balance , please: ");
            decimal Account_Balance = Convert.ToDecimal(Console.ReadLine());
            string dt = DateTime.Now.ToString().Remove(10);
            current object4 = new current(AccountIDcurrent, Account_Balance, dt);
            return object4;
        }
        public void DisplayOfAcounts(ArrayList CurrentAcount)
        {


            Console.WriteLine();
            Console.WriteLine(" ~~~~~~CurrentAcount~~~~~~~~~");
            foreach (current opjcet10 in CurrentAcount)
            {
                opjcet10.PrintInfo_account();

            }


        }
        public long get_id(current opject8)
        {
            return opject8.AccountID;
        }
        public void Withdraw(ArrayList CurrentAcount)
        {
            Console.Write("Enter money that you want to Withdraw: ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter ID: ");
            string search = Console.ReadLine();
            int counter = 3; // num of trying
                             //بحث في لست الحساب التجاري  
            while (counter > 0)
            {
                if (search.Length == 10)
                {
                    foreach (current i in CurrentAcount)
                    {
                        if (Convert.ToInt64(search) == i.AccountID)
                        {//لابد ان لايكون الحساب فارغ حتى يتم السحب
                            if (i.Balance == 0)
                            {
                                Console.WriteLine("This account is empty!.");
                                counter = 0;
                                break;
                            }
                            else
                            {
                                i.Balance -= amount;
                                Console.WriteLine("\n\nWithdraw successfully! in CurrentAcount");
                                counter = 0;
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Acount is not found!!");
                            counter = 0;
                            break;
                        }
                    }
                }

                else
                {

                    Console.WriteLine($"Wrong ID, please try again. you just have {counter} chances!");
                    search = Console.ReadLine();
                    counter--;

                }
            }
        }
        public void Deposit(ArrayList CurrentAcount)
        {
            Console.WriteLine("Enter money: ");
            decimal mony = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter ID: ");
            string search = Console.ReadLine();
            int counter = 3; // num of trying  
            while (counter > 0)
            {
                if (search.Length == 10)
                {

                    foreach (current i in CurrentAcount)
                    {
                        if (Convert.ToInt64(search) == i.AccountID)
                        {
                            i.Balance += mony;
                            Console.WriteLine(i.AccountID);
                            Console.WriteLine("\n\nDeposited successfully!");
                            counter = 0;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Acount is not found!!");
                            counter = 0;
                            break;
                        }


                    }
                }
                else
                {

                    Console.WriteLine($"Wrong ID, please try again. you just have {counter} chances!");
                    search = Console.ReadLine();
                    counter--;

                }
            }

        }


        // البحث عن الحساب
        public void SearchAccount(ArrayList CurrentAcount)
        {
            Console.Write("Enter The ID of The Account: ");
            string searchingAccountID = Console.ReadLine();
            bool isFound = false;
            if (searchingAccountID.Length == 10)
            {

                foreach (current client in CurrentAcount)
                {
                    if (client.AccountID == Convert.ToInt64(searchingAccountID))
                    {
                        client.PrintInfo_account();
                        isFound = true;
                    }
                }
                if (isFound == false)
                {
                    Console.WriteLine("This Account is NOT FOUND!");

                }
            }

            else
            {
                Console.WriteLine("Wrong Account ID.");
            }

        }

        public void SearchForAcuontDt(ArrayList CurrentAcount)
        {
            // Read client ID from user
            Console.Write("\nEnter date in the following format (DD/MM/YYYY): ");
            string ttd = Console.ReadLine();
            bool isFound = false;

            // Search for ID in ArrayList
            foreach (current opjcet4 in CurrentAcount)
            {

                if (opjcet4.Dt == ttd)
                {
                    opjcet4.PrintInfo_account();
                    isFound = true;
                }
            }


            if (isFound == false)
                Console.WriteLine("This Acuont is not found !!!");

        }
        public void CloseAccount(ArrayList CurrentAcount)
        {
            Console.Write("Enter The ID of The Account: ");
            string searchDelete = Console.ReadLine();
            bool isFound = false;
            if (searchDelete.Length == 10)
            {
                foreach (current client in CurrentAcount)
                {
                    if (client.AccountID == Convert.ToInt64(searchDelete))
                    {
                        if (client.Balance > 0)
                        {

                            Console.WriteLine("Account was delete.");
                            CurrentAcount.RemoveAt(CurrentAcount.IndexOf(client));
                            isFound = true;
                            break;
                        }
                        else
                        {
                            CurrentAcount.RemoveAt(CurrentAcount.IndexOf(client));
                            Console.WriteLine("Account was delete.");
                            isFound = true;
                            break;
                        }

                    }
                }
                if (isFound == false)
                {
                    Console.WriteLine("This Account is NOT FOUND!" + "\a");

                }
            }

            else
            {
                Console.WriteLine("Wrong Account ID.");
            }
        }
        //التحويل
        public void Transfare(ArrayList CurrentAcount)
        {
            Console.WriteLine("cuu");
            Console.WriteLine("Enter money to transfer: ");
            long mony = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("enter ID of first account");
            string search1 = Console.ReadLine();
            Console.WriteLine("enter ID of second account");
            string search2 = Console.ReadLine();
            bool x = true;
            bool y = true;
            int counter1 = 3; // num of trying
            int counter2 = 3;
            if (search1 != search2)
            {

                while (counter1 > 0 || counter2 > 0 && search1 != search2)
                {
                    if (search1.Length == 10 && search2.Length == 10)//اذا كانت عملية الادخال للاي دي للحسابين صحيحة
                    {
                        foreach (current i in CurrentAcount)//بيدور عن الاي دي الاول في الحساب الجاري
                        {
                            if (Convert.ToInt64(search1) == i.AccountID)
                            {
                                x = false;
                                foreach (current j in CurrentAcount)//بيدور عن الاي دي الثاني في الحساب الجاري
                                {
                                    if (Convert.ToInt64(search2) == j.AccountID)
                                    {
                                        if (i.Balance < 0)
                                        {
                                            Console.WriteLine("This first account is empty!.");
                                            counter1 = 0;
                                            counter2 = 0;
                                            break;
                                        }
                                        else
                                        {
                                            i.Balance -= mony;
                                            j.Balance += mony;
                                            Console.WriteLine("\n\ntransfere successfully!");
                                            counter1 = 0;
                                            counter2 = 0;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        {
                                            Console.WriteLine("operation is filled!");
                                            counter1 = 0;
                                            counter2 = 0;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        if (x == true)
                        {
                            Console.WriteLine("the first account is not found!");
                            counter1 = 0;
                            counter2 = 0;
                        }

                    }
                    else if (search1.Length != 10 && search2.Length == 10)//اذا كانت عملية الادخال للاي دي للحساب الاول خاطئة وللثاني صحيحة
                    {
                        Console.WriteLine($"The ID ({search1}) is wrong, please try again. you just have {counter1} chances!");
                        search1 = Console.ReadLine();
                        counter1--;
                    }
                    else if (search2.Length != 10 && search1.Length == 10)//اذا كانت عملية الادخال للاي دي للحساب الثاني خاطئة وللاول صحيحة
                    {
                        Console.WriteLine($"The ID ({search2}) is wrong, please try again. you just have {counter2} chances!");
                        search2 = Console.ReadLine();
                        counter2--;
                    }
                    else//اذا كانت عملية الادخال للاي دي لكلا الحسابين خاطئة
                    {
                        Console.WriteLine($"The ID ({search1}) and ID ({search2}) are wrong, please try again. you just have {counter1} chances!");
                        Console.WriteLine("Enter the first ID:");
                        search1 = Console.ReadLine();
                        Console.WriteLine("Enter the second ID:");
                        search2 = Console.ReadLine();
                        counter1--;
                        counter2--;
                    }

                }
            }
            else
            {
                Console.WriteLine("ERROR OPREATION!!");
            }


        }
        public void PrintInfo_account()
        {
            base.PrintInfoaccount();

        }

    }

    class Clients

    {


        private string mobile;
        public string FullName { get; set; }
        public long ID { get; set; }
        public string Job { get; set; }
        public string Address { get; set; }
        public int B_or_c { get; set; }
        public long AccountIDCurrent { get; set; }
        public long AccountIDBusiness { get; set; }


        public Clients(string fullName, long iD, string job, string mobile, string address, long idAccountbusiness, long idAccountcurrent, int b_or_c)
        {
            FullName = fullName;
            ID = iD;
            Job = job;
            Mobile = mobile;
            Address = address;
            B_or_c = b_or_c;
            AccountIDCurrent = idAccountcurrent;
            AccountIDBusiness = idAccountbusiness;

        }

        public string Mobile
        {
            get
            {
                return mobile;
            }
            set
            {
                if (value.Length == 9)
                {
                    mobile = value;
                }
                else
                {
                    Console.WriteLine("Wrong number, please try again: ");
                }
            }


        }

        public void PrintInfo_Client()
        {
            Console.WriteLine("Name: " + FullName);
            Console.WriteLine("Jop: " + Job);
            Console.WriteLine("Mobile Number: " + Mobile);
            Console.WriteLine("Address: " + Address);
            Console.WriteLine("Clinet ID:" + ID);
        }



    }
    static class MainSystem
    {
        private static ArrayList BussinessAccount;
        private static long idClient;
        private static ArrayList AddingClients;
        private static long AccountIDbussiness;
        private static long AccountIDcurrent;

        private static ArrayList CurrentAcount;
        static MainSystem()
        {
            AccountIDbussiness = 2020101000;
            idClient = 20201000;
            AccountIDcurrent = 2020101000;
            AddingClients = new ArrayList();

            BussinessAccount = new ArrayList();
            CurrentAcount = new ArrayList();
        }

        //اظافة عميل
        public static void AddClient()
        {
            Console.Write("Enter your full name, please: ");
            string fullName = Console.ReadLine();
            Console.WriteLine("Enter your job, please: ");
            string job = Console.ReadLine();
            Console.WriteLine("Enter your mobile number, please: ");
            string mobile = Console.ReadLine();
            Console.WriteLine("Enter your address: ");
            string address = Console.ReadLine();
            Console.Write("choose type of accont 1 for BussinessAcount ,2 for currentAcount");
            string type = Console.ReadLine();
            int b = 1;
            int c = 2;
            bool x = false;

            if (type == "1")
            {

                foreach (Clients i in AddingClients)
                {
                    if (fullName == i.FullName && i.B_or_c == 1)
                    {
                        x = true;
                        Console.WriteLine("already have account!!");
                        break;
                    }

                }

                if (x == false)
                {
                    bussiness obj1 = new bussiness();
                    BussinessAccount.Add(obj1.Add_Acount(AccountIDbussiness));
                    Clients object2 = new Clients(fullName, idClient, job, mobile, address, AccountIDbussiness,0, b);
                    AddingClients.Add(object2);
                    idClient++;
                    AccountIDbussiness++;
                }
            }
            else if (type == "2")
            {
                foreach (Clients i in AddingClients)
                {
                    if (fullName == i.FullName && i.B_or_c == 2)
                    {
                        x = true;
                        Console.WriteLine("already have account!!");
                        break;
                    }
                }

                if (x == false)
                {
                    current obj1 = new current();
                    CurrentAcount.Add(obj1.Add_Acount(AccountIDcurrent));
                    Clients object2 = new Clients(fullName, idClient, job, mobile, address,0, AccountIDcurrent, c);
                    AddingClients.Add(object2);
                    idClient++;
                    AccountIDcurrent++;
                }

            }

        }

        // انشاء حساب
        public static void Add_Acount()
        {
            Console.Write("choose type of accont 1 for BussinessAcount ,2 for currentAcount");
            string type = Console.ReadLine();
            Console.Write("enter id of the client");
            long praviusClient_Id = Convert.ToInt64(Console.ReadLine());
            bool y = false;

            if (type == "1")
            {
                foreach (Clients i in AddingClients)
                {
                    if (praviusClient_Id == i.ID && i.B_or_c == 2)
                    {

                        y = true;
                        bussiness obj1 = new bussiness();
                        BussinessAccount.Add(obj1.Add_Acount(AccountIDbussiness));
                        i.AccountIDBusiness = AccountIDbussiness;
                        AccountIDbussiness++;
                        break;
                    }
                }
            }
            else if (type == "2")
            {
                foreach (Clients i in AddingClients)
                {
                    if (praviusClient_Id == i.ID && i.B_or_c == 1)
                    {
                        y = true;
                        current obj1 = new current();
                        CurrentAcount.Add(obj1.Add_Acount(AccountIDcurrent));
                        i.AccountIDCurrent = AccountIDcurrent;
                        AccountIDcurrent++;
                        break;
                    }
                }
            }
            if (y == false)
            {
                Console.WriteLine("cannot creat an acount... you have to be a clinet at  first");
            }
        }
        // للبحث عن العميل
        public static void SearchClient()
        {
            Console.Write("Enter The ID of The Clinet: ");
            string searchingClientID = Console.ReadLine();
            bool isFound = false;
            if (searchingClientID.Length == 8)
            {
                foreach (Clients client in AddingClients)
                {
                    if (client.ID == Convert.ToInt64(searchingClientID))
                    {
                        client.PrintInfo_Client();
                        isFound = true;
                    }
                }
                if (isFound == false)
                {
                    Console.WriteLine("This Client is NOT FOUND!");

                }
            }
            else
            {
                Console.WriteLine("Wrong Client ID.");
            }
        }
        public static void DisplayOpClients()
        {
            bussiness obj1 = new bussiness();
            current obj2 = new current();
            foreach (Clients opjcet6 in AddingClients)
            {

                Console.WriteLine(" ~~~~~~Client Information~~~~~~~~~");
                opjcet6.PrintInfo_Client();
                foreach (bussiness opject7 in BussinessAccount)
                {
                    if (opjcet6.AccountIDBusiness == obj1.get_id(opject7))
                    {
                        Console.WriteLine(" ~~~~~~Bussiness Account~~~~~~~~~");
                        opject7.PrintInfo_account();
                        
                    }
                }
                foreach (current opject8 in CurrentAcount)
                {
                    if (opjcet6.AccountIDCurrent == obj2.get_id(opject8))
                    {
                        Console.WriteLine(" ~~~~~~Current Account~~~~~~~~~");
                        opject8.PrintInfo_account();

                    }
                }

            }
        }

        
        public static void DisplayOfAcounts()
        {
            bussiness obj1 = new bussiness();
            obj1.DisplayOfAcounts(BussinessAccount);
            current obj2 = new current();
            obj2.DisplayOfAcounts(CurrentAcount);

        }
        public static void Withdraw()
        {
            Console.Write("choose type of accont 1 for BussinessAcount ,2 for currentAcount");
            string type = Console.ReadLine();
            if (type == "1")
            {
                bussiness obj1 = new bussiness();
                obj1.Withdraw(BussinessAccount);
            }
            else if (type == "2")
            {
                current obj1 = new current();
                obj1.Withdraw(CurrentAcount);


            }
        }
        public static void Deposit()
        {
            Console.Write("choose type of accont 1 for BussinessAcount ,2 for currentAcount");
            string type = Console.ReadLine();
            if (type == "1")
            {
                bussiness obj1 = new bussiness();
                obj1.Deposit(BussinessAccount);
            }
            else if (type == "2")
            {
                current obj1 = new current();
                obj1.Deposit(CurrentAcount);

            }
        }


        // البحث عن الحساب
        public static void SearchAccount()
        {

            Console.Write("choose type of accont 1 for BussinessAcount ,2 for currentAcount");
            string type = Console.ReadLine();
            if (type == "1")
            {
                bussiness obj1 = new bussiness();
                obj1.SearchAccount(BussinessAccount, AccountIDbussiness);
            }
            else if (type == "2")
            {
                current obj1 = new current();
                obj1.SearchAccount(CurrentAcount);

            }
        }


        public static void SearchForAcuontDt()
        {

            Console.Write("choose type of accont 1 for BussinessAcount ,2 for currentAcount");
            string type = Console.ReadLine();
            if (type == "1")
            {
                bussiness obj1 = new bussiness();
                obj1.SearchForAcuontDt(BussinessAccount, AccountIDbussiness);
            }
            else if (type == "2")
            {
                current obj1 = new current();
                obj1.SearchForAcuontDt(CurrentAcount);

            }
        }
        public static void CloseAccount()
        {
            Console.Write("choose type of accont 1 for BussinessAcount ,2 for currentAcount");
            string type = Console.ReadLine();
            if (type == "1")
            {
                bussiness obj1 = new bussiness();
                obj1.CloseAccount(BussinessAccount);
            }
            else if (type == "2")
            {
                current obj1 = new current();
                obj1.CloseAccount(CurrentAcount);

            }
        }
        //التحويل
        public static void Transfare()
        {
            Console.Write("choose type of accont 1 for BussinessAcount ,2 for currentAcount");
            string type = Console.ReadLine();
            if (type == "1")
            {
                bussiness obj1 = new bussiness();
                obj1.Transfare(BussinessAccount);
            }
            else if (type == "2")
            {
                current obj1 = new current();
                obj1.Transfare(CurrentAcount);

            }
        }
    }
}

