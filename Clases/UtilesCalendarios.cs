using System;
using System.Drawing;
using System.Windows.Forms;

namespace Calendario.Clases
{
    public class UtilesCalendarios
    {

        private const int DIAS_SEMANA = 7;
        private const int COL_VIERNES = 4;
        private const int COL_DOMINGO = 6;

        public static void IniciarCalendario(CalendarioDTO calendarioDto)
        {
            DateTime fecha = new DateTime();
            string[] datos = GetNewArrayDatos();

            // Configuramos el "label" del mes
            ConfiguraLabelMes(calendarioDto);

            for (int dia = 1; dia <= UtilesFechas.GetDiaFindeMes(calendarioDto.Anno, calendarioDto.Mes); dia++)
                {
                    fecha = new DateTime(calendarioDto.Anno, calendarioDto.Mes, dia);
                    int diaSemana = UtilesFechas.GetDiaSemana(fecha);
                    datos[diaSemana - 1] = dia.ToString();
                    if (diaSemana == COL_DOMINGO + 1)
                    {
                        calendarioDto.DgvMes.Rows.Add(datos);
                        datos = GetNewArrayDatos();
                    }

                }
            if (!datos[0].Equals(""))
            {
                calendarioDto.DgvMes.Rows.Add(datos);
                datos = GetNewArrayDatos();
            }

            SetMesCalendario(calendarioDto.DgvMes, calendarioDto.Anno, calendarioDto.Mes);

        }

        private static void ConfiguraLabelMes(CalendarioDTO calendarioDto)
        {
            calendarioDto.LblMes.Text = UtilesFechas.GetMesTexto(calendarioDto.Mes);

            if (calendarioDto.Anno == DateTime.Now.Year && calendarioDto.Mes == DateTime.Now.Month)
                calendarioDto.LblMes.BackColor = Color.PaleGreen;
            else
                calendarioDto.LblMes.BackColor = Color.LightCyan;
        }

        private static string[] GetNewArrayDatos()
        {
            // Creamos la matriz y la rellenamos con espacios
            string[] datos = new string[DIAS_SEMANA];
            for (int i = 0; i <= DIAS_SEMANA - 1; i++) { datos[i] = ""; }
            return datos;
        }

        private static void SetMesCalendario(DataGridView dgvMes, int anno, int mes)
        {
            string dia = "";

            for (int fila = 0; fila < dgvMes.Rows.Count; fila++)
            {
                for (int columna = 0; columna <= DIAS_SEMANA - 1; columna++)
                {
                    if (dgvMes.Rows[fila].Cells[columna].Value == null)
                        dgvMes.Rows[fila].Cells[columna].Value = "";

                    dia = dgvMes.Rows[fila].Cells[columna].Value.ToString();

                    if (dia.Equals(""))
                        dgvMes.Rows[fila].Cells[columna].Style.BackColor = Color.LightGray;
                    else
                    {
                        // Coloreamos las celdas
                        if (columna > COL_VIERNES)
                            dgvMes.Rows[fila].Cells[columna].Style.BackColor = Color.LightYellow;
                        else if (UtilesFechas.EsFestivo(new DateTime(anno, mes, Convert.ToInt32(dia))))
                            dgvMes.Rows[fila].Cells[columna].Style.BackColor = Color.LightYellow;
                        else
                            dgvMes.Rows[fila].Cells[columna].Style.BackColor = Color.White;
                        // Conformamos la fecha
                        DateTime fecha = new DateTime(anno, mes, Convert.ToInt32(dia));
                        if(EsElDiaDehoy(fecha))
                            dgvMes.Rows[fila].Cells[columna].Style.BackColor = Color.Aqua;
                        // Almacenamos la fecha en la propiedad "Tag" de cada celda
                        dgvMes.Rows[fila].Cells[columna].Tag = fecha.ToString("dd/MM/yyyy");
                    }
                }
            }
        }

        private static bool EsElDiaDehoy(DateTime fecha)
        {
            DateTime fecha2 = DateTime.Now;

            if (fecha.Date == fecha2.Date)
                return true;
            return false;
        }

    }
}
