
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
        private string addresse;
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
        public string Addresse
        {
            get { return addresse; }
            set { addresse = value; }
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

        }
        public void Withdraw()
        {

        }

    }
}
