using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ShervinHybridEncryptor
{
    public class ShervinEncryptor
    {
        // IV is generated randomly on each encryption
        public static byte[] IV; 

        public static string Encrypt(string inputText, string key, CipherMode mode)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            des.Mode = mode;
            des.Key = Encoding.ASCII.GetBytes(key);
            IV = des.IV;
            using (MemoryStream stream = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(stream, des.CreateEncryptor(des.Key, des.IV), CryptoStreamMode.Write))
                {
                    byte[] data = Encoding.Default.GetBytes(inputText);
                    cs.Write(data, 0, data.Length);
                    cs.FlushFinalBlock();
                    return Convert.ToBase64String(stream.ToArray());
                }
            }
        }

        public static string Decrypt(string inputText, string key, CipherMode mode)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            des.Mode = mode;
            des.Key = Encoding.ASCII.GetBytes(key);

            using (MemoryStream stream = new MemoryStream(Convert.FromBase64String(inputText)))
            {
                using (CryptoStream cs = new CryptoStream(stream, des.CreateDecryptor(des.Key, IV), CryptoStreamMode.Read))
                {
                    using (StreamReader sr = new StreamReader(cs, Encoding.ASCII))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
        }
        
        /// <summary>
        /// Generate a random key of size 8 (64 bits)
        /// </summary>
        /// <returns></returns>
        public static string GenerateRandomKey()
        {
            Random random = new Random();
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 8)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
