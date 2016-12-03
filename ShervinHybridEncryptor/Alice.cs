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

                    ShervinAESUtility.Send(rsaKey, inputText, out iv, out encryptedSessionKey, out encryptedMessage);
                    bob.Receive(iv, encryptedSessionKey, encryptedMessage);
                }
            }
        }
    }
}
