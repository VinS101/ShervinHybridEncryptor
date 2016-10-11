namespace ShervinDesEncryptor
{
    partial class ShervinDesEncryptorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShervinDesEncryptorForm));
            this.InputTextLabel = new System.Windows.Forms.Label();
            this.SecretKeyLabel = new System.Windows.Forms.Label();
            this.OperationLabel = new System.Windows.Forms.Label();
            this.InputText = new System.Windows.Forms.TextBox();
            this.SecretKey = new System.Windows.Forms.TextBox();
            this.EncryptRadioButton = new System.Windows.Forms.RadioButton();
            this.DecryptRadioButton = new System.Windows.Forms.RadioButton();
            this.ImportInputText = new System.Windows.Forms.Button();
            this.ImportSecretKey = new System.Windows.Forms.Button();
            this.OutputLabel = new System.Windows.Forms.Label();
            this.OutputText = new System.Windows.Forms.TextBox();
            this.OpenOutputNotepad = new System.Windows.Forms.Button();
            this.ClearInputText = new System.Windows.Forms.Button();
            this.ExecuteButton = new System.Windows.Forms.Button();
            this.RandomizeSecretKey = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.CopyOutputText = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // InputTextLabel
            // 
            this.InputTextLabel.AutoSize = true;
            this.InputTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputTextLabel.Location = new System.Drawing.Point(14, 39);
            this.InputTextLabel.Name = "InputTextLabel";
            this.InputTextLabel.Size = new System.Drawing.Size(95, 20);
            this.InputTextLabel.TabIndex = 0;
            this.InputTextLabel.Text = "Input Text:";
            // 
            // SecretKeyLabel
            // 
            this.SecretKeyLabel.AutoSize = true;
            this.SecretKeyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.SecretKeyLabel.Location = new System.Drawing.Point(14, 125);
            this.SecretKeyLabel.Name = "SecretKeyLabel";
            this.SecretKeyLabel.Size = new System.Drawing.Size(101, 20);
            this.SecretKeyLabel.TabIndex = 1;
            this.SecretKeyLabel.Text = "Secret Key:";
            // 
            // OperationLabel
            // 
            this.OperationLabel.AutoSize = true;
            this.OperationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.OperationLabel.Location = new System.Drawing.Point(16, 180);
            this.OperationLabel.Name = "OperationLabel";
            this.OperationLabel.Size = new System.Drawing.Size(93, 20);
            this.OperationLabel.TabIndex = 2;
            this.OperationLabel.Text = "Operation:";
            // 
            // InputText
            // 
            this.InputText.Location = new System.Drawing.Point(149, 39);
            this.InputText.Multiline = true;
            this.InputText.Name = "InputText";
            this.InputText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.InputText.Size = new System.Drawing.Size(309, 56);
            this.InputText.TabIndex = 3;
            this.InputText.TextChanged += new System.EventHandler(this.InputText_TextChanged);
            this.InputText.Validating += new System.ComponentModel.CancelEventHandler(this.InputText_Validating);
            // 
            // SecretKey
            // 
            this.SecretKey.Location = new System.Drawing.Point(149, 125);
            this.SecretKey.Name = "SecretKey";
            this.SecretKey.Size = new System.Drawing.Size(309, 20);
            this.SecretKey.TabIndex = 4;
            this.SecretKey.Validating += new System.ComponentModel.CancelEventHandler(this.SecretKey_Validating);
            // 
            // EncryptRadioButton
            // 
            this.EncryptRadioButton.AutoSize = true;
            this.EncryptRadioButton.CausesValidation = false;
            this.EncryptRadioButton.Checked = true;
            this.EncryptRadioButton.Location = new System.Drawing.Point(149, 183);
            this.EncryptRadioButton.Name = "EncryptRadioButton";
            this.EncryptRadioButton.Size = new System.Drawing.Size(83, 17);
            this.EncryptRadioButton.TabIndex = 5;
            this.EncryptRadioButton.TabStop = true;
            this.EncryptRadioButton.Text = "DES Encypt";
            this.EncryptRadioButton.UseVisualStyleBackColor = true;
            // 
            // DecryptRadioButton
            // 
            this.DecryptRadioButton.AutoSize = true;
            this.DecryptRadioButton.CausesValidation = false;
            this.DecryptRadioButton.Location = new System.Drawing.Point(238, 183);
            this.DecryptRadioButton.Name = "DecryptRadioButton";
            this.DecryptRadioButton.Size = new System.Drawing.Size(87, 17);
            this.DecryptRadioButton.TabIndex = 6;
            this.DecryptRadioButton.Text = "DES Decrypt";
            this.DecryptRadioButton.UseVisualStyleBackColor = true;
            this.DecryptRadioButton.CheckedChanged += new System.EventHandler(this.DecryptRadioButton_CheckedChanged);
            // 
            // ImportInputText
            // 
            this.ImportInputText.CausesValidation = false;
            this.ImportInputText.Location = new System.Drawing.Point(464, 39);
            this.ImportInputText.Name = "ImportInputText";
            this.ImportInputText.Size = new System.Drawing.Size(75, 23);
            this.ImportInputText.TabIndex = 7;
            this.ImportInputText.Text = "Import";
            this.ImportInputText.UseVisualStyleBackColor = true;
            this.ImportInputText.Click += new System.EventHandler(this.ImportInputText_Click);
            // 
            // ImportSecretKey
            // 
            this.ImportSecretKey.CausesValidation = false;
            this.ImportSecretKey.Location = new System.Drawing.Point(464, 125);
            this.ImportSecretKey.Name = "ImportSecretKey";
            this.ImportSecretKey.Size = new System.Drawing.Size(55, 23);
            this.ImportSecretKey.TabIndex = 8;
            this.ImportSecretKey.Text = "Import";
            this.ImportSecretKey.UseVisualStyleBackColor = true;
            this.ImportSecretKey.Click += new System.EventHandler(this.ImportSecretKey_Click);
            // 
            // OutputLabel
            // 
            this.OutputLabel.AutoSize = true;
            this.OutputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.OutputLabel.Location = new System.Drawing.Point(40, 240);
            this.OutputLabel.Name = "OutputLabel";
            this.OutputLabel.Size = new System.Drawing.Size(69, 20);
            this.OutputLabel.TabIndex = 9;
            this.OutputLabel.Text = "Output:";
            // 
            // OutputText
            // 
            this.OutputText.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.OutputText.CausesValidation = false;
            this.OutputText.Location = new System.Drawing.Point(149, 228);
            this.OutputText.Multiline = true;
            this.OutputText.Name = "OutputText";
            this.OutputText.ReadOnly = true;
            this.OutputText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.OutputText.Size = new System.Drawing.Size(309, 54);
            this.OutputText.TabIndex = 10;
            // 
            // OpenOutputNotepad
            // 
            this.OpenOutputNotepad.CausesValidation = false;
            this.OpenOutputNotepad.Location = new System.Drawing.Point(464, 228);
            this.OpenOutputNotepad.Name = "OpenOutputNotepad";
            this.OpenOutputNotepad.Size = new System.Drawing.Size(75, 22);
            this.OpenOutputNotepad.TabIndex = 11;
            this.OpenOutputNotepad.Text = "Open Text";
            this.OpenOutputNotepad.UseVisualStyleBackColor = true;
            this.OpenOutputNotepad.Click += new System.EventHandler(this.OpenOutputNotepad_Click);
            // 
            // ClearInputText
            // 
            this.ClearInputText.CausesValidation = false;
            this.ClearInputText.Location = new System.Drawing.Point(464, 72);
            this.ClearInputText.Name = "ClearInputText";
            this.ClearInputText.Size = new System.Drawing.Size(75, 23);
            this.ClearInputText.TabIndex = 12;
            this.ClearInputText.Text = "Clear";
            this.ClearInputText.UseVisualStyleBackColor = true;
            this.ClearInputText.Click += new System.EventHandler(this.ClearInputText_Click);
            // 
            // ExecuteButton
            // 
            this.ExecuteButton.Location = new System.Drawing.Point(201, 305);
            this.ExecuteButton.Name = "ExecuteButton";
            this.ExecuteButton.Size = new System.Drawing.Size(186, 39);
            this.ExecuteButton.TabIndex = 13;
            this.ExecuteButton.Text = "Encrypt!";
            this.ExecuteButton.UseVisualStyleBackColor = true;
            this.ExecuteButton.Click += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // RandomizeSecretKey
            // 
            this.RandomizeSecretKey.CausesValidation = false;
            this.RandomizeSecretKey.Location = new System.Drawing.Point(523, 125);
            this.RandomizeSecretKey.Name = "RandomizeSecretKey";
            this.RandomizeSecretKey.Size = new System.Drawing.Size(55, 23);
            this.RandomizeSecretKey.TabIndex = 14;
            this.RandomizeSecretKey.Text = "Random";
            this.RandomizeSecretKey.UseVisualStyleBackColor = true;
            this.RandomizeSecretKey.Click += new System.EventHandler(this.RandomizeSecretKey_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // CopyOutputText
            // 
            this.CopyOutputText.CausesValidation = false;
            this.CopyOutputText.Location = new System.Drawing.Point(464, 256);
            this.CopyOutputText.Name = "CopyOutputText";
            this.CopyOutputText.Size = new System.Drawing.Size(75, 22);
            this.CopyOutputText.TabIndex = 15;
            this.CopyOutputText.Text = "Copy";
            this.CopyOutputText.UseVisualStyleBackColor = true;
            this.CopyOutputText.Click += new System.EventHandler(this.CopyOutputText_Click);
            // 
            // ShervinDesEncryptorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 356);
            this.Controls.Add(this.CopyOutputText);
            this.Controls.Add(this.RandomizeSecretKey);
            this.Controls.Add(this.ExecuteButton);
            this.Controls.Add(this.ClearInputText);
            this.Controls.Add(this.OpenOutputNotepad);
            this.Controls.Add(this.OutputText);
            this.Controls.Add(this.OutputLabel);
            this.Controls.Add(this.ImportSecretKey);
            this.Controls.Add(this.ImportInputText);
            this.Controls.Add(this.DecryptRadioButton);
            this.Controls.Add(this.EncryptRadioButton);
            this.Controls.Add(this.SecretKey);
            this.Controls.Add(this.InputText);
            this.Controls.Add(this.OperationLabel);
            this.Controls.Add(this.SecretKeyLabel);
            this.Controls.Add(this.InputTextLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ShervinDesEncryptorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shervin DES Encryptor";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InputTextLabel;
        private System.Windows.Forms.Label SecretKeyLabel;
        private System.Windows.Forms.Label OperationLabel;
        private System.Windows.Forms.TextBox InputText;
        private System.Windows.Forms.TextBox SecretKey;
        private System.Windows.Forms.RadioButton EncryptRadioButton;
        private System.Windows.Forms.RadioButton DecryptRadioButton;
        private System.Windows.Forms.Button ImportInputText;
        private System.Windows.Forms.Button ImportSecretKey;
        private System.Windows.Forms.Label OutputLabel;
        private System.Windows.Forms.TextBox OutputText;
        private System.Windows.Forms.Button OpenOutputNotepad;
        private System.Windows.Forms.Button ClearInputText;
        private System.Windows.Forms.Button ExecuteButton;
        private System.Windows.Forms.Button RandomizeSecretKey;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button CopyOutputText;
    }
}

