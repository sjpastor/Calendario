using Calendario.Clases;
using Calendario.Clases.Db.DAO;
using Calendario.Clases.Db.DTO;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace Calendario.Forms
{
    public partial class CalendarioAnualView : Form
    {
        public CalendarioAnualView()
        {
            InitializeComponent();
        }

        private void MiCalendario_Load(object sender, EventArgs e)
        {
            ConfiguraCalendarios();
            txtAnno.Text = DateTime.Now.Year.ToString();
            GeneraCalendarios();
            this.Left = 20;
            this.Top = 20;
            this.Width = this.Parent.Width - 80;
            this.Height = this.Parent.Height - 80;
            CargarGrids();
        }

        private void tsbAnnoMas_Click(object sender, EventArgs e)
        {
            txtAnno.Text = (Convert.ToInt32(txtAnno.Text) + 1).ToString();
            GeneraCalendarios();
        }

        private void tsbAnnoMenos_Click(object sender, EventArgs e)
        {
            txtAnno.Text = (Convert.ToInt32(txtAnno.Text) - 1).ToString();
            GeneraCalendarios();
        }

        private void dgvEnero_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            string fecha = dgvEnero.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag.ToString();

            MessageBox.Show(fecha);
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            splitContainer1.SplitterDistance = 1100;
        }

        private void txtAnno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
                GeneraCalendarios();

        }
        private void MiCalendario_Resize(object sender, EventArgs e)
        {
            Redimensionar();
        }

        private void Redimensionar()
        {
            this.Cursor = Cursors.WaitCursor;
            dgvEventosConFecha.Width = splitContainer1.Panel2.Width - 50;
            dgvEventosSinFecha.Width = splitContainer1.Panel2.Width - 50;
            this.Cursor = Cursors.Default;
        }

        private void ConfiguraCalendarios()
        {
            DataGridView dgvMes = new DataGridView();
            Label lblMes = new Label();

            for (int mes = 1; mes <= 12; mes++)
            {
                GetGridMes(mes, ref dgvMes, ref lblMes);
                for (int columna = 0; columna < dgvMes.Columns.Count; columna++)
                {
                    dgvMes.Columns[columna].Width = 35;
                }
            }
        }

        private void GetGridMes(int mes, ref DataGridView dgvMes, ref Label lblMes)
        {
            switch (mes)
            {
                case 1:
                    dgvMes = dgvEnero;
                    lblMes = lblEnero;
                    break;
                case 2:
                    dgvMes = dgvFebrero;
                    lblMes = lblFebrero;
                    break;
                case 3:
                    dgvMes = dgvMarzo;
                    lblMes = lblMarzo;
                    break;
                case 4:
                    dgvMes = dgvAbril;
                    lblMes = lblAbril;
                    break;
                case 5:
                    dgvMes = dgvMayo;
                    lblMes = lblMayo;
                    break;
                case 6:
                    dgvMes = dgvJunio;
                    lblMes = lblJunio;
                    break;
                case 7:
                    dgvMes = dgvJulio;
                    lblMes = lblJulio;
                    break;
                case 8:
                    dgvMes = dgvAgosto;
                    lblMes = lblAgosto;
                    break;
                case 9:
                    dgvMes = dgvSeptiembre;
                    lblMes = lblSeptiembre;
                    break;
                case 10:
                    dgvMes = dgvOctubre;
                    lblMes = lblOctubre;
                    break;
                case 11:
                    dgvMes = dgvNoviembre;
                    lblMes = lblNoviembre;
                    break;
                case 12:
                    dgvMes = dgvDiciembre;
                    lblMes = lblDiciembre;
                    break;
                default:
                    break;
            }
        }

        private void GeneraCalendarios()
        {
            int anno = Convert.ToInt32(txtAnno.Text);

            // Cargamos los días (numérico) en los Calendarios
            SetDiasCalendarios(anno);
        }

        private void SetDiasCalendarios(int anno)
        {

            DataGridView dgvMes = new DataGridView();
            Label lblMes = new Label();

            for (int mes = 1; mes <= 12; mes++)
            {
                GetGridMes(mes, ref dgvMes, ref lblMes);
                dgvMes.Rows.Clear();
                CalendarioDTO calendarioDto = new CalendarioDTO(lblMes, dgvMes, anno, mes);
                UtilesCalendarios.IniciarCalendario(calendarioDto);
            }

        }

        private void CargarGrids()
        {
            CargarGridEventosConFecha();
            CargarGridEventosSinFecha();
        }

        private void CargarGridEventosConFecha()
        {

            string[] datos = new string[6];
            bool mostrarRegistro;

            dgvEventosConFecha.Rows.Clear();
            //TareasViewGridConfig.ConfiguraDataGrid(view.dgvTareas);

            List<EventoConFechaDTO> eventos = EventosConFechaDAO.GetAllEventos("", "", "", true);
            if (eventos == null) return;

            foreach (EventoConFechaDTO evento in eventos)
            {
                datos[0] = evento.Id.ToString();
                datos[1] = evento.Fecha;
                datos[2] = evento.Hora;
                datos[3] = evento.Evento;
                datos[4] = evento.Comentarios;
                datos[5] = evento.Pendiente;
                dgvEventosConFecha.Rows.Add(datos);
            }

            return;

        }

        private void CargarGridEventosSinFecha()
        {

        }

        private void CalendarioAnualView_Shown(object sender, EventArgs e)
        {
            Redimensionar();
        }
    }
}
