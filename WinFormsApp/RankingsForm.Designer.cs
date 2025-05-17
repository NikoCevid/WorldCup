namespace WinFormsApp
{
    partial class RankingsForm
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
            this.flpGoals = new FlowLayoutPanel();
            this.flpCards = new FlowLayoutPanel();
            this.flpAttendance = new FlowLayoutPanel();
            this.btnExport = new Button();
            this.lblGoals = new Label();
            this.lblCards = new Label();
            this.lblAttendance = new Label();

            this.SuspendLayout();

            // Labels
            this.lblGoals.Text = "🏆 Golovi";
            this.lblGoals.Location = new Point(30, 20);
            this.lblGoals.Size = new Size(200, 20);

            this.lblCards.Text = "🟨 Žuti kartoni";
            this.lblCards.Location = new Point(270, 20);
            this.lblCards.Size = new Size(200, 20);

            this.lblAttendance.Text = "👥 Posjetitelji";
            this.lblAttendance.Location = new Point(510, 20);
            this.lblAttendance.Size = new Size(200, 20);

            // flpGoals
            this.flpGoals.Location = new Point(30, 50);
            this.flpGoals.Size = new Size(200, 350);
            this.flpGoals.AutoScroll = true;

            // flpCards
            this.flpCards.Location = new Point(270, 50);
            this.flpCards.Size = new Size(200, 350);
            this.flpCards.AutoScroll = true;

            // flpAttendance
            this.flpAttendance.Location = new Point(510, 50);
            this.flpAttendance.Size = new Size(250, 350);
            this.flpAttendance.AutoScroll = true;

            // btnExport
            this.btnExport.Text = "Export";
            this.btnExport.Location = new Point(350, 420);
            this.btnExport.Size = new Size(100, 30);
            this.btnExport.Click += new EventHandler(this.btnExport_Click);

            // RankingsForm
            this.ClientSize = new Size(800, 480);
            this.Controls.Add(this.lblGoals);
            this.Controls.Add(this.lblCards);
            this.Controls.Add(this.lblAttendance);
            this.Controls.Add(this.flpGoals);
            this.Controls.Add(this.flpCards);
            this.Controls.Add(this.flpAttendance);
            this.Controls.Add(this.btnExport);
            this.Name = "RankingsForm";
            this.Text = "RankingsForm";
            this.ResumeLayout(false);
        }



        #endregion

        private FlowLayoutPanel flpGoals;
        private FlowLayoutPanel flpCards;
        private FlowLayoutPanel flpAttendance;
        private Button btnExport;
        private Label lblGoals;
        private Label lblCards;
        private Label lblAttendance;

    }
}