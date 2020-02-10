using System;
using static System.Console;
using System.Collections.Generic;

namespace SmallBankOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            int userNum;
            WriteLine("Velkommen til banken ");
            WriteLine("1. Login\n" + "2. Luk programet");
            userNum = int.Parse(ReadLine());
            switch (userNum)
            {
                case 1:
                    break;
                case 2:
                    break;
                default:
                    break;
            }
            ReadLine();

        }
    }
}
