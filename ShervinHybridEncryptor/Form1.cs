using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace ShervinHybridEncryptor
{
    public partial class ShervinDesEncryptorForm : Form
    {
        public ShervinDesEncryptorForm()
        {
            InitializeComponent();
        }

        #region Validation
        private void InputText_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(InputText, string.IsNullOrWhiteSpace(InputText.Text) ? "Input Text is empty." : "");
        }

        private void SecretKey_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SecretKey.Text))
            {
                errorProvider1.SetError(SecretKey, "You must enter a secret key");
            }
            else if (SecretKey.Text.Length != 8)
            {
                MessageBox.Show("Error: They key has to be exactly 8 characters");
                errorProvider1.SetError(SecretKey, "");
            }
            else
            {
                errorProvider1.SetError(SecretKey, "");
            }
        }

        private bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(InputText.Text) ||
                string.IsNullOrWhiteSpace(SecretKey.Text) ||
                SecretKey.Text.Length != 8)
            {
                return false;
            }
            return true;
        }

        #endregion

        #region Control Events
        private void DecryptRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ExecuteButton.Text = DecryptRadioButton.Checked ? "Decrypt!" : "Encrypt!";
            OutputText.Clear();
            CopyOutputText.Enabled = false;
            OpenOutputNotepad.Enabled = false;
        }

        private void ImportInputText_Click(object sender, EventArgs e)
        {
            InputText.Text = ImportTextfile();
            errorProvider1.SetError(InputText, "");
        }

        private void ImportSecretKey_Click(object sender, EventArgs e)
        {
            SecretKey.Clear();
            SecretKey.Text = ImportTextfile();
            errorProvider1.SetError(SecretKey, "");
        }

        private void ClearInputText_Click(object sender, EventArgs e)
        {
            InputText.Clear();
        }

        private void InputText_TextChanged(object sender, EventArgs e)
        {
            OpenOutputNotepad.Enabled = false;
            CopyOutputText.Enabled = false;
            OutputText.Clear();
        }

        private void OpenOutputNotepad_Click(object sender, EventArgs e)
        {
            var currentDir = Directory.GetCurrentDirectory();
            var fileName = "Output_" + DateTime.Now.ToString("MMddYYYYhhmmss.txt");
            var fullPath = currentDir + @"\" + fileName;
            File.WriteAllText(fullPath, OutputText.Text);
            Process.Start(fullPath);
        }

        private void RandomizeSecretKey_Click(object sender, EventArgs e)
        {
            SecretKey.Text = ShervinEncryptor.GenerateRandomKey();
        }

        private void CopyOutputText_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(OutputText.Text);
        }

        private void EncryptionModeDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            OutputText.Clear();
            OpenOutputNotepad.Enabled = false;
            CopyOutputText.Enabled = false;
        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                Debug.WriteLine("Executing now...");

                var args = new List<object>
                {
                    OperationCode,
                    InputText.Text,
                    SecretKey.Text,
                    SelectedMode
                };

                backgroundWorker1.RunWorkerAsync(args);
            }
            else
            {
                MessageBox.Show("Invalid input. Make sure your input is correct.");
            }
        }
        #endregion

        #region Private Methods
        private CipherMode SelectedMode
        {
            get
            {
                if (EncryptionModeDropdown.SelectedIndex == 0)
                {
                    return CipherMode.ECB;
                }
                else if (EncryptionModeDropdown.SelectedIndex == 1)
                {
                    return CipherMode.CBC;
                }
                throw new Exception("Invalid Mode");
            }
        }

        private int OperationCode
        {
            get
            {
                if (EncryptRadioButton.Checked)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
        }

        private string ImportTextfile()
        {
            var result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result != DialogResult.OK) return string.Empty;
            var file = openFileDialog1.FileName;
            try
            {
                var text = File.ReadAllText(file);
                var size = text.Length;

                if (size == 0) 
                    throw new IOException();

                return text;
            }
            catch (IOException)
            {
                MessageBox.Show("Invalid file. Make sure to select a valid text file.");
                return string.Empty;
            }
        }
        #endregion

        #region MultiThreading

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var genericlist = e.Argument as List<object>;
            if (genericlist == null) throw new Exception("Fatal Error: Bad threading");
            var operationCode = (int)genericlist[0];
            var inputText = genericlist[1].ToString();
            var key = genericlist[2].ToString();
            var mode = (CipherMode)genericlist[3];

            Debug.WriteLine("Operation Code: " + operationCode);
            Debug.WriteLine("inputText:" + inputText);
            Debug.WriteLine("Secret Key:" + key);

            e.Result = operationCode == 1
                ? ShervinEncryptor.Encrypt(inputText, key, mode)
                : ShervinEncryptor.Decrypt(inputText, key, mode);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Debug.WriteLine("Process completed");

            if (e.Error == null)
            {
                var result = e.Result.ToString();
                Debug.WriteLine("Result: " + result);


                OutputText.Clear();
                OutputText.Text = result;

                CopyOutputText.Enabled = true;
                OpenOutputNotepad.Enabled = true;
            }
            else
            {
                string message = @"Invalid data to decrypt. 
                Please make sure you are decrypting ciphertext that was decrypted using your chosen secret key and encryption mode.";
                MessageBox.Show(message);
            }
        }
        #endregion
    }
}
