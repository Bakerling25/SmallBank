using System;
using System.Collections.Generic;
using System.Text;

namespace SmallBankOOP
{
    class Administration:User
    {
        private string adminNavn;
        public string AdminNavn { get { return adminNavn; } set { adminNavn = value; } }

        public void DeleteKonti(List<Customer> customers, string username, int kontinummer)
        {
            foreach (Customer customer in customers)
            {
                if (customer.UserName == username)
                {
                    foreach (Account items in customer.Accounts)
                    {

                    }
                }
            }
        }
        public void DeleteKonto()
        {

        }
        public void RegisterKunde()
        {

        }
        public void RegisterNyKonti()
        {

        }
        public void CheckSamledeKapital()
        {

        }
        public void InsertMoney()
        {

        }
        public void ShowKundeKonti()
        {

        }
        public void Login()
        {

        }
        public void UpdateKunde()
        {

        }
    }
}
