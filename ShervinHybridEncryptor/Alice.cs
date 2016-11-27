using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ShervinHybridEncryptor
{
    internal static class Alice
    {
        public static void SendSecretMessage(string inputText)
        {
            using (var bob = new Bob())
            {
                using (var rsaKey = new RSACryptoServiceProvider())
                {
                    // Get Bob's public key
                    rsaKey.ImportCspBlob(bob.key);

                    byte[] encryptedSessionKey;
                    byte[] encryptedMessage;
                    byte[] iv;

                    Send(rsaKey, inputText, out iv, out encryptedSessionKey, out encryptedMessage);
                    bob.Receive(iv, encryptedSessionKey, encryptedMessage);
                }
            }
        }

        private static void Send(RSA key, string secretMessage, out byte[] iv, out byte[] encryptedSessionKey, out byte[] encryptedMessage)
        {
            using (Aes aes = new AesCryptoServiceProvider())
            {
                iv = aes.IV;

                // Encrypt the session key
                var keyFormatter = new RSAPKCS1KeyExchangeFormatter(key);
                encryptedSessionKey = keyFormatter.CreateKeyExchange(aes.Key, typeof(Aes));

                // Encrypt the message
                using (var ciphertext = new MemoryStream())
                using (var cs = new CryptoStream(ciphertext, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    byte[] plaintextMessage = Encoding.UTF8.GetBytes(secretMessage);
                    cs.Write(plaintextMessage, 0, plaintextMessage.Length);
                    cs.Close();

                    encryptedMessage = ciphertext.ToArray();
                }
            }
        }
    }
}
