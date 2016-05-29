using System;
using System.Security.Cryptography;
using System.Text;

namespace LufkinLib
{
    class Encrypt
    {
        private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();

        private static String byteArrayToHexString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
            {
                hex.AppendFormat("{0:x2}", b);
            }

            return hex.ToString();
        }

        public static String createSalt()
        {
            byte[] buff = new byte[32];
            rngCsp.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }

        public static String generateSHA256Hash(String input, String salt)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input + salt);

            SHA256Managed hashString = new SHA256Managed();

            byte[] hash = hashString.ComputeHash(bytes);

            return byteArrayToHexString(hash);
        }
    }
}