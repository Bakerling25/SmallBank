using System;
using System.Collections.Generic;
using System.Text;

namespace SmallBankOOP
{
    abstract class User
    {
        private int userID;
        private string password;
        private bool loginStatus;
        private string email;
        private DateTime registerDate;

        public int UserID { get { return userID; } set { userID = value; } }
        public string Password { get { return password; } set { password = value; } }
        public string Email { get { return email; } set { email = value; } }
        public DateTime RegisterDate { get { return registerDate; } set { registerDate = value; } }
        /// <summary>
        /// bruges til at tjekke om brugeren eksitere og om koden er den rigtige for at tilgå systemet
        /// </summary>
        /// <param name="id">brugerid/adminid</param>
        /// <param name="passwd">koden som systemet tjekker om passer med id for brugeren</param>
        /// <param name="bruger">en liste over administratore der kan tilgå systemet</param>
        /// <returns></returns>
        public bool VerifyLogin(int id, string passwd,List<Administration> bruger)
        {
            foreach (Administration administration in bruger)
            {
                if (administration.userID == id && administration.password == passwd)
                {
                    administration.loginStatus = true;
                    return true;
                }
            }
            return false;
        }
        
    }
}
