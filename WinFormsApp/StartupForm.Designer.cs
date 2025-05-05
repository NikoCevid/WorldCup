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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartupForm));
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
            resources.ApplyResources(lbChampionship, "lbChampionship");
            lbChampionship.Name = "lbChampionship";
            lbChampionship.Click += lbChampionship_Click;
            // 
            // lbLanguage
            // 
            resources.ApplyResources(lbLanguage, "lbLanguage");
            lbLanguage.Name = "lbLanguage";
            lbLanguage.Click += lbLanguage_Click;
            // 
            // cmbChampionship
            // 
            resources.ApplyResources(cmbChampionship, "cmbChampionship");
            cmbChampionship.FormattingEnabled = true;
            cmbChampionship.Name = "cmbChampionship";
            cmbChampionship.SelectedIndexChanged += cmbChampionship_SelectedIndexChanged;
            // 
            // cmbLanguage
            // 
            resources.ApplyResources(cmbLanguage, "cmbLanguage");
            cmbLanguage.FormattingEnabled = true;
            cmbLanguage.Name = "cmbLanguage";
            cmbLanguage.SelectedIndexChanged += cmbLanguage_SelectedIndexChanged;
            // 
            // btnApply
            // 
            resources.ApplyResources(btnApply, "btnApply");
            btnApply.Name = "btnApply";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += btnApply_Click;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(tableLayoutPanel1, "tableLayoutPanel1");
            tableLayoutPanel1.Controls.Add(lbChampionship, 0, 0);
            tableLayoutPanel1.Controls.Add(cmbChampionship, 0, 1);
            tableLayoutPanel1.Controls.Add(lbLanguage, 0, 2);
            tableLayoutPanel1.Controls.Add(cmbLanguage, 0, 3);
            tableLayoutPanel1.Controls.Add(btnApply, 0, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // StartupForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "StartupForm";
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