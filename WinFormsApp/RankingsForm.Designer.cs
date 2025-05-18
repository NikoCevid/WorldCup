namespace WinFormsApp
{
    partial class RankingsForm
    {
        private TableLayoutPanel tableLayoutPanel;

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
            this.tableLayoutPanel = new TableLayoutPanel();
            this.lblGoals = new Label();
            this.lblCards = new Label();
            this.lblAttendance = new Label();
            this.flpGoals = new FlowLayoutPanel();
            this.flpCards = new FlowLayoutPanel();
            this.flpAttendance = new FlowLayoutPanel();
            this.btnExport = new Button();
            this.SuspendLayout();

            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            this.tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            this.tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34F));
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F)); // Header labels
            this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F)); // Panels
            this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F)); // Export button
            this.tableLayoutPanel.Dock = DockStyle.Fill;
            this.tableLayoutPanel.Controls.Add(this.lblGoals, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.lblCards, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.lblAttendance, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.flpGoals, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.flpCards, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.flpAttendance, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.btnExport, 1, 2);

            // 
            // lblGoals
            // 
            this.lblGoals.Text = " Golovi";
            this.lblGoals.TextAlign = ContentAlignment.MiddleCenter;
            this.lblGoals.Dock = DockStyle.Fill;

            // 
            // lblCards
            // 
            this.lblCards.Text = " Žuti kartoni";
            this.lblCards.TextAlign = ContentAlignment.MiddleCenter;
            this.lblCards.Dock = DockStyle.Fill;
            this.lblCards.Click += lblCards_Click;

            // 
            // lblAttendance
            // 
            this.lblAttendance.Text = " Posjetitelji";
            this.lblAttendance.TextAlign = ContentAlignment.MiddleCenter;
            this.lblAttendance.Dock = DockStyle.Fill;
            this.lblAttendance.Click += lblAttendance_Click;

            // 
            // flpGoals
            // 
            this.flpGoals.AutoScroll = true;
            this.flpGoals.Dock = DockStyle.Fill;

            // 
            // flpCards
            // 
            this.flpCards.AutoScroll = true;
            this.flpCards.Dock = DockStyle.Fill;

            // 
            // flpAttendance
            // 
            this.flpAttendance.AutoScroll = true;
            this.flpAttendance.Dock = DockStyle.Fill;

            // 
            // btnExport
            // 
            this.btnExport.Text = "Export";
            this.btnExport.Size = new Size(100, 30);
            this.btnExport.Anchor = AnchorStyles.None;
            this.btnExport.Click += btnExport_Click;

            // 
            // RankingsForm
            // 
            this.ClientSize = new Size(1000, 700);
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "RankingsForm";
            this.Text = "RankingsForm";
            this.WindowState = FormWindowState.Maximized;

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