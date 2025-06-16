namespace WinFormsApp
{
    partial class ExitConfirmationForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblMessage;
        private Button btnYes;
        private Button btnNo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblMessage = new Label();
            btnYes = new Button();
            btnNo = new Button();
            SuspendLayout();
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Location = new Point(45, 19);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(238, 20);
            lblMessage.TabIndex = 0;
            lblMessage.Text = "Are you sure that you want to exit?";
            // 
            // btnYes
            // 
            btnYes.Location = new Point(30, 60);
            btnYes.Name = "btnYes";
            btnYes.Size = new Size(75, 30);
            btnYes.TabIndex = 1;
            btnYes.Text = "Yes";
            btnYes.Click += btnYes_Click;
            // 
            // btnNo
            // 
            btnNo.Location = new Point(222, 60);
            btnNo.Name = "btnNo";
            btnNo.Size = new Size(75, 30);
            btnNo.TabIndex = 2;
            btnNo.Text = "No";
            btnNo.Click += btnNo_Click;
            // 
            // ExitConfirmationForm
            // 
            ClientSize = new Size(339, 110);
            Controls.Add(lblMessage);
            Controls.Add(btnYes);
            Controls.Add(btnNo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "ExitConfirmationForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Potvrda izlaza";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
