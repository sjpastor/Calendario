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
            sql += "  FROM Seguimientos s, Tareas t";
            sql += " WHERE s.IdTarea = t.Id";
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

            dto.Id = reader.GetInt32(reader.GetOrdinal("s.Id"));
            dto.IdTarea = reader.GetInt32(reader.GetOrdinal("IdTarea"));
            dto.Fecha = OleDbUtiles.GetDatoAsString(reader, "Fecha");
            //dto.Notas = OleDbUtiles.GetDatoAsString(reader, "Notas");

            return dto;

        }

        public static bool Insert(TareaDTO dto)
        {

            string sql = "";

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = Conexion.GetConexion();

            sql = "";
            sql += "INSERT INTO Tareas (IdProyecto, FApertura, Tarea, Descripcion, FHito, IdEstadoTarea, FCierre)";
            sql += "VALUES (" + dto.IdProyecto.ToString() + ",";
            sql += "        " + UtilesAccessDb.GetFechaAccess(dto.FApertura.ToString()) + ",";
            sql += "       '" + dto.Tarea + "',";
            sql += "       '" + dto.Descripcion + "',";
            sql += "        " + UtilesAccessDb.GetFechaAccess(dto.FHito.ToString()) + ",";
            sql += "        " + dto.IdEstadoTarea.ToString() + ",";
            //sql += "        " + UtilesAccessDb.GetFechaAccess(dto.FCierre.ToString()) + ")";

            Globales.logger.WriteLog(sql);

            UtilesDb.EjecutaQuery(Conexion.GetConexion(), sql, true);

            return true;

        }

        public static bool Update(TareaDTO dto)
        {

            string sql = "";

            sql = "";
            sql += "UPDATE Tareas ";
            sql += "   SET IdProyecto = " + dto.IdProyecto.ToString() + ", ";
            sql += "       FApertura = " + UtilesAccessDb.GetFechaAccess(dto.FApertura) + ", ";
            sql += "       Tarea = '" + dto.Tarea + "', ";
            sql += "       Descripcion = '" + dto.Descripcion + "', ";
            sql += "       FHito = " + UtilesAccessDb.GetFechaAccess(dto.FHito) + ", ";
            sql += "       IdEstadoTarea = " + dto.IdEstadoTarea.ToString() + ", ";
            //sql += "       FCierre = " + UtilesAccessDb.GetFechaAccess(dto.FCierre) + " ";
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
