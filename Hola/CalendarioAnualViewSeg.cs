using System;
using System.Windows.Forms;

namespace Calendario
{
    public partial class CalendarioAnualViewSeg : Form
    {

        private int izquierdaPanelSuperiorMinimizado;
        private int anchoPanelSuperiorMinimizado = 300;

        public CalendarioAnualViewSeg()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            posicionIzquierdaInicialPanelSuperior();
            //MostrarVentanaMinimizada();
            InicializarCalendario();
        }

        private void posicionIzquierdaInicialPanelSuperior()
        {
            izquierdaPanelSuperiorMinimizado = (Screen.PrimaryScreen.Bounds.Width - anchoPanelSuperiorMinimizado) / 2;
        }

        //private void MostrarVentanaMinimizada()
        //{
        //    return;
        //    this.Top = Screen.PrimaryScreen.Bounds.Top;
        //    this.Left = izquierdaPanelSuperiorMinimizado;
        //    this.Width = anchoPanelSuperiorMinimizado;
        //    this.Height = 30;
        //}

        //private void OcultarVentana()
        //{
        //    return;
        //    this.Top = Screen.PrimaryScreen.Bounds.Top;
        //    this.Left = Screen.PrimaryScreen.Bounds.Left;
        //    this.Width = Screen.PrimaryScreen.Bounds.Width;
        //    this.Height = 5;
        //}

        //private void MaximizarVentana()
        //{
        //    this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        //}

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("dd") + " ";
            lblHora.Text += "de " + MesEnTexto(DateTime.Now).ToLower() + " ";
            lblHora.Text += "del " + DateTime.Now.ToString("yyyy");
            lblHora.Text += new string(' ', 5);
            lblHora.Text += DateTime.Now.ToString("HH") + ":";
            lblHora.Text += DateTime.Now.ToString("mm") + ":";
            lblHora.Text += DateTime.Now.ToString("ss");

        }

        private string MesEnTexto(DateTime ahora)
        {
            switch (ahora.Month)
            {
                case 1: return "Enero";
                case 2: return "Febrero";
                case 3: return "Marzo";
                case 4: return "Abril";
                case 5: return "Mayo";
                case 6: return "Junio";
                case 7: return "Julio";
                case 8: return "Agosto";
                case 9: return "Septiembre";
                case 10: return "Octubre";
                case 11: return "Noviembre";
                case 12: return "Diciembre";
                default: return "";
            }

        }

        private void InicializarCalendario()
        {
            mesEnero.MinDate = Convert.ToDateTime("01/01/" + txtAnno.Value);
            mesEnero.MaxDate = Convert.ToDateTime("31/01/" + txtAnno.Value);
            mesFebrero.MinDate = Convert.ToDateTime("01/02/" + txtAnno.Value);
            mesFebrero.MaxDate = Convert.ToDateTime(UltimoDiaFebrero(txtAnno.Value).ToString() + "/02/" + txtAnno.Value);
            mesMarzo.MinDate = Convert.ToDateTime("01/03/" + txtAnno.Value);
            mesMarzo.MaxDate = Convert.ToDateTime("31/03/" + txtAnno.Value);
            //mesEnero.MinDate = Convert.ToDateTime("01/01/" + txtAnno.Value);
            //mesEnero.MaxDate = Convert.ToDateTime("31/01/" + txtAnno.Value);
            //mesEnero.MinDate = Convert.ToDateTime("01/01/" + txtAnno.Value);
            //mesEnero.MaxDate = Convert.ToDateTime("31/01/" + txtAnno.Value);
            //mesEnero.MinDate = Convert.ToDateTime("01/01/" + txtAnno.Value);
            //mesEnero.MaxDate = Convert.ToDateTime("31/01/" + txtAnno.Value);
        }

        private int UltimoDiaFebrero(decimal anno)
        {
            DateTime primerDiaDeMarzo = new DateTime(2025, 3, 1);
            DateTime ultimoDiaDeFebrero = primerDiaDeMarzo.AddDays(-1);
            return ultimoDiaDeFebrero.Day;
        }

        private void CalendarioView_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                RelojView rv = new RelojView();
                rv.ShowDialog();
                this.Hide();
            }
        }

        private void splitContainer1_SplitterMoving(object sender, SplitterCancelEventArgs e)
        {
            label1.Text = "Panel izquierdo = " + splitContainer1.Panel1.Width + " , Panel derecho = " + splitContainer1.Panel1.Width;
        }
    }
}
