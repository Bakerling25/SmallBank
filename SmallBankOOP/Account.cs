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
        public AccountType AccountType { get { return accountType; } }
    }
}
