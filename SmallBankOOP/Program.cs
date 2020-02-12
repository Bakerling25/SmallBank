using System;
using static System.Console;
using System.Collections.Generic;

namespace SmallBankOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>();
            List<Account> clausAcc = new List<Account>();
            List<Administration> administrations = new List<Administration>();
            administrations.Add(new Administration() { UserID = 15, AdminNavn = "ClausAdmin", Password = "AdminRule14", Email = "admin@admin.dk" });
            clausAcc.Add(new Account() { KontiNummer = 1, AccountType = AccountType.Indlån, Saldo = 1000 });
            clausAcc.Add(new Account() { KontiNummer = 2, AccountType = AccountType.Udlån, Saldo = 200 });
            List<Account> thomasAcc = new List<Account>();
            thomasAcc.Add(new Account() { KontiNummer = 1, AccountType = AccountType.Indlån, Saldo = 2000.50 });
            thomasAcc.Add(new Account() { KontiNummer = 2, AccountType = AccountType.Udlån, Saldo = 1000.75 });
            customers.Add(new Customer("Claus","Clausdimon" ,"Dimon", "password123", new Adresse("Grønløkkevej", "Odense C", 5000, 38, 1), clausAcc, "250393-####", 1, "email@email.com"));
            customers.Add(new Customer("Thomas", "Bakerling", "Salling", "Thomas321", new Adresse("Lille Grønskær", "Odense C", 5000, 15, 10), thomasAcc, "121280-####", 2, "email.T@email.com"));
            Administration administration = new Administration();
            bool workNotDone = true;
            int userNum;
            WriteLine("Velkommen til banken ");
            WriteLine("1. Login\n" + "2. Luk programet");
            userNum = int.Parse(ReadLine());
            switch (userNum)
            {
                case 1:
                    Write("dit brugerid: ");
                    int brugerID = Convert.ToInt32(ReadLine());
                    WriteLine();
                    Write("dit password: ");
                    string paswd = ReadLine();
                    if (administration.Login(administrations, brugerID, paswd) == true)
                    {
                        WriteLine("Velkommen administrator");
                        ReadLine();
                        while (workNotDone == true)
                        {
                            WriteLine("du kan nu vælge hvad du skal gøre: ");
                            WriteLine("1: slette konti hos bruger \r\n2: slette kunde konto\r\n" +
                                "3: register ny kunde \r\n4: register kundes nye konti" +
                                "\r\n5: checke samlede kapital \r\n6: sætte penge ind på kundes konti" +
                                "\r\n7: se alle kundes kontier\r\n8: updatere kundens data");
                            int valg = Convert.ToInt32(ReadLine());
                            string brugerNavn;
                            int kontiNumb;
                            switch (valg)
                            {
                                case 1:
                                    Write("brugernavn for kunden der skal fjernes en konti fra: ");
                                    brugerNavn = ReadLine();
                                    Write("kontinummer for den konti der skal fjernes: ");
                                    kontiNumb = Convert.ToInt32(ReadLine());
                                    administration.DeleteKonti(customers, brugerNavn, kontiNumb);
                                    break;
                                case 2:
                                    Write("brugernavn for kunden der skal fjernes fra systemet: ");
                                    brugerNavn = ReadLine();
                                    administration.DeleteKonto(customers, brugerNavn);
                                    break;
                                case 3:
                                    administration.RegisterKunde(customers);
                                    break;
                                case 4:
                                    administration.RegisterNyKonti(customers);
                                    break;
                                case 5:
                                    administration.CheckSamledeKapital(customers);
                                    break;
                                case 6:
                                    Write("Brugernavn på kunden, der skal have insat penge: ");
                                    brugerNavn = ReadLine();
                                    Write("hvilken konti skal have pengene sat ind: ");
                                    kontiNumb = Convert.ToInt32(ReadLine());
                                    Write("beløb der skal sættes ind: ");
                                    double penge = Convert.ToDouble(ReadLine());
                                    administration.InsertMoney(customers, brugerNavn, kontiNumb, penge);
                                    break;
                                case 7:
                                    Write("kundens brugernavn, til et overblik over konti: ");
                                    brugerNavn = ReadLine();
                                    administration.ShowKundeKonti(customers, brugerNavn);
                                    break;
                                case 8:
                                    Write("brugernavn på kunden, der skal have sine data opdateret: ");
                                    brugerNavn = ReadLine();
                                    administration.UpdateKunde(customers, brugerNavn);
                                    break;
                                default:
                                    WriteLine("det valgte nummer er ikke på listen");
                                    ReadLine();
                                    break;
                            }
                            WriteLine("er du færdig med dine opgaver? ");
                            string svar = ReadLine();
                            if (svar == "ja" || svar == "Ja" || svar == "yes" || svar == "Yes")
                            {
                                workNotDone = false;
                            }
                        }
                    }
                    break;
                case 2:
                    WriteLine("tak for brugen af vores software");
                    ReadLine();
                    break;
                default:
                    Console.WriteLine("det valgte nummer er ikke på listen\r\nmen tak for din tid, hav en god dag");
                    Console.ReadLine();
                    break;
            }
            ReadLine();

        }
    }
}
