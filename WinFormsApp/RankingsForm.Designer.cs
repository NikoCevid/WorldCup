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
            tableLayoutPanel = new TableLayoutPanel();
            lblGoals = new Label();
            lblCards = new Label();
            lblAttendance = new Label();
            flpGoals = new FlowLayoutPanel();
            flpCards = new FlowLayoutPanel();
            flpAttendance = new FlowLayoutPanel();
            btnExport = new Button();
            tableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 3;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34F));
            tableLayoutPanel.Controls.Add(lblGoals, 0, 0);
            tableLayoutPanel.Controls.Add(lblCards, 1, 0);
            tableLayoutPanel.Controls.Add(lblAttendance, 2, 0);
            tableLayoutPanel.Controls.Add(flpGoals, 0, 1);
            tableLayoutPanel.Controls.Add(flpCards, 1, 1);
            tableLayoutPanel.Controls.Add(flpAttendance, 2, 1);
            tableLayoutPanel.Controls.Add(btnExport, 1, 2);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 3;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel.Size = new Size(1000, 700);
            tableLayoutPanel.TabIndex = 0;
            // 
            // lblGoals
            // 
            lblGoals.Dock = DockStyle.Fill;
            lblGoals.Location = new Point(3, 0);
            lblGoals.Name = "lblGoals";
            lblGoals.Size = new Size(327, 25);
            lblGoals.TabIndex = 0;
            lblGoals.Text = " Goals";
            lblGoals.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCards
            // 
            lblCards.Dock = DockStyle.Fill;
            lblCards.Location = new Point(336, 0);
            lblCards.Name = "lblCards";
            lblCards.Size = new Size(327, 25);
            lblCards.TabIndex = 1;
            lblCards.Text = "Yellow cards";
            lblCards.TextAlign = ContentAlignment.MiddleCenter;
            lblCards.Click += lblCards_Click;
            // 
            // lblAttendance
            // 
            lblAttendance.Dock = DockStyle.Fill;
            lblAttendance.Location = new Point(669, 0);
            lblAttendance.Name = "lblAttendance";
            lblAttendance.Size = new Size(328, 25);
            lblAttendance.TabIndex = 2;
            lblAttendance.Text = "Attendance";
            lblAttendance.TextAlign = ContentAlignment.MiddleCenter;
            lblAttendance.Click += lblAttendance_Click;
            // 
            // flpGoals
            // 
            flpGoals.AutoScroll = true;
            flpGoals.Dock = DockStyle.Fill;
            flpGoals.Location = new Point(3, 28);
            flpGoals.Name = "flpGoals";
            flpGoals.Size = new Size(327, 619);
            flpGoals.TabIndex = 3;
            // 
            // flpCards
            // 
            flpCards.AutoScroll = true;
            flpCards.Dock = DockStyle.Fill;
            flpCards.Location = new Point(336, 28);
            flpCards.Name = "flpCards";
            flpCards.Size = new Size(327, 619);
            flpCards.TabIndex = 4;
            // 
            // flpAttendance
            // 
            flpAttendance.AutoScroll = true;
            flpAttendance.Dock = DockStyle.Fill;
            flpAttendance.Location = new Point(669, 28);
            flpAttendance.Name = "flpAttendance";
            flpAttendance.Size = new Size(328, 619);
            flpAttendance.TabIndex = 5;
            // 
            // btnExport
            // 
            btnExport.Anchor = AnchorStyles.None;
            btnExport.Location = new Point(449, 660);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(100, 30);
            btnExport.TabIndex = 6;
            btnExport.Text = "Export";
            btnExport.Click += btnExport_Click;
            // 
            // RankingsForm
            // 
            ClientSize = new Size(1000, 700);
            Controls.Add(tableLayoutPanel);
            Name = "RankingsForm";
            Text = "RankingsForm";
            WindowState = FormWindowState.Maximized;
            tableLayoutPanel.ResumeLayout(false);
            ResumeLayout(false);
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