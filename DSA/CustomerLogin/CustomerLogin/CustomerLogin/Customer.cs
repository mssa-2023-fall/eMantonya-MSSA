using System.Security.Cryptography;
using System.Text;

namespace CustomerLogin
{
    public class Customer
    {
        private string _eMail;
        private string _name;
        //private string _password;
        public byte[] salt;
        public byte[] _passwordHash;

        //Constructor
        public Customer(string eMail, string name, string password)
        {
            salt = RandomNumberGenerator.GetBytes(64);
            _eMail = eMail;
            _name = name;
            //_password = password;
            _passwordHash = Hasher.ComputeHash(password, salt);
        }

    }
}
