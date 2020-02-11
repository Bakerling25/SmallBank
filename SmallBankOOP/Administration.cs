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
            Console.Write("CPR-nummer for kunden er: ");
            string cprNummer = Console.ReadLine();
            Console.Write("Password er: ");
            string password = Console.ReadLine();
            Console.WriteLine();
            Console.Write("kundens fornavn er: ");
            string forNavn = Console.ReadLine();
            Console.WriteLine();
            Console.Write("kundens efternavn er: ");
            string efterNavn = Console.ReadLine();
            Console.WriteLine();
            List<Account> accounts = new List<Account>();
            Console.Write("Kundens gadenavn er: ");
            string streetName = Console.ReadLine();
            Console.WriteLine();
            Console.Write("By kunden lever i: ");
            string byNavn = Console.ReadLine();
            Console.WriteLine();
            Console.Write("byens Zip kode: ");
            int zipCode = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.Write("hus nummer for kundens bolig: ");
            int husNummer = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.Write("er der et etagenummer ved adressen: Y/N ");
            string yesOrNo = Console.ReadLine();
            if (yesOrNo.Contains("Y"))
            {
                Console.WriteLine();
                Console.Write(" 0 er lig med stuen, 1 er første sal ... \r\nhvad etage bor kunden på: ");
                int etageNummer = Convert.ToInt32(Console.ReadLine());

                Adresse adresse =new Adresse(streetName, byNavn, zipCode, husNummer, etageNummer);
                customers.Add(new Customer(forNavn, brugernavn, efterNavn, password, adresse, accounts, cprNummer));
            }
            else
            {
                Adresse adresse = new Adresse(streetName, byNavn, zipCode, husNummer);
                customers.Add(new Customer(forNavn, brugernavn, efterNavn, password, adresse, accounts, cprNummer));
            }

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
