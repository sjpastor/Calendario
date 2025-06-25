using Calendario.Forms;
using System;
using System.Windows.Forms;

namespace Calendario
{
    public partial class CalendarioView : Form
    {
        public CalendarioView()
        {
            InitializeComponent();
        }

        private void anualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CalendarioAnualView cav = new CalendarioAnualView();
            cav.MdiParent = this;
            cav.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void micalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CalendarioAnualView cav = new CalendarioAnualView();
            cav.MdiParent = this;
            cav.Show();
        }

        private void CalendarioView_Load(object sender, EventArgs e)
        {

        }
    }
}
