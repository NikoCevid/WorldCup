namespace WinFormsApp
{
    partial class StartupForm
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
            lbChampionship = new Label();
            lbLanguage = new Label();
            cmbChampionship = new ComboBox();
            cmbLanguage = new ComboBox();
            btnApply = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // lbChampionship
            // 
            lbChampionship.Anchor = AnchorStyles.None;
            lbChampionship.AutoSize = true;
            lbChampionship.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lbChampionship.Name = "lbChampionship";
            lbChampionship.Size = new Size(207, 28);
            lbChampionship.TabIndex = 0;
            lbChampionship.Text = "Select championship";
            lbChampionship.TextAlign = ContentAlignment.TopCenter;
            lbChampionship.Click += lbChampionship_Click;
            // 
            // lbLanguage
            // 
            lbLanguage.Anchor = AnchorStyles.None;
            lbLanguage.AutoSize = true;
            lbLanguage.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lbLanguage.Name = "lbLanguage";
            lbLanguage.Size = new Size(162, 28);
            lbLanguage.TabIndex = 1;
            lbLanguage.Text = "Select language";
            lbLanguage.Click += lbLanguage_Click;
            // 
            // cmbChampionship
            // 
            cmbChampionship.Anchor = AnchorStyles.None;
            cmbChampionship.FormattingEnabled = true;
            cmbChampionship.Name = "cmbChampionship";
            cmbChampionship.Size = new Size(151, 28);
            cmbChampionship.TabIndex = 2;
            cmbChampionship.SelectedIndexChanged += cmbChampionship_SelectedIndexChanged;
            // 
            // cmbLanguage
            // 
            cmbLanguage.Anchor = AnchorStyles.None;
            cmbLanguage.FormattingEnabled = true;
            cmbLanguage.Name = "cmbLanguage";
            cmbLanguage.Size = new Size(184, 28);
            cmbLanguage.TabIndex = 3;
            cmbLanguage.SelectedIndexChanged += cmbLanguage_SelectedIndexChanged;
            // 
            // btnApply
            // 
            btnApply.Anchor = AnchorStyles.None;
            btnApply.FlatStyle = FlatStyle.Flat;
            btnApply.Font = new Font("Segoe UI", 10F);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(94, 35);
            btnApply.TabIndex = 4;
            btnApply.Text = "Apply";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += btnApply_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(lbChampionship, 0, 0);
            tableLayoutPanel1.Controls.Add(cmbChampionship, 0, 1);
            tableLayoutPanel1.Controls.Add(lbLanguage, 0, 2);
            tableLayoutPanel1.Controls.Add(cmbLanguage, 0, 3);
            tableLayoutPanel1.Controls.Add(btnApply, 0, 4);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 8F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 5;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // StartupForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "StartupForm";
            Text = "StartupForm";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }


        #endregion

        private Label lbChampionship;
        private Label lbLanguage;
        private ComboBox cmbChampionship;
        private ComboBox cmbLanguage;
        private Button btnApply;
        private TableLayoutPanel tableLayoutPanel1;
    }
}