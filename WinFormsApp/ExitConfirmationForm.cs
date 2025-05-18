using System;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class ExitConfirmationForm : Form
    {
        public ExitConfirmationForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += ExitConfirmationForm_KeyDown;
        }

        private void ExitConfirmationForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnYes.PerformClick();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnNo.PerformClick();
            }
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
