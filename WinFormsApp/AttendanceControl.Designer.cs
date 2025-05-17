using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp
{
    partial class AttendanceControl
    {
        private Label lblLocation;
        private Label lblAttendance;
        private Label lblTeams;

        private void InitializeComponent()
        {
            lblLocation = new Label();
            lblAttendance = new Label();
            lblTeams = new Label();

            SuspendLayout();

            // lblLocation
            lblLocation.AutoSize = true;
            lblLocation.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblLocation.Location = new Point(5, 5);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(70, 20);

            // lblAttendance
            lblAttendance.AutoSize = true;
            lblAttendance.Location = new Point(5, 30);
            lblAttendance.Name = "lblAttendance";
            lblAttendance.Size = new Size(100, 20);

            // lblTeams
            lblTeams.AutoSize = true;
            lblTeams.Location = new Point(5, 50);
            lblTeams.Name = "lblTeams";
            lblTeams.Size = new Size(150, 20);

            // AttendanceControl
            Controls.Add(lblLocation);
            Controls.Add(lblAttendance);
            Controls.Add(lblTeams);
            Name = "AttendanceControl";
            Size = new Size(200, 75);
            BorderStyle = BorderStyle.FixedSingle;

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
