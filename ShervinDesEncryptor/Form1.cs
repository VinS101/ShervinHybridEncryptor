using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShervinDesEncryptor
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
            if (string.IsNullOrWhiteSpace(InputText.Text))
            {
                errorProvider1.SetError(InputText, "Input Text is empty.");
            }
            else
            {
                errorProvider1.SetError(InputText, "");
            }
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
            if (DecryptRadioButton.Checked)
            {
                ExecuteButton.Text = "Decrypt!";
            }
            else
            {
                ExecuteButton.Text = "Encrypt!";
            }
            OutputText.Clear();
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
            string currentDir = Directory.GetCurrentDirectory();
            string fileName = "Output_" + DateTime.Now.ToString("MMddYYYYhhmmss.txt");
            string fullPath = currentDir + @"\" + fileName;
            System.IO.File.WriteAllText(fullPath, OutputText.Text);
            System.Diagnostics.Process.Start(fullPath);
        }

        private void RandomizeSecretKey_Click(object sender, EventArgs e)
        {
            SecretKey.Text = ShervinEncryptor.GenerateRandomKey();
        }

        private void CopyOutputText_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(OutputText.Text);
        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                Debug.WriteLine("Executing now...");

                List<object> args = new List<object>();
                args.Add(this.OperationCode);   // Encrypt or decrypt
                args.Add(this.InputText.Text);
                args.Add(this.SecretKey.Text);

                backgroundWorker1.RunWorkerAsync(args);
            }
            else
            {
                MessageBox.Show("Invalid input. Make sure your input is correct.");
            }
        }
        #endregion

        #region Private Methods
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
            int size = -1;
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    string text = File.ReadAllText(file);
                    size = text.Length;

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
            return string.Empty;
        }
        #endregion

        #region MultiThreading
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            List<object> genericlist = e.Argument as List<object>;
            int OperationCode = (int)genericlist[0];
            string inputText = genericlist[1].ToString();
            string key = genericlist[2].ToString();

            Debug.WriteLine("Operation Code: " + OperationCode);
            Debug.WriteLine("inputText:" + inputText);
            Debug.WriteLine("Secret Key:" + key);

       
            if (OperationCode == 1)
                e.Result = ShervinEncryptor.Encrypt(inputText, key);
            else
                e.Result = ShervinEncryptor.Decrypt(inputText, key);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Debug.WriteLine("Process completed");

            if (e.Error == null)
            {
                string result = e.Result.ToString();
                Debug.WriteLine("Result: " + result);


                OutputText.Clear();
                OutputText.Text = result;

                CopyOutputText.Enabled = true;
                OpenOutputNotepad.Enabled = true;
            }
            else
            {
                string message = "Invalid data to decrypt. Please make sure you are decrypting ciphertext that was decrypted using your secret key";
                MessageBox.Show(message);
            }
        }
        #endregion
    }
}
