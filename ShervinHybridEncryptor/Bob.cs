using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ShervinHybridEncryptor
{
    internal class Bob : IDisposable
    {
        public byte[] key;
        private RSACryptoServiceProvider rsaKey = new RSACryptoServiceProvider();
        private string MessageBox { get; set; }
        public Bob()
        {
            key = rsaKey.ExportCspBlob(false);
        }
        public void Receive(byte[] iv, byte[] encryptedSessionKey, byte[] encryptedMessage)
        {
            using (Aes aes = new AesCryptoServiceProvider())
            {
                aes.IV = iv;

                // Decrypt the session key
                var keyDeformatter = new RSAPKCS1KeyExchangeDeformatter(rsaKey);
                aes.Key = keyDeformatter.DecryptKeyExchange(encryptedSessionKey);

                // Decrypt the message
                using (var plaintext = new MemoryStream())
                {
                    using (var cs = new CryptoStream(plaintext, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(encryptedMessage, 0, encryptedMessage.Length);
                        cs.Close();

                        MessageBox = Encoding.UTF8.GetString(plaintext.ToArray());
                        Debug.WriteLine("Message recieved!: " + MessageBox);
                    }
                }
            }
        }

        public void Dispose()
        {
            rsaKey.Dispose();
        }
    }
}
