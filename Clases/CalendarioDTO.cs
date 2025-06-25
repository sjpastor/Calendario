using System.Windows.Forms;

namespace Calendario.Clases
{
    public class CalendarioDTO
    {

        private Label lblMes;
        private DataGridView dgvMes;
        private int anno = 0;
        private int mes = 0;

        public Label LblMes { get => lblMes; set => lblMes = value; }
        public DataGridView DgvMes { get => dgvMes; set => dgvMes = value; }
        public int Anno { get => anno; set => anno = value; }
        public int Mes { get => mes; set => mes = value; }

        public CalendarioDTO(Label lblMes, DataGridView dgvMes, int anno, int mes)
        {
            this.LblMes = lblMes;
            this.DgvMes = dgvMes;
            this.Anno = anno;
            this.Mes = mes;
        }

    }
}
