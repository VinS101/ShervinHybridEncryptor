using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            else
            {
                errorProvider1.SetError(SecretKey, "");
            }
        }

        private bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(InputText.Text) ||
                string.IsNullOrWhiteSpace(SecretKey.Text))
            {
                return false;
            }
            return true;
        }

        #endregion

        private void ImportInputText_Click(object sender, EventArgs e)
        {
            InputText.Text = ImportTextfile();
            errorProvider1.SetError(InputText, "");
        }

        private void ClearInputText_Click(object sender, EventArgs e)
        {
            InputText.Clear();
        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                MessageBox.Show("Executing now...");
            }
            else
            {
                MessageBox.Show("Invalid input. Make sure all fields are populated");
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
    }
}
