using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class AttendanceControl : UserControl
    {
        public AttendanceControl(string location, int attendance, string homeTeam, string awayTeam)
        {
            InitializeComponent();

            lblLocation.Text = location;
            lblAttendance.Text = $"{attendance:N0} gledatelja";
            lblTeams.Text = $"{homeTeam} vs {awayTeam}";
        }
    }
}
