using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp
{
    partial class PlayerControl
    {
        private System.ComponentModel.IContainer components = null;
        private PictureBox picPlayer;
        private PictureBox picStar;
        private Label lblName;
        private Label lblNumber;
        private Label lblPosition;
        private Label lblCaptain;
        private Label lblStatValue;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.picPlayer = new PictureBox();
            this.picStar = new PictureBox();
            this.lblName = new Label();
            this.lblNumber = new Label();
            this.lblPosition = new Label();
            this.lblCaptain = new Label();
            this.lblStatValue = new Label();

            ((System.ComponentModel.ISupportInitialize)(this.picPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStar)).BeginInit();
            this.SuspendLayout();

            // 
            // picPlayer
            // 
            this.picPlayer.Location = new Point(5, 5);
            this.picPlayer.Size = new Size(48, 48);
            this.picPlayer.SizeMode = PictureBoxSizeMode.Zoom;
            this.picPlayer.Image = null;

            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new Point(60, 5);
            this.lblName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            // 
            // picStar
            // 
            this.picStar.Size = new Size(16, 16);
            this.picStar.SizeMode = PictureBoxSizeMode.Zoom;
            this.picStar.Location = new Point(200, 5); // default, ali možeš overrideat ručno
            this.picStar.Visible = false;

            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new Point(60, 25);

            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new Point(60, 45);

            // 
            // lblCaptain
            // 
            this.lblCaptain.AutoSize = true;
            this.lblCaptain.ForeColor = Color.Red;
            this.lblCaptain.Location = new Point(60, 65);

            // 
            // lblStatValue
            // 
            this.lblStatValue.AutoSize = true;
            this.lblStatValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblStatValue.Location = new Point(180, 75); // ⬅️ podignuto gore da se ne reže

            // 
            // PlayerControl
            // 
            this.Controls.Add(this.picPlayer);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.picStar);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.lblCaptain);
            this.Controls.Add(this.lblStatValue);

            this.Size = new Size(250, 100);
            this.BorderStyle = BorderStyle.FixedSingle;

            ((System.ComponentModel.ISupportInitialize)(this.picPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
