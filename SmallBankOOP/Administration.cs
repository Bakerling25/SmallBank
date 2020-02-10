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
        public void DeleteKonto(List<Customer> customers, string bruger)
        {
            foreach (Customer customer in customers)
            {
                if (customer.UserName == bruger)
                {
                    customers.Remove(customer);
                }
            }

        }
        public void RegisterKunde(List<Customer> customers)
        {
            string brugernavn;
            Console.WriteLine("ny bruger laves nu: ");
            Console.Write("Brugernavn er: ");
            brugernavn = Console.ReadLine();
            foreach (Customer customer in customers)
            {
                if (brugernavn == customer.UserName)
                {
                    goto end;
                }
            }
            Console.WriteLine();
            Console.Write("Password er: ");
            string password = Console.ReadLine();


        end:
            Console.WriteLine("brugernavn eksistere allerede");
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
