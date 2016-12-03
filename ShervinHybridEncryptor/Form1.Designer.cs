namespace ShervinHybridEncryptor
{
    partial class ShervinHybridEncryptorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShervinHybridEncryptorForm));
            this.InputTextLabel = new System.Windows.Forms.Label();
            this.InputText = new System.Windows.Forms.TextBox();
            this.ImportInputText = new System.Windows.Forms.Button();
            this.OutputLabel = new System.Windows.Forms.Label();
            this.OutputText = new System.Windows.Forms.TextBox();
            this.ClearInputText = new System.Windows.Forms.Button();
            this.ExecuteButton = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // InputTextLabel
            // 
            this.InputTextLabel.AutoSize = true;
            this.InputTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputTextLabel.Location = new System.Drawing.Point(5, 54);
            this.InputTextLabel.Name = "InputTextLabel";
            this.InputTextLabel.Size = new System.Drawing.Size(138, 20);
            this.InputTextLabel.TabIndex = 0;
            this.InputTextLabel.Text = "Alice\'s Message";
            // 
            // InputText
            // 
            this.InputText.Location = new System.Drawing.Point(149, 39);
            this.InputText.Multiline = true;
            this.InputText.Name = "InputText";
            this.InputText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.InputText.Size = new System.Drawing.Size(422, 56);
            this.InputText.TabIndex = 3;
            this.InputText.Validating += new System.ComponentModel.CancelEventHandler(this.InputText_Validating);
            // 
            // ImportInputText
            // 
            this.ImportInputText.CausesValidation = false;
            this.ImportInputText.Location = new System.Drawing.Point(588, 43);
            this.ImportInputText.Name = "ImportInputText";
            this.ImportInputText.Size = new System.Drawing.Size(75, 23);
            this.ImportInputText.TabIndex = 7;
            this.ImportInputText.Text = "Import";
            this.ImportInputText.UseVisualStyleBackColor = true;
            this.ImportInputText.Click += new System.EventHandler(this.ImportInputText_Click);
            // 
            // OutputLabel
            // 
            this.OutputLabel.AutoSize = true;
            this.OutputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.OutputLabel.Location = new System.Drawing.Point(61, 159);
            this.OutputLabel.Name = "OutputLabel";
            this.OutputLabel.Size = new System.Drawing.Size(69, 20);
            this.OutputLabel.TabIndex = 9;
            this.OutputLabel.Text = "Output:";
            // 
            // OutputText
            // 
            this.OutputText.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.OutputText.CausesValidation = false;
            this.OutputText.Location = new System.Drawing.Point(149, 159);
            this.OutputText.Multiline = true;
            this.OutputText.Name = "OutputText";
            this.OutputText.ReadOnly = true;
            this.OutputText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.OutputText.Size = new System.Drawing.Size(528, 333);
            this.OutputText.TabIndex = 10;
            // 
            // ClearInputText
            // 
            this.ClearInputText.CausesValidation = false;
            this.ClearInputText.Location = new System.Drawing.Point(588, 72);
            this.ClearInputText.Name = "ClearInputText";
            this.ClearInputText.Size = new System.Drawing.Size(75, 23);
            this.ClearInputText.TabIndex = 12;
            this.ClearInputText.Text = "Clear";
            this.ClearInputText.UseVisualStyleBackColor = true;
            this.ClearInputText.Click += new System.EventHandler(this.ClearInputText_Click);
            // 
            // ExecuteButton
            // 
            this.ExecuteButton.Location = new System.Drawing.Point(149, 110);
            this.ExecuteButton.Name = "ExecuteButton";
            this.ExecuteButton.Size = new System.Drawing.Size(110, 31);
            this.ExecuteButton.TabIndex = 13;
            this.ExecuteButton.Text = "Send to Bob!";
            this.ExecuteButton.UseVisualStyleBackColor = true;
            this.ExecuteButton.Click += new System.EventHandler(this.ExecuteButton_Click);
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
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // ShervinHybridEncryptorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 510);
            this.Controls.Add(this.ExecuteButton);
            this.Controls.Add(this.ClearInputText);
            this.Controls.Add(this.OutputText);
            this.Controls.Add(this.OutputLabel);
            this.Controls.Add(this.ImportInputText);
            this.Controls.Add(this.InputText);
            this.Controls.Add(this.InputTextLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ShervinHybridEncryptorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shervin Hybrid Encryptor";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InputTextLabel;
        private System.Windows.Forms.TextBox InputText;
        private System.Windows.Forms.Button ImportInputText;
        private System.Windows.Forms.Label OutputLabel;
        private System.Windows.Forms.TextBox OutputText;
        private System.Windows.Forms.Button ClearInputText;
        private System.Windows.Forms.Button ExecuteButton;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

