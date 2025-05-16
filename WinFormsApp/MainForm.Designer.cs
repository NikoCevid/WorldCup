namespace WinFormsApp
{
    partial class MainForm
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
            cmbRepresentation = new ComboBox();
            pnlPlayers = new FlowLayoutPanel();
            pnlFavPlayers = new FlowLayoutPanel();
            pnlPlayer = new Panel();
            lblFavPlayer = new Label();
            lblCaptain = new Label();
            lblPosition = new Label();
            lblShirt = new Label();
            lblName = new Label();
            pictureBox = new PictureBox();
            btnTransfer = new Button();
            btnRemove = new Button();
            btnPicutre = new Button();
            lblPlayers = new Label();
            lblFavPlayers = new Label();
            lblPlayer = new Label();
            lblRepresentation = new Label();
            pnlPlayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // cmbRepresentation
            // 
            cmbRepresentation.FormattingEnabled = true;
            cmbRepresentation.Location = new Point(241, 48);
            cmbRepresentation.Name = "cmbRepresentation";
            cmbRepresentation.Size = new Size(151, 28);
            cmbRepresentation.TabIndex = 0;
            cmbRepresentation.SelectedIndexChanged += cmbRepresentation_SelectedIndexChanged;
            // 
            // pnlPlayers
            // 
            pnlPlayers.Location = new Point(22, 128);
            pnlPlayers.Name = "pnlPlayers";
            pnlPlayers.Size = new Size(250, 200);
            pnlPlayers.TabIndex = 1;
            pnlPlayers.FlowDirection = FlowDirection.TopDown;
            pnlPlayers.WrapContents = false;
            pnlPlayers.AutoScroll = true;
            pnlPlayers.Paint += pnlPlayers_Paint;
            // 
            // pnlFavPlayers
            // 
            pnlFavPlayers.Location = new Point(320, 128);
            pnlFavPlayers.Name = "pnlFavPlayers";
            pnlFavPlayers.Size = new Size(250, 200);
            pnlFavPlayers.TabIndex = 0;
            pnlFavPlayers.Paint += pnlFavPlayers_Paint;
            // 
            // pnlPlayer
            // 
            pnlPlayer.Controls.Add(lblFavPlayer);
            pnlPlayer.Controls.Add(lblCaptain);
            pnlPlayer.Controls.Add(lblPosition);
            pnlPlayer.Controls.Add(lblShirt);
            pnlPlayer.Controls.Add(lblName);
            pnlPlayer.Controls.Add(pictureBox);
            pnlPlayer.Location = new Point(584, 128);
            pnlPlayer.Name = "pnlPlayer";
            pnlPlayer.Size = new Size(150, 250);
            pnlPlayer.TabIndex = 3;
            pnlPlayer.Paint += pnlPlayer_Paint;
            // 
            // lblFavPlayer
            // 
            lblFavPlayer.AutoSize = true;
            lblFavPlayer.Location = new Point(13, 214);
            lblFavPlayer.Name = "lblFavPlayer";
            lblFavPlayer.Size = new Size(117, 20);
            lblFavPlayer.TabIndex = 5;
            lblFavPlayer.Text = "Favourite player:";
            lblFavPlayer.Click += lblFavPlayer_Click;
            // 
            // lblCaptain
            // 
            lblCaptain.AutoSize = true;
            lblCaptain.Location = new Point(12, 194);
            lblCaptain.Name = "lblCaptain";
            lblCaptain.Size = new Size(63, 20);
            lblCaptain.TabIndex = 4;
            lblCaptain.Text = "Captain:";
            lblCaptain.Click += lblCaptain_Click;
            // 
            // lblPosition
            // 
            lblPosition.AutoSize = true;
            lblPosition.Location = new Point(11, 162);
            lblPosition.Name = "lblPosition";
            lblPosition.Size = new Size(64, 20);
            lblPosition.TabIndex = 3;
            lblPosition.Text = "Position:";
            lblPosition.Click += lblPosition_Click;
            // 
            // lblShirt
            // 
            lblShirt.AutoSize = true;
            lblShirt.Location = new Point(13, 128);
            lblShirt.Name = "lblShirt";
            lblShirt.Size = new Size(100, 20);
            lblShirt.TabIndex = 2;
            lblShirt.Text = "Shirt Number:";
            lblShirt.Click += lblShirt_Click;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(11, 95);
            lblName.Name = "lblName";
            lblName.Size = new Size(52, 20);
            lblName.TabIndex = 1;
            lblName.Text = "Name:";
            lblName.Click += lblName_Click;
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(11, 14);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(123, 56);
            pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            pictureBox.Click += pictureBox_Click;
            // 
            // btnTransfer
            // 
            btnTransfer.Location = new Point(22, 392);
            btnTransfer.Name = "btnTransfer";
            btnTransfer.Size = new Size(215, 29);
            btnTransfer.TabIndex = 0;
            btnTransfer.Text = "Transfer to favourites";
            btnTransfer.UseVisualStyleBackColor = true;
            btnTransfer.Click += btnTransfer_Click;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(296, 392);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(205, 29);
            btnRemove.TabIndex = 4;
            btnRemove.Text = "Remove from favourites";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnPicutre
            // 
            btnPicutre.Location = new Point(584, 392);
            btnPicutre.Name = "btnPicutre";
            btnPicutre.Size = new Size(154, 29);
            btnPicutre.TabIndex = 5;
            btnPicutre.Text = "Add picture";
            btnPicutre.UseVisualStyleBackColor = true;
            btnPicutre.Click += btnPicutre_Click;
            // 
            // lblPlayers
            // 
            lblPlayers.AutoSize = true;
            lblPlayers.Location = new Point(22, 93);
            lblPlayers.Name = "lblPlayers";
            lblPlayers.Size = new Size(58, 20);
            lblPlayers.TabIndex = 0;
            lblPlayers.Text = "Players:";
            lblPlayers.Click += lblPlayers_Click;
            // 
            // lblFavPlayers
            // 
            lblFavPlayers.AutoSize = true;
            lblFavPlayers.Location = new Point(320, 93);
            lblFavPlayers.Name = "lblFavPlayers";
            lblFavPlayers.Size = new Size(123, 20);
            lblFavPlayers.TabIndex = 8;
            lblFavPlayers.Text = "Favourite players:";
            lblFavPlayers.Click += lblFavPlayers_Click;
            // 
            // lblPlayer
            // 
            lblPlayer.AutoSize = true;
            lblPlayer.Location = new Point(584, 93);
            lblPlayer.Name = "lblPlayer";
            lblPlayer.Size = new Size(52, 20);
            lblPlayer.TabIndex = 9;
            lblPlayer.Text = "Player:";
            lblPlayer.Click += lblPlayer_Click;
            // 
            // lblRepresentation
            // 
            lblRepresentation.AutoSize = true;
            lblRepresentation.Location = new Point(22, 48);
            lblRepresentation.Name = "lblRepresentation";
            lblRepresentation.Size = new Size(172, 20);
            lblRepresentation.TabIndex = 10;
            lblRepresentation.Text = "Favourite representation:";
            lblRepresentation.Click += lblRepresentation_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 535);
            Controls.Add(lblRepresentation);
            Controls.Add(lblPlayer);
            Controls.Add(lblFavPlayers);
            Controls.Add(lblPlayers);
            Controls.Add(btnPicutre);
            Controls.Add(btnRemove);
            Controls.Add(btnTransfer);
            Controls.Add(pnlFavPlayers);
            Controls.Add(pnlPlayer);
            Controls.Add(pnlPlayers);
            Controls.Add(cmbRepresentation);
            Name = "MainForm";
            Text = "MainForm";
            pnlPlayer.ResumeLayout(false);
            pnlPlayer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbRepresentation;
        private FlowLayoutPanel pnlPlayers;
        private FlowLayoutPanel pnlFavPlayers;
        private Panel pnlPlayer;
        private Button btnTransfer;
        private Button btnRemove;
        private Button btnPicutre;
        private MenuStrip menuStrip1;
        private Label lblPlayers;
        private Label lblFavPlayers;
        private Label lblPlayer;
        private Label lblRepresentation;
        private PictureBox pictureBox;
        private Label lblName;
        private Label lblShirt;
        private Label lblCaptain;
        private Label lblPosition;
        private Label lblFavPlayer;
    }
}