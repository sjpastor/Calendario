using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Calendario
{
    public partial class RelojView : Form
    {

        //private Label labelHora;
        private Timer timerHora;
        private Timer timerMouse;
        private bool fijar = false;

        private bool oculto = true;

        public RelojView()
        {

            InitializeComponent();

            // Propiedades del formulario
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            this.Width = 500;
            this.Height = 30;
            this.StartPosition = FormStartPosition.Manual;

            // Posicionar arriba centrado
            int pantallaAncho = Screen.PrimaryScreen.Bounds.Width;
            this.Location = new Point((pantallaAncho - this.Width) / 2, -this.Height + 1);

            // Timer para actualizar la hora
            timerHora = new Timer();
            timerHora.Interval = 1000;
            timerHora.Tick += (s, e) =>
            {
                lblHora.Text = DateTime.Now.ToString("dddd dd/MM/yyyy HH:mm:ss");
            };
            timerHora.Start();

            // Timer para detectar cursor
            timerMouse = new Timer();
            timerMouse.Interval = 100;
            timerMouse.Tick += (s, e) =>
            {
                MostrarOcultar();
            };
            timerMouse.Start();
        }

        private void RelojView_Load(object sender, EventArgs e)
        {
            byte[] imageData;
            imageData = Properties.Resources.SinFijar;

            using (MemoryStream ms = new MemoryStream(imageData))
            {
                Image image = Image.FromStream(ms);
                this.cmdFijar.Image = image;
            }
        }

        private void MostrarOcultar()
        {
            Point cursorPos = Cursor.Position;
            if (cursorPos.Y <= this.Height)
            {
                if (oculto)
                {
                    this.Location = new Point(this.Location.X, 0);
                    oculto = false;
                }
            }
            else
            {
                if (!oculto && !fijar)
                {
                    this.Location = new Point(this.Location.X, -this.Height + 1);
                    oculto = true;
                }
            }
        }

        private void lblHora_Click(object sender, EventArgs e)
        {
            CalendarioAnualView calendario = new CalendarioAnualView();
            this.Dispose();
            calendario.ShowDialog();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cmdFijar_Click(object sender, EventArgs e)
        {
            byte[] imageData;
            fijar = !fijar;

            if (fijar)
                imageData = Properties.Resources.Fijado;
            else
                imageData = Properties.Resources.SinFijar;

            using (MemoryStream ms = new MemoryStream(imageData))
            {
                Image image = Image.FromStream(ms);
                this.cmdFijar.Image = image;
            }

        }

    }
}

