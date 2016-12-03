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
        public static void PrepareSend(RSA key, string secretMessage, out byte[] iv, out byte[] encryptedSessionKey, out byte[] encryptedMessage)
        {
            Logger.Log("Preparing the secret message to send...");
            Logger.Log("RSA key Exchange Algorithm: " + key.KeyExchangeAlgorithm);
            Logger.Log("RSA key Size: " + key.KeySize);
            using (Aes aes = new AesCryptoServiceProvider())
            {
                iv = aes.IV;
                Logger.Log("AES IV: " + Encoding.Default.GetString(iv));
                // Encrypt the session key
                var keyFormatter = new RSAPKCS1KeyExchangeFormatter(key);
                encryptedSessionKey = keyFormatter.CreateKeyExchange(aes.Key, typeof(Aes));
                Logger.Log("Session Key: " + Encoding.Default.GetString(encryptedSessionKey));
                // Encrypt the message
                using (var ciphertext = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ciphertext, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        var plaintextMessage = Encoding.UTF8.GetBytes(secretMessage);
                        cs.Write(plaintextMessage, 0, plaintextMessage.Length);
                        cs.Close();

                        encryptedMessage = ciphertext.ToArray();
                        Logger.Log("Encrypted Message: \"" + Encoding.Default.GetString(encryptedMessage) + "\"");
                    }
                }
            }
        }
    }
}
