using System;
using System.Security.Cryptography;
using System.Text;

namespace GameFreelance.Web.Utils
{
    public static class PasswordUtils
    {
        public static Guid GetHashPassword(string password)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            
            MD5CryptoServiceProvider cryptoServiceProvider = new MD5CryptoServiceProvider();

            byte[] bytesHash = cryptoServiceProvider.ComputeHash(bytes);

            string hash = string.Empty;

            foreach (byte b in bytesHash)
            {
                hash += $"{b:x2}";
            }

            return new Guid(hash);
        }
    }
}