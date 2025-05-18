namespace WinFormsApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Button btnSettings;
        private Button btnExit;



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
            btnRankings = new Button();
            btnSettings = new Button();
            btnExit = new Button();
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
            pnlPlayers.AutoScroll = true;
            pnlPlayers.FlowDirection = FlowDirection.TopDown;
            pnlPlayers.Location = new Point(22, 128);
            pnlPlayers.Name = "pnlPlayers";
            pnlPlayers.Size = new Size(278, 307);
            pnlPlayers.TabIndex = 1;
            pnlPlayers.WrapContents = false;
            // 
            // pnlFavPlayers
            // 
            pnlFavPlayers.Location = new Point(320, 128);
            pnlFavPlayers.Name = "pnlFavPlayers";
            pnlFavPlayers.Size = new Size(282, 307);
            pnlFavPlayers.TabIndex = 0;
            // 
            // pnlPlayer
            // 
            pnlPlayer.Controls.Add(lblFavPlayer);
            pnlPlayer.Controls.Add(lblCaptain);
            pnlPlayer.Controls.Add(lblPosition);
            pnlPlayer.Controls.Add(lblShirt);
            pnlPlayer.Controls.Add(lblName);
            pnlPlayer.Controls.Add(pictureBox);
            pnlPlayer.Location = new Point(608, 128);
            pnlPlayer.Name = "pnlPlayer";
            pnlPlayer.Size = new Size(180, 307);
            pnlPlayer.TabIndex = 3;
            // 
            // lblFavPlayer
            // 
            lblFavPlayer.Location = new Point(10, 278);
            lblFavPlayer.Name = "lblFavPlayer";
            lblFavPlayer.Size = new Size(100, 23);
            lblFavPlayer.TabIndex = 0;
            lblFavPlayer.Text = "Favourite player:";
            // 
            // lblCaptain
            // 
            lblCaptain.Location = new Point(10, 249);
            lblCaptain.Name = "lblCaptain";
            lblCaptain.Size = new Size(100, 23);
            lblCaptain.TabIndex = 1;
            lblCaptain.Text = "Captain:";
            // 
            // lblPosition
            // 
            lblPosition.Location = new Point(10, 229);
            lblPosition.Name = "lblPosition";
            lblPosition.Size = new Size(100, 23);
            lblPosition.TabIndex = 2;
            lblPosition.Text = "Position:";
            // 
            // lblShirt
            // 
            lblShirt.Location = new Point(10, 199);
            lblShirt.Name = "lblShirt";
            lblShirt.Size = new Size(100, 23);
            lblShirt.TabIndex = 3;
            lblShirt.Text = "Shirt Number:";
            // 
            // lblName
            // 
            lblName.Location = new Point(11, 170);
            lblName.Name = "lblName";
            lblName.Size = new Size(100, 23);
            lblName.TabIndex = 4;
            lblName.Text = "Name:";
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(11, 14);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(166, 153);
            pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox.TabIndex = 5;
            pictureBox.TabStop = false;
            // 
            // btnTransfer
            // 
            btnTransfer.Location = new Point(33, 455);
            btnTransfer.Name = "btnTransfer";
            btnTransfer.Size = new Size(215, 29);
            btnTransfer.TabIndex = 7;
            btnTransfer.Text = "Transfer to favourites";
            btnTransfer.Click += btnTransfer_Click;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(345, 455);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(205, 29);
            btnRemove.TabIndex = 6;
            btnRemove.Text = "Remove from favourites";
            btnRemove.Click += btnRemove_Click;
            // 
            // btnPicutre
            // 
            btnPicutre.Location = new Point(618, 455);
            btnPicutre.Name = "btnPicutre";
            btnPicutre.Size = new Size(154, 29);
            btnPicutre.TabIndex = 5;
            btnPicutre.Text = "Add picture";
            btnPicutre.Click += btnPicutre_Click;
            // 
            // lblPlayers
            // 
            lblPlayers.Location = new Point(22, 93);
            lblPlayers.Name = "lblPlayers";
            lblPlayers.Size = new Size(100, 23);
            lblPlayers.TabIndex = 4;
            lblPlayers.Text = "Players:";
            // 
            // lblFavPlayers
            // 
            lblFavPlayers.Location = new Point(320, 93);
            lblFavPlayers.Name = "lblFavPlayers";
            lblFavPlayers.Size = new Size(139, 23);
            lblFavPlayers.TabIndex = 3;
            lblFavPlayers.Text = "Favourite players:";
            // 
            // lblPlayer
            // 
            lblPlayer.Location = new Point(608, 93);
            lblPlayer.Name = "lblPlayer";
            lblPlayer.Size = new Size(100, 23);
            lblPlayer.TabIndex = 2;
            lblPlayer.Text = "Player:";
            // 
            // lblRepresentation
            // 
            lblRepresentation.Location = new Point(22, 48);
            lblRepresentation.Name = "lblRepresentation";
            lblRepresentation.Size = new Size(190, 23);
            lblRepresentation.TabIndex = 1;
            lblRepresentation.Text = "Favourite representation:";
            // 
            // btnRankings
            // 
            btnRankings.Location = new Point(439, 46);
            btnRankings.Name = "btnRankings";
            btnRankings.Size = new Size(120, 30);
            btnRankings.TabIndex = 0;
            btnRankings.Text = "Rankings";
            btnRankings.Click += btnRankings_Click;
            // 
            // btnSettings
            // 
            btnSettings.Location = new Point(585, 45);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(92, 33);
            btnSettings.TabIndex = 0;
            btnSettings.Text = "Postavke";
            btnSettings.Click += btnSettings_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(710, 46);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 30);
            btnExit.TabIndex = 8;
            btnExit.Text = "Izlaz";
            btnExit.Click += btnExit_Click;
            // 
            // MainForm
            // 
            ClientSize = new Size(800, 535);
            Controls.Add(btnSettings);
            Controls.Add(btnRankings);
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
            Controls.Add(btnExit);
            Name = "MainForm";
            Text = "MainForm";
            pnlPlayer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);

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
        private Button btnRankings;
    }
}