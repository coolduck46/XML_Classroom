using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        public XElement ToXML()
        {
            XElement userElement = new XElement("Username");
            userElement.Value = username;
            XElement passElement = new XElement("Password");
            passElement.Value = password;
            XElement accountElement = new XElement("Account", userElement, passElement);
            return accountElement;
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

