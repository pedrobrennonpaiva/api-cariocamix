using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CariocaMix.Utils.Security
{
    public class HashPassword
    {
        public static string GetHash(string text)
        {
            // SHA512 is disposable by inheritance.  
            using var sha256 = SHA256.Create();

            // Send a sample text to hash.  
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));

            // Get the hashed string.  
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }

        public static string RandomString(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] uintBuffer = new byte[sizeof(uint)];

                while (length-- > 0)
                {
                    rng.GetBytes(uintBuffer);
                    uint num = BitConverter.ToUInt32(uintBuffer, 0);
                    res.Append(valid[(int)(num % (uint)valid.Length)]);
                }
            }

            return res.ToString();
        }
    }
}
