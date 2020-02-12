using System;
using System.Collections.Generic;
using System.Text;

namespace SmallBankOOP
{
    class Administration:User
    {
        private string adminNavn;

        public string AdminNavn { get { return adminNavn; } set { adminNavn = value; } }
        /// <summary>
        /// med denne vil man slette en bestem brugers konti, ud fra hvad kundens brugernavn er
        /// og hvad for en af kontierne der har det kontinummer man har givet
        /// </summary>
        /// <param name="customers">hele listen af kunder, kan ses som en database, hvor alle tingene er i</param>
        /// <param name="username">med dette finder man den bestemte kunde i listen(databasen)</param>
        /// <param name="kontinummer">med denne finder man den rigtige konti, for at slette den fra listen af konti for kunden</param>
        public void DeleteKonti(List<Customer> customers, string username, int kontinummer)
        {
            foreach (Customer customer in customers)
            {
                if (customer.UserName == username)
                {
                    foreach (Account account in customer.Accounts)
                    {
                        if (account.KontiNummer == kontinummer)
                        {
                            customer.Accounts.Remove(account);
                        }
                    }
                }
            }
            WorkComplete();
        }
        /// <summary>
        /// sletter kunden fra listen/databasen med kunder
        /// </summary>
        /// <param name="customers">hele listen af kunder, som kan ses som en database, med alle relevatnte informationer</param>
        /// <param name="bruger">bruges til at finde den rigtige kunde på listen</param>
        public void DeleteKonto(List<Customer> customers, string bruger)
        {
            foreach (Customer customer in customers)
            {
                if (customer.UserName == bruger)
                {
                    customers.Remove(customer);
                }
            }
            WorkComplete();
        }
        /// <summary>
        /// man tilføjer en ny kunde til vores liste, hvor at man kun skal have listen, som man tilføjer ting til
        /// </summary>
        /// <param name="customers">hele listen af kunder, som kan ses som en database, med alle relevatnte informationer</param>
        public void RegisterKunde(List<Customer> customers)
        {
            int userID;
            string brugernavn;
            string email;
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
            Console.Write("kundes nye id: ");
            userID = Convert.ToInt32(Console.ReadLine());
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
            Console.Write("kundens email: ");
            email = Console.ReadLine();
            Console.WriteLine();
            List<Account> accounts = new List<Account>();
            Account account = new Account();
            accounts.Add(account);
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
            Adresse adresse;
            Console.WriteLine();
            Console.Write("er der et etagenummer ved adressen: Y/N ");
            string yesOrNo = Console.ReadLine();
            if (yesOrNo.Contains("Y"))
            {
                Console.WriteLine();
                Console.Write(" 0 er lig med stuen, 1 er første sal ... \r\nhvad etage bor kunden på: ");
                int etageNummer = Convert.ToInt32(Console.ReadLine());

                adresse =new Adresse(streetName, byNavn, zipCode, husNummer, etageNummer);
               
            }
            else
            {
                adresse = new Adresse(streetName, byNavn, zipCode, husNummer);
            }
            customers.Add(new Customer(forNavn, brugernavn, efterNavn, password, adresse, accounts, cprNummer,userID,email));
            WorkComplete();
        end:
            Console.WriteLine("brugernavn eksistere allerede");
        }
        /// <summary>
        /// bruges til at lave sætte en ny konti op for kunden, og hvad for en type kontien er,
        /// samt hvad for et beløb der er skal sættes ind, til den nye konti
        /// </summary>
        /// <param name="customers">hele listen af kunder, som kan ses som en database, med alle relevatnte informationer</param>
        public void RegisterNyKonti(List<Customer> customers)
        {
            Console.WriteLine("hvilken kunde skal have en ny konti tilføjet: ");
            string kunde = Console.ReadLine();
            Console.WriteLine();
            Account account = new Account();
            foreach (Customer customer in customers)
            {
                if (customer.UserName == kunde)
                {
                    Console.Write("nye saldo på den nye konti:(brug . i stedet for ,) ");
                    double saldo = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine();
                    Console.Write("nye kontinummer: ");
                    int nyKontiNummer = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    AccountType type;
                    Console.Write("hvad er konti: (indlån/udlån) ");
                    string typen = Console.ReadLine();
                    if (typen == "indlån")
                    {
                        type = AccountType.Indlån;
                    }
                    else
                    {
                        type = AccountType.Udlån;
                    }
                    account.AccountType = type;
                    account.KontiNummer = nyKontiNummer;
                    account.Saldo = saldo;
                    customer.Accounts.Add(account);
                }
            }
            WorkComplete();
        }
        /// <summary>
        /// checker alle kunders indlån og udlåns saldo, og giver et resultat for begge kontityper
        /// og giver banken et resultat der er hvad banken holder for kunderne, og hvad kunderne skylder dem
        /// </summary>
        /// <param name="customers">hele listen af kunder, som kan ses som en database, med alle relevatnte informationer</param>
        public void CheckSamledeKapital(List<Customer> customers)
        {
            double totalIndLånSaldo = 0;
            double totalUdlånSaldo = 0;
            foreach (Customer customer in customers)
            {
                    foreach (Account account in customer.Accounts)
                    {
                        if (account.AccountType == AccountType.Indlån)
                        {
                            totalIndLånSaldo += account.Saldo;
                        }
                        else if (account.AccountType == AccountType.Udlån)
                        {
                            totalUdlånSaldo += account.Saldo;
                        }
                    }
                
            }
            Console.WriteLine("den totale indlåns saldo for banken er er: " + totalIndLånSaldo + " kr.\r\n" +
                "og den totale udlåns saldo for banken er: " + totalUdlånSaldo + " kr.");
        }
        /// <summary>
        /// sætter en bestemt mængde penge ind i den udvalgte kundes bestemte konti
        /// </summary>
        /// <param name="customers">hele listen af kunder, som kan ses som en database, med alle relevatnte informationer</param>
        /// <param name="bruger">den bruger som skal have penge sat på en af kontierne der er på kunden</param>
        /// <param name="kontiNummer">kontiens nummer til at finde den rigtige hvor pengene skal ind</param>
        /// <param name="money">en double værdi med mængden af penge der bliver sat ind</param>
        public void InsertMoney(List<Customer> customers, string bruger,int kontiNummer ,double money)
        {
            foreach (Customer customer in customers)
            {
                if (customer.UserName == bruger)
                {
                    foreach (Account account in customer.Accounts)
                    {
                        if (account.KontiNummer == kontiNummer)
                        {
                            account.Saldo += money;
                        }
                    }
                }
            }
            WorkComplete();
        }
        /// <summary>
        /// viser den bestemte kundes kontier og hvad det er for en konti(indlån/udlån) og hvor mange penge der er på den givne konti
        /// </summary>
        /// <param name="customers">hele listen af kunder, som kan ses som en database, med alle relevatnte informationer</param>
        /// <param name="bruger">hvilken kunde man skal have et overblik over</param>
        public void ShowKundeKonti(List<Customer> customers,string bruger)
        {
            foreach (Customer customer in customers)
            {
                if (customer.UserName == bruger)
                {
                    Console.WriteLine(bruger + " har disse konti");
                    Console.ReadLine();
                    foreach (Account account in customer.Accounts)
                    {
                        Console.WriteLine("kontinummer: " + account.KontiNummer);
                        if (account.AccountType == AccountType.Indlån)
                        {
                            Console.WriteLine("konti typen er: indlån");
                        }
                        else
                        {
                            Console.WriteLine("konti typen er: udlån");
                        }
                        Console.ReadLine();
                        Console.WriteLine("på konti er der: " + account.Saldo);
                        Console.ReadLine();
                    }
                }
            }
        }
        /// <summary>
        /// bruges til at kalde på Verify login på User.cs hvor vi sender til den listen over hvem der har adgang til systemet
        /// og hvad brugerid og password er for den prøvende login attempt
        /// </summary>
        /// <param name="administrations"> en liste over administrators der kan tilgå vores forskellige metoder</param>
        /// <param name="brugerid">bruges til at finde den givne administrator som vil tilgå systemet</param>
        /// <param name="paswd">administratorens adgangskode/password</param>
        /// <returns></returns>
        public bool Login(List<Administration> administrations,int brugerid, string paswd)
        {
            if (VerifyLogin(brugerid,paswd,administrations)== true)
            {
                Console.WriteLine("du er nu logget ind");
                Console.ReadLine();
                return true;
            }
            else
            {
                Console.WriteLine("forkert password eller userID");
                Console.ReadLine();
                return false;
            }
            
        }
        /// <summary>
        /// metode til at sige at den kaldte metode man har brugt er færdig med at køre
        /// </summary>
        public void WorkComplete()
        {
            Console.WriteLine("opgaven er færdig nu");
            Console.ReadLine();
        }
        /// <summary>
        /// bruges til at opdatere kunden, hvis der er sket ændringer i kundes hverdag, som man er blevet gift
        /// flyttet, skal have nyt password, har skiftet email og lign.
        /// </summary>
        /// <param name="customers">hele listen af kunder, som kan ses som en database, med alle relevatnte informationer</param>
        /// <param name="bruger">som skal have ændringerne lavet</param>
        public void UpdateKunde(List<Customer> customers, string bruger)
        {
            foreach (Customer customer in customers)
            {
                if (customer.UserName == bruger)
                {
                    Console.WriteLine("hvad skal ændres på bruger. \r\n" +
                        "du kan vælge imellem: \r\n" +
                        "1: password \r\n2: Email \r\n3: efternavn \r\n4: username" +
                        "\r\n5: adressen");
                    int svar = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    switch (svar)
                    {
                        case 1:
                            Console.Write("nye password er: ");
                            string nypasswd = Console.ReadLine();
                            customer.Password = nypasswd;
                            break;
                        case 2:
                            Console.Write("nye Email er: ");
                            string nyEmail = Console.ReadLine();
                            customer.Email = nyEmail;
                            break;
                        case 3:
                            Console.Write("nye efternavn er: ");
                            string nyEfterNavn = Console.ReadLine();
                            customer.EfterNavn = nyEfterNavn;
                            break;
                        case 4:
                            Console.Write("nye username er:");
                            string nyUserName = Console.ReadLine();
                            customer.UserName = nyUserName;
                            break;
                        case 5:
                            Adresse adresse;
                            Console.Write("nye gadenavn er: ");
                            string nyGadeNavn = Console.ReadLine();
                            Console.WriteLine();
                            Console.Write("den nye by: ");
                            string nyByNavn = Console.ReadLine();
                            Console.WriteLine();
                            Console.Write("byens zip code: ");
                            int nyByZip = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();
                            Console.Write("nye husnummer er: ");
                            int nyHusNummer = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();
                            Console.Write("er der et etagenummer ved adressen: Y/N ");
                            string yesOrNo = Console.ReadLine();
                            if (yesOrNo.Contains("Y"))
                            {
                                Console.WriteLine();
                                Console.Write(" 0 er lig med stuen, 1 er første sal ... \r\nhvad etage bor kunden på: ");
                                int etageNummer = Convert.ToInt32(Console.ReadLine());

                                adresse = new Adresse(nyGadeNavn, nyByNavn, nyByZip, nyHusNummer, etageNummer);

                            }
                            else
                            {
                                adresse = new Adresse(nyGadeNavn, nyByNavn, nyByZip, nyHusNummer );
                            }
                            customer.Adresse = adresse;
                            break;
                        default:
                            Console.WriteLine("det valgte nummer er ikke på listen");
                            Console.ReadLine();
                            break;
                    }
                }
            }
        }
    }
}
