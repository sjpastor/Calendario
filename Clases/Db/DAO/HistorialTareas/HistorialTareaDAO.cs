
using Cuadernotas.Clases.Comunes;
using Cuadernotas.Clases.Db;
using Cuadernotas.Clases.DTO.HistorialTareas;
using System.Collections.Generic;
using System.Data.OleDb;
using UtilesCs.Clases.Utilidades.AccessDb;
using UtilesCs.Clases.Utilidades.Db;

namespace Cuadernotas.Clases.DAO.HistorialTareas
{
    public class HistorialTareaDAO
    {


        public static List<HistorialTareaDTO> GetHistorialTarea(int idTarea)
        {

            List<HistorialTareaDTO> listado = new List<HistorialTareaDTO>();
            HistorialTareaDTO dto = new HistorialTareaDTO();

            string sql;

            sql = "";
            sql += "SELECT * ";
            sql += "  FROM HistorialTareas";
            sql += " WHERE idTarea = " + idTarea.ToString();

            Globales.logger.WriteLog(sql);
            OleDbDataReader reader = UtilesDb.GetOleDbDataReader(Conexion.GetConexion(), sql);
            if (reader == null)
                return null;

            while (reader.Read())
            {
                dto = new HistorialTareaDTO();
                dto.Id = OleDbUtiles.GetIntFromReader(reader, "Id", 0);
                dto.IdTarea = OleDbUtiles.GetIntFromReader(reader, "IdTarea", 0);
                dto.Fecha = OleDbUtiles.GetDatoAsString(reader, "Fecha", "");
                dto.Notas = OleDbUtiles.GetDatoAsString(reader, "Notas", "");
                listado.Add(dto);
            }
            reader.Close();

            return listado;

        }

        public static bool Guardar(HistorialTareaDTO historialTareaDto)
        {

            if (historialTareaDto.Id == 0)
                return Insertar(historialTareaDto);
            else
                return Actualizar(historialTareaDto);

        }

        private static bool Insertar(HistorialTareaDTO historialTareaDto)
        {

            string sql;

            sql = "";
            sql += "INSERT INTO HistorialTareas (IdTarea, Fecha, Notas)";
            sql += " VALUES (" + historialTareaDto.IdTarea.ToString() + ",";
            sql += "         " + UtilesAccessDb.GetFechaAccess(historialTareaDto.Fecha) + ", ";
            sql += "        '" + historialTareaDto.Notas + "')";

            Globales.logger.WriteLog(sql);

            return UtilesDb.EjecutaQuery(Conexion.GetConexion(), sql, true);

        }

        private static bool Actualizar(HistorialTareaDTO historialTareaDto)
        {
            string sql;

            sql = "";
            sql += "UPDATE HistorialTareas";
            sql += "   SET IdTarea = " + historialTareaDto.IdTarea.ToString() + ",";
            sql += "       Fecha = " + UtilesAccessDb.GetFechaAccess(historialTareaDto.Fecha) + ", ";
            sql += "       Notas = '" + historialTareaDto.Notas + "'";
            sql += "  WHERE Id = " + historialTareaDto.Id.ToString();

            Globales.logger.WriteLog(sql);

            return UtilesDb.EjecutaQuery(Conexion.GetConexion(), sql, true);

        }

        public static bool Eliminar(HistorialTareaDTO historialTareaDto)
        {
            string sql;

            sql = "";
            sql += "DELETE FROM HistorialTareas";
            sql += "  WHERE Id = " + historialTareaDto.Id.ToString();

            Globales.logger.WriteLog(sql);

            return UtilesDb.EjecutaQuery(Conexion.GetConexion(), sql, true);

        }

    }
}
