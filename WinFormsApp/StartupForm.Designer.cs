namespace WinFormsApp
{
    partial class StartupForm
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
            cmbTournament = new ComboBox();
            cmbLanguage = new ComboBox();
            btnConfirm = new Button();
            SuspendLayout();
            // 
            // cmbTournament
            // 
            cmbTournament.FormattingEnabled = true;
            cmbTournament.Location = new Point(82, 155);
            cmbTournament.Name = "cmbTournament";
            cmbTournament.Size = new Size(151, 28);
            cmbTournament.TabIndex = 0;
            // 
            // cmbLanguage
            // 
            cmbLanguage.FormattingEnabled = true;
            cmbLanguage.Location = new Point(472, 155);
            cmbLanguage.Name = "cmbLanguage";
            cmbLanguage.Size = new Size(151, 28);
            cmbLanguage.TabIndex = 1;
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(307, 335);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(94, 29);
            btnConfirm.TabIndex = 2;
            btnConfirm.Text = "button1";
            btnConfirm.UseVisualStyleBackColor = true;
            // 
            // StartupForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnConfirm);
            Controls.Add(cmbLanguage);
            Controls.Add(cmbTournament);
            Name = "StartupForm";
            Text = "StartupForm";
            Load += StartupForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cmbTournament;
        private ComboBox cmbLanguage;
        private Button btnConfirm;
    }
}