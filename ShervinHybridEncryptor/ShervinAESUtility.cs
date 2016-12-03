using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ShervinHybridEncryptor
{
    internal class ShervinAESUtility
    {
        public static void Send(RSA key, string secretMessage, out byte[] iv, out byte[] encryptedSessionKey, out byte[] encryptedMessage)
        {
            using (Aes aes = new AesCryptoServiceProvider())
            {
                iv = aes.IV;

                // Encrypt the session key
                var keyFormatter = new RSAPKCS1KeyExchangeFormatter(key);
                encryptedSessionKey = keyFormatter.CreateKeyExchange(aes.Key, typeof(Aes));

                // Encrypt the message
                using (var ciphertext = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ciphertext, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        var plaintextMessage = Encoding.UTF8.GetBytes(secretMessage);
                        cs.Write(plaintextMessage, 0, plaintextMessage.Length);
                        cs.Close();

                        encryptedMessage = ciphertext.ToArray();
                    }
                }
            }
        }
    }
}
