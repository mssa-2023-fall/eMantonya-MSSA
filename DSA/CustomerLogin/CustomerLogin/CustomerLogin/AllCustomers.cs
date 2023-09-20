using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CustomerLogin
{
    public class AllCustomers
    {
        public Dictionary<string, Customer> allCustomers = new Dictionary<string, Customer>();

        public bool CreateAccount(string eMail, string name, string pass)
        {
            if (allCustomers.ContainsKey(eMail)) //account already exists with that e-mail - return false
            {
                return false;
            }
            else
            {
                allCustomers.Add(eMail, new Customer(eMail, name, pass));
                return true;
            }
        }

        public bool Login(string email, string pass)
        {
            if (!allCustomers.ContainsKey(email))
            {
                return false;
            }
            if (Hasher.VerifyPassword(pass, allCustomers[email]._passwordHash, allCustomers[email].salt))
            {
                return true;
            }
            return false;
        }
    }
}
