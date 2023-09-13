using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CustomerLogin
{
    public class Hasher
    {
        const int keySize = 64;
        const int iterations = 350000;
        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;
        public byte[] ComputeHash(string input, byte[] salt)
        {

            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(input),
                salt,
                iterations,
                hashAlgorithm,
                keySize);

            return hash;
        }
       

        public bool VerifyPassword(string clearPassword, byte[] passwordHash, byte[] salt)
        {

            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(clearPassword, salt, iterations, hashAlgorithm, keySize);

            return CryptographicOperations.FixedTimeEquals(hashToCompare, passwordHash);
        }
    }
}
