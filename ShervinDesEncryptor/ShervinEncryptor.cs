using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ShervinDesEncryptor
{
    public class ShervinEncryptor
    {
        public static string Encrypt(string inputText, string key)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            des.Mode = CipherMode.ECB;
            des.Padding = PaddingMode.PKCS7;
            des.Key = Encoding.ASCII.GetBytes(key);

            using (MemoryStream stream = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(stream, des.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    byte[] data = Encoding.Default.GetBytes(inputText);
                    cs.Write(data, 0, data.Length);
                    cs.FlushFinalBlock();
                    return Convert.ToBase64String(stream.ToArray());
                }
            }
        }

        public static string Decrypt(string inputText, string key)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            des.Mode = CipherMode.ECB;
            des.Padding = PaddingMode.PKCS7;
            des.Key = Encoding.ASCII.GetBytes(key);

            using (MemoryStream stream = new MemoryStream(Convert.FromBase64String(inputText)))
            {
                using (CryptoStream cs = new CryptoStream(stream, des.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    using (StreamReader sr = new StreamReader(cs, Encoding.ASCII))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
        }

        public static string GenerateRandomKey()
        {
            Random random = new Random();
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 8)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
