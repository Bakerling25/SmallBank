﻿using System;
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

        public bool VerifyLogin(int id, string passwd,List<User> bruger)
        {
            foreach (User item in bruger)
            {
                if (item.userID == id && item.password == passwd)
                {
                    item.loginStatus = true;
                    return true;
                }
            }
            return false;
        }
        
    }
}
