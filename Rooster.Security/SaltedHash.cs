using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Rooster.Security
{
    public static class SaltedHash
    {
        public static byte[] GenerateSalt()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            int minSaltSize = 16;
            int maxSaltSize = 32;
            Random random = new Random();
            int saltSize = random.Next(minSaltSize, maxSaltSize);

            byte[] byteArray = new byte[saltSize];

            rng.GetBytes(byteArray);

            return byteArray;
        }

        public static byte[] GenerateSaltedHash(string passwordPlainText, byte[] saltBytes)
        {
            byte[] clearTextBytes = Encoding.UTF8.GetBytes(passwordPlainText);

            byte[] clearTextWithSaltBytes = new byte[clearTextBytes.Length + saltBytes.Length];

            for (int i = 0; i < clearTextBytes.Length; i++)
            {
                clearTextWithSaltBytes[i] = clearTextBytes[i];
            }

            for (int i = 0; i < saltBytes.Length; i++)
            {
                clearTextWithSaltBytes[clearTextBytes.Length + i] = saltBytes[i];
            }

            //Calculate the hash
            HashAlgorithm hash = new SHA256Managed();
            byte[] hashBytes = hash.ComputeHash(clearTextWithSaltBytes);

            return hashBytes;
        }

        public static bool IsPasswordValid(string passwordPlainText, byte[] savedSaltBytes, byte[] savedHashBytes)
        {
            byte[] array1 = GenerateSaltedHash(passwordPlainText, savedSaltBytes);
            byte[] array2 = savedHashBytes;

            if (array1.Length != array2.Length)
                return false;

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                    return false;
            }

            return true;
        }
    }
}
