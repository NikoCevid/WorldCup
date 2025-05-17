using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp
{
    partial class PlayerControl
    {
        private PictureBox picPlayer;
        private PictureBox picStar;
        private Label lblName;
        private Label lblNumber;
        private Label lblPosition;
        private Label lblCaptain;
        private Label lblStatValue;

        private void InitializeComponent()
        {
            picPlayer = new PictureBox();
            picStar = new PictureBox();
            lblName = new Label();
            lblNumber = new Label();
            lblPosition = new Label();
            lblCaptain = new Label();
            lblStatValue = new Label();

            ((System.ComponentModel.ISupportInitialize)picPlayer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picStar).BeginInit();
            SuspendLayout();

            // 
            // picPlayer
            // 
            picPlayer.Location = new Point(5, 5);
            picPlayer.Name = "picPlayer";
            picPlayer.Size = new Size(50, 50);
            picPlayer.SizeMode = PictureBoxSizeMode.StretchImage;
            picPlayer.TabIndex = 0;
            picPlayer.TabStop = false;

            // 
            // picStar
            // 
            picStar.Location = new Point(170, 5);
            picStar.Name = "picStar";
            picStar.Size = new Size(16, 16);
            picStar.SizeMode = PictureBoxSizeMode.StretchImage;
            picStar.TabIndex = 1;
            picStar.TabStop = false;
            picStar.Visible = false;

            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(75, 5);
            lblName.Name = "lblName";
            lblName.Size = new Size(0, 20);
            lblName.TabIndex = 2;

            // 
            // lblNumber
            // 
            lblNumber.AutoSize = true;
            lblNumber.Location = new Point(75, 25);
            lblNumber.Name = "lblNumber";
            lblNumber.Size = new Size(0, 20);
            lblNumber.TabIndex = 3;

            // 
            // lblPosition
            // 
            lblPosition.AutoSize = true;
            lblPosition.Location = new Point(75, 45);
            lblPosition.Name = "lblPosition";
            lblPosition.Size = new Size(0, 20);
            lblPosition.TabIndex = 4;

            // 
            // lblCaptain
            // 
            lblCaptain.AutoSize = true;
            lblCaptain.ForeColor = Color.Red;
            lblCaptain.Location = new Point(75, 65);
            lblCaptain.Name = "lblCaptain";
            lblCaptain.Size = new Size(0, 20);
            lblCaptain.TabIndex = 5;

            // 
            // lblStatValue
            // 
            lblStatValue.AutoSize = true;
            lblStatValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblStatValue.Location = new Point(5, 60);
            lblStatValue.Name = "lblStatValue";
            lblStatValue.Size = new Size(0, 20);
            lblStatValue.TabIndex = 6;

            // 
            // PlayerControl
            // 
            Controls.Add(picPlayer);
            Controls.Add(picStar);
            Controls.Add(lblName);
            Controls.Add(lblNumber);
            Controls.Add(lblPosition);
            Controls.Add(lblCaptain);
            Controls.Add(lblStatValue);
            Name = "PlayerControl";
            Size = new Size(200, 85);
            ((System.ComponentModel.ISupportInitialize)picPlayer).EndInit();
            ((System.ComponentModel.ISupportInitialize)picStar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
