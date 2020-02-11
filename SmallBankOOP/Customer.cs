
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
        public void ShowAllSaldo()
        {

        }
        public double Deposit(double amount)
        {
            return amount;
        }
        public void Withdraw()
        {

        }
        public Customer(string forNavn, string brugerNavn, string efterNavn, string paswd, Adresse adresse, List<Account> accounts, string cprNummer)
        {
            Cpr = cprNummer;
            FuldeNavn = forNavn;
            EfterNavn = efterNavn;
            addresse = adresse;
            userName = brugerNavn;
            Accounts = accounts;
        }

    }
}
