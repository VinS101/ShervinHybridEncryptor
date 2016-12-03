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
            Logger.Log("Initializing Bob...");
            using (var bob = new Bob())
            {
                Logger.Log("Preparing RSA key for Alice...");
                using (var rsaKey = new RSACryptoServiceProvider())
                {
                    Logger.Log("Alice imports Bob's public key...");
                    rsaKey.ImportCspBlob(bob.key);

                    byte[] encryptedSessionKey;
                    byte[] encryptedMessage;
                    byte[] iv;

                    ShervinAESUtility.PrepareSend(rsaKey, inputText, out iv, out encryptedSessionKey, out encryptedMessage);

                    Logger.Log("Sending message to Bob...");
                    bob.Receive(iv, encryptedSessionKey, encryptedMessage);
                }
            }
        }
    }
}
