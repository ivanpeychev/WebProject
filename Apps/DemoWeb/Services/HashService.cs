using System;
using System.Security.Cryptography;
using System.Text;

namespace DemoWeb.Services
{
    public class HashService : IHashService
    {
        public string Hash(string stringToHash)
        {
            // SHA256 is disposable by inheritance.  
            using (var sha256 = SHA256.Create())
            {
                stringToHash += "SaltingThePassword!@#$%";
                // Send a sample text to hash.  
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(stringToHash));
                // Get the hashed string.  
                var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();

                return hash;
            }
        }
    }
}
