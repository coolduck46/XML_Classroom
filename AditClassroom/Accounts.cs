using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AditClassroom
{
    class Accounts
    {

        public string username;
        public string password;

        public Accounts(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public bool CompareTo(string userusername, string userpassword)
        {
            if (username == userusername)
            {
                if (password == userpassword)
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }
            return false;
        }

    }


}

