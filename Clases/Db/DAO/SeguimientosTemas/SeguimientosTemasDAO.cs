using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;
using TasksBook.Clases.Comunes;
using TasksBook.Clases.DTO;
using UtilesCs.Clases.Utilidades.AccessDb;
using UtilesCs.Clases.Utilidades.Db;

namespace TasksBook.Clases.DAO.SeguimientosTareas
{
    public class SeguimientosTareasDAO
    {

        public static List<SeguimientoTareaDTO> GetSeguimientosByIdTarea(int id)
        {

            List<SeguimientoTareaDTO> lista = new List<SeguimientoTareaDTO>();
            string sql = "";

            sql = "";
            sql += "SELECT *";
            sql += "  FROM SeguimientoTareas st, Tareas t";
            sql += " WHERE st.IdTarea = t.Id";
            sql += "   AND t.Id = " + id.ToString();
            sql += " ORDER BY Fecha";

            Globales.logger.WriteLog(sql);
            OleDbDataReader reader = UtilesDb.GetOleDbDataReader(Conexion.GetConexion(), sql);
            if (reader == null)
                return null;
            while (reader.Read())
            {
                SeguimientoTareaDTO dto = new SeguimientoTareaDTO();
                dto = ReaderToDTO(reader);
                lista.Add(dto);
            }
            reader.Close();

            return lista;

        }

        //public static TareaDTO GetTareaDTOById(int id)
        //{

        //    TareaDTO dto = new TareaDTO();
        //    string sql = "";

        //    sql = "";
        //    sql += "SELECT *";
        //    sql += "  FROM Proyectos p, Tareas t, EstadosTareas et";
        //    sql += " WHERE p.Id = t.IdProyecto";
        //    sql += "   AND t.IdEstadoTarea = et.Id";
        //    sql += "   AND t.Id = " + id.ToString();

        //    Globales.logger.WriteLog(sql);
        //    OleDbDataReader reader = UtilesDb.GetOleDbDataReader(Conexion.GetConexion(), sql);
        //    if (reader == null)
        //        return null;

        //    while (reader.Read())
        //    {
        //        dto = ReaderToDTO(reader);
        //    }
        //    reader.Close();

        //    return dto;
        //}

        private static SeguimientoTareaDTO ReaderToDTO(OleDbDataReader reader)
        {

            SeguimientoTareaDTO dto = new SeguimientoTareaDTO();

            dto.Id = reader.GetInt32(reader.GetOrdinal("st.Id"));
            dto.IdTarea = reader.GetInt32(reader.GetOrdinal("IdTarea"));
            dto.Fecha = OleDbUtiles.GetDatoAsString(reader, "Fecha");
            dto.Notas = OleDbUtiles.GetDatoAsString(reader, "Notas");
            dto.Etiquetas = OleDbUtiles.GetDatoAsString(reader, "Etiquetas");
            dto.AbreTarea = OleDbUtiles.GetDatoAsString(reader, "AbreTarea");
            return dto;

        }

        public static bool Insert(SeguimientoTareaDTO dto)
        {

            string sql = "";

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = Conexion.GetConexion();

            sql = "";
            sql += "INSERT INTO SeguimientoTareas (IdTarea, Fecha, Notas, Etiquetas, AbreTarea)";
            sql += "VALUES (" + dto.IdTarea.ToString() + ",";
            sql += "        " + UtilesAccessDb.GetFechaAccess(dto.Fecha.ToString()) + ",";
            sql += "       '" + dto.Notas + "',";
            sql += "       '" + dto.Etiquetas + "',";
            sql += "       '" + dto.AbreTarea + "')";

            Globales.logger.WriteLog(sql);

            UtilesDb.EjecutaQuery(Conexion.GetConexion(), sql, true);

            return true;

        }

        public static bool Update(SeguimientoTareaDTO dto)
        {

            string sql = "";

            sql = "";
            sql += "UPDATE SeguimientoTareas ";
            sql += "   SET Fecha = " + UtilesAccessDb.GetFechaAccess(dto.Fecha) + ", ";
            sql += "       Notas = '" + dto.Notas + "', ";
            sql += "       Etiquetas = '" + dto.Etiquetas + "', ";
            sql += "       AbreTarea = '" + dto.AbreTarea + "' ";
            sql += " WHERE Id = " + dto.Id;

            Globales.logger.WriteLog(sql);

            UtilesDb.EjecutaQuery(Conexion.GetConexion(), sql, true);

            return true;

        }

        public static bool UpdateRtf(int id, RichTextBox rtb)
        {
            string sql = "";

            Globales.logger.WriteLog(sql);

            return true;

        }


    }
}
