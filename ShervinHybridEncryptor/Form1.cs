﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace ShervinHybridEncryptor
{
    public partial class ShervinHybridEncryptorForm : Form
    {
        private Logger Logger { get; set; }
        public ShervinHybridEncryptorForm()
        {
            InitializeComponent();

            Logger = new Logger(backgroundWorker1);
        }

        #region Validation

        private void InputText_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(InputText, string.IsNullOrWhiteSpace(InputText.Text) ? "Input Text is empty." : "");
        }

        #endregion

        #region Control Events

        private void ImportInputText_Click(object sender, EventArgs e)
        {
            InputText.Text = ImportTextfile();
            errorProvider1.SetError(InputText, "");
        }

        private void ClearInputText_Click(object sender, EventArgs e)
        {
            InputText.Clear();
            OutputText.Clear();
        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                Debug.WriteLine("Executing now...");

                var args = new List<object>
                {
                    InputText.Text
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
        private bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(InputText.Text);
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
            var inputText = genericlist[0].ToString();

            Logger.FirstLog = DateTime.Now;
            Logger.Log(string.Format("Alice's message: \"{0}\"", inputText));

            Alice.SendSecretMessage(inputText);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            OutputText.AppendLine(e.UserState.ToString());
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Debug.WriteLine("Process completed");

        }

        #endregion
    }
}

public static class WinFormsExtensions
{
    public static void AppendLine(this TextBox source, string value)
    {
        if (source.Text.Length == 0)
            source.Text = value;
        else
            source.AppendText("\r\n" + value);
    }
}