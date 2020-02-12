using System;
using System.Collections.Generic;
using System.Text;

namespace SmallBankOOP
{
    class Account
    {
        private double saldo;
        private int kontiNummer;
        private AccountType accountType;

        public double Saldo
        {
            get { return saldo; }
            set { saldo = value; }
        }
        public int KontiNummer
        {
            get { return kontiNummer; }
            set { kontiNummer = value; }
        }
        public AccountType AccountType
        {
            get { return accountType; }
            set { accountType = value; }
        }
        /// <summary>
        /// bruges til at se saldoen for den bestemte konti
        /// </summary>
        public void ShowSaldo()
        {
            Console.WriteLine("konti nr.: " + KontiNummer);
            Console.WriteLine("er typen: " + AccountType);
            Console.WriteLine("og har en saldo af: " + Saldo);
            Console.ReadLine();

        }
    }
}
