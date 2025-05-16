
using WinFormsApp.Helpers;

namespace WinFormsApp
{
        partial class PlayerControl
        {
            private System.Windows.Forms.PictureBox picPlayer;
            private System.Windows.Forms.PictureBox picStar;
            private System.Windows.Forms.Label lblName;
            private System.Windows.Forms.Label lblNumber;
            private System.Windows.Forms.Label lblPosition;
            private System.Windows.Forms.Label lblCaptain;

        private void InitializeComponent()
        {
            picPlayer = new PictureBox();
            picStar = new PictureBox();
            lblName = new Label();
            lblNumber = new Label();
            lblPosition = new Label();
            lblCaptain = new Label();
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
            // PlayerControl
            // 
            Controls.Add(picPlayer);
            Controls.Add(picStar);
            Controls.Add(lblName);
            Controls.Add(lblNumber);
            Controls.Add(lblPosition);
            Controls.Add(lblCaptain);
            Name = "PlayerControl";
            Size = new Size(200, 70);
            ((System.ComponentModel.ISupportInitialize)picPlayer).EndInit();
            ((System.ComponentModel.ISupportInitialize)picStar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
    }



