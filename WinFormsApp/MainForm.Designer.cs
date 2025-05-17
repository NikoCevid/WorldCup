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
            this.cmbRepresentation = new ComboBox();
            this.pnlPlayers = new FlowLayoutPanel();
            this.pnlFavPlayers = new FlowLayoutPanel();
            this.pnlPlayer = new Panel();
            this.lblFavPlayer = new Label();
            this.lblCaptain = new Label();
            this.lblPosition = new Label();
            this.lblShirt = new Label();
            this.lblName = new Label();
            this.pictureBox = new PictureBox();
            this.btnTransfer = new Button();
            this.btnRemove = new Button();
            this.btnPicutre = new Button();
            this.lblPlayers = new Label();
            this.lblFavPlayers = new Label();
            this.lblPlayer = new Label();
            this.lblRepresentation = new Label();
            this.btnRankings = new Button();

            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.pnlPlayer.SuspendLayout();
            this.SuspendLayout();

            // cmbRepresentation
            this.cmbRepresentation.FormattingEnabled = true;
            this.cmbRepresentation.Location = new Point(241, 48);
            this.cmbRepresentation.Name = "cmbRepresentation";
            this.cmbRepresentation.Size = new Size(151, 28);
            this.cmbRepresentation.TabIndex = 0;
            this.cmbRepresentation.SelectedIndexChanged += new EventHandler(this.cmbRepresentation_SelectedIndexChanged);

            // pnlPlayers
            this.pnlPlayers.AutoScroll = true;
            this.pnlPlayers.FlowDirection = FlowDirection.TopDown;
            this.pnlPlayers.Location = new Point(22, 128);
            this.pnlPlayers.Name = "pnlPlayers";
            this.pnlPlayers.Size = new Size(250, 307);
            this.pnlPlayers.TabIndex = 1;
            this.pnlPlayers.WrapContents = false;

            // pnlFavPlayers
            this.pnlFavPlayers.Location = new Point(320, 128);
            this.pnlFavPlayers.Name = "pnlFavPlayers";
            this.pnlFavPlayers.Size = new Size(250, 307);
            this.pnlFavPlayers.TabIndex = 0;

            // pnlPlayer
            this.pnlPlayer.Controls.Add(this.lblFavPlayer);
            this.pnlPlayer.Controls.Add(this.lblCaptain);
            this.pnlPlayer.Controls.Add(this.lblPosition);
            this.pnlPlayer.Controls.Add(this.lblShirt);
            this.pnlPlayer.Controls.Add(this.lblName);
            this.pnlPlayer.Controls.Add(this.pictureBox);
            this.pnlPlayer.Location = new Point(608, 128);
            this.pnlPlayer.Name = "pnlPlayer";
            this.pnlPlayer.Size = new Size(180, 307);
            this.pnlPlayer.TabIndex = 3;

            // Labels and PictureBox
            this.lblFavPlayer.Location = new Point(10, 278);
            this.lblCaptain.Location = new Point(10, 249);
            this.lblPosition.Location = new Point(10, 229);
            this.lblShirt.Location = new Point(10, 199);
            this.lblName.Location = new Point(11, 170);
            this.pictureBox.Location = new Point(11, 14);
            this.pictureBox.Size = new Size(123, 153);
            this.pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;

            this.lblFavPlayer.Text = "Favourite player:";
            this.lblCaptain.Text = "Captain:";
            this.lblPosition.Text = "Position:";
            this.lblShirt.Text = "Shirt Number:";
            this.lblName.Text = "Name:";

            // btnTransfer
            this.btnTransfer.Location = new Point(33, 455);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new Size(215, 29);
            this.btnTransfer.Text = "Transfer to favourites";
            this.btnTransfer.Click += new EventHandler(this.btnTransfer_Click);

            // btnRemove
            this.btnRemove.Location = new Point(302, 455);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new Size(205, 29);
            this.btnRemove.Text = "Remove from favourites";
            this.btnRemove.Click += new EventHandler(this.btnRemove_Click);

            // btnPicutre
            this.btnPicutre.Location = new Point(584, 455);
            this.btnPicutre.Name = "btnPicutre";
            this.btnPicutre.Size = new Size(154, 29);
            this.btnPicutre.Text = "Add picture";
            this.btnPicutre.Click += new EventHandler(this.btnPicutre_Click);

            // Labels
            this.lblPlayers.Location = new Point(22, 93);
            this.lblPlayers.Text = "Players:";
            this.lblFavPlayers.Location = new Point(320, 93);
            this.lblFavPlayers.Text = "Favourite players:";
            this.lblPlayer.Location = new Point(608, 93);
            this.lblPlayer.Text = "Player:";
            this.lblRepresentation.Location = new Point(22, 48);
            this.lblRepresentation.Text = "Favourite representation:";

            // btnRankings
            this.btnRankings.Location = new Point(493, 43);
            this.btnRankings.Name = "btnRankings";
            this.btnRankings.Size = new Size(120, 30);
            this.btnRankings.Text = "Rankings";
            this.btnRankings.Click += new System.EventHandler(this.btnRankings_Click);


            // MainForm
            this.ClientSize = new Size(800, 535);
            this.Controls.Add(this.btnRankings);
            this.Controls.Add(this.lblRepresentation);
            this.Controls.Add(this.lblPlayer);
            this.Controls.Add(this.lblFavPlayers);
            this.Controls.Add(this.lblPlayers);
            this.Controls.Add(this.btnPicutre);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.pnlFavPlayers);
            this.Controls.Add(this.pnlPlayer);
            this.Controls.Add(this.pnlPlayers);
            this.Controls.Add(this.cmbRepresentation);
            this.Name = "MainForm";
            this.Text = "MainForm";

            this.pnlPlayer.ResumeLayout(false);
            this.pnlPlayer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
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