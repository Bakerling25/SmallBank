
using System;
using System.Collections.Generic;
using System.Text;

namespace SmallBankOOP
{
    class Customer:User
    {
        private string cpr;
        private string fuldeNavn;
        private string efterNavn;
        private Adresse addresse;
        private string userName;
        private List<Account> accounts;

        public string Cpr
        {
            get { return cpr; }
            set { cpr = value; }
        }
        public string FuldeNavn
        { 
            get { return fuldeNavn; }
            set { fuldeNavn = value; }
        }
        public string EfterNavn
        {
            get { return efterNavn; }
            set { efterNavn = value; }
        }
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public List<Account> Accounts
        {
            get { return accounts; }
            set { accounts = value; }
        }
        public Adresse Adresse { get { return addresse; } set { addresse = value; } }
        public void ShowAllSaldo(List<Customer> customers)
        {
            Console.WriteLine("banken har disse kunder med deres konti og saldo: ");
            Console.ReadLine();
            foreach (Customer customer in customers)
            {
                for (int i = 0; i < Console.WindowWidth; i++)
                {
                    Console.Write("_");
                }
                Console.WriteLine();
                Console.ReadLine();
                Console.WriteLine(customer.UserName + "har disse konti hos banken: ");
                foreach (Account account in customer.accounts)
                {
                    for (int i = 0; i < Console.WindowWidth; i++)
                    {
                        Console.Write("_");
                    }
                    Console.ReadLine();
                    account.ShowSaldo();
                    
                }
            }
        }
        public double Deposit(List<Customer> customers, string bruger, int kontinummer, double amount)
        {
            foreach (Customer customer in customers)
            {
                if (customer.UserName == bruger)
                {
                    foreach (Account account in customer.accounts)
                    {
                        if (account.KontiNummer == kontinummer)
                        {
                            if (account.AccountType == AccountType.Indlån)
                            {
                                account.Saldo += amount;
                                Console.WriteLine("nye saldo er: " + account.Saldo);
                                Console.ReadLine();
                            }
                            else if (account.AccountType == AccountType.Udlån)
                            {
                                account.Saldo -= amount;
                                Console.WriteLine("på konti er der nu : " + account.Saldo);
                                Console.ReadLine();
                            }
                        }
                    }
                }
            }
            return amount;
        }
        public void Withdraw(List<Customer> customers, string bruger, int kontinummer, double udtræk)
        {
            foreach (Customer customer in customers)
            {
                if (customer.UserName == bruger)
                {
                    foreach (Account account in customer.accounts)
                    {
                        if (account.KontiNummer == kontinummer)
                        {
                            if (account.AccountType == AccountType.Indlån)
                            {
                                account.Saldo -= udtræk;
                                Console.WriteLine("nye saldo er: " + account.Saldo);
                                Console.ReadLine();
                            }
                            else if (account.AccountType == AccountType.Udlån)
                            {
                                account.Saldo += udtræk;
                                Console.WriteLine("på konti er der nu : " + account.Saldo);
                                Console.ReadLine();
                            }
                        }
                    }
                }
            }
        }
        public Customer(string forNavn, string brugerNavn, string efterNavn, string paswd, Adresse adresse, List<Account> accounts, string cprNummer, int userID, string email)
        {
            UserID = userID;
            Email = email;
            Cpr = cprNummer;
            FuldeNavn = forNavn;
            EfterNavn = efterNavn;
            addresse = adresse;
            UserName = brugerNavn;
            Accounts = accounts;
            Password = paswd;
            RegisterDate = DateTime.Now;
        }

    }
}
