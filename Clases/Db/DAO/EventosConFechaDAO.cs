using Calendario.Clases.Db.DTO;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using TasksBook.Clases.Db;
using UtilesCs.Clases.Utilidades.Db;

namespace Calendario.Clases.Db.DAO
{
    public class EventosConFechaDAO
    {
        public static List<EventoConFechaDTO> GetAllEventos(string texto, string proyecto, string subproyecto, bool ocultarTerminadas)
        {

            string sql;
            List<EventoConFechaDTO> listado = new List<EventoConFechaDTO>();

            string[] palabras = texto.Split(',');

            sql = "";
            sql += "SELECT * ";
            sql += "  FROM EventosConFecha ";
            sql += " ORDER BY fecha, hora";
            //if (ocultarTerminadas)
            //{
            //    sql += OleDbUtiles.SqlWhereAnd(sql) + "  IdSituacion <> " + Globales.ID_TAREA_TERMINADA.ToString();
            //}
            //if (palabras.Length > 0 & !palabras[0].Equals(""))
            //{
            //    sql += OleDbUtiles.SqlWhereAnd(sql) + "(";
            //    foreach (string palabra in palabras)
            //    {
            //        sql += " TareaDetalles Like '%" + palabra.Trim() + "%' OR";
            //    }
            //    sql = sql.Substring(0, sql.Length - 3);
            //    sql += ")";
            //}

            Comun.logger.WriteLog(sql);
            OleDbDataReader reader = UtilesDb.GetOleDbDataReader(Conexion.GetConexion(), sql);
            if (reader == null)
                return null;

            if (!reader.HasRows)
                return null;

            while (reader.Read())
            {
                EventoConFechaDTO dto = ReaderToDTO(reader);
                listado.Add(dto);
            }
            reader.Close();

            return listado;

        }

        private static EventoConFechaDTO ReaderToDTO(OleDbDataReader reader)
        {

            EventoConFechaDTO eventoConFechaDTO = new EventoConFechaDTO();
            eventoConFechaDTO.Id = OleDbUtiles.GetIntFromReader(reader, "Id");
            eventoConFechaDTO.Fecha = Convert.ToDateTime(OleDbUtiles.GetStringFromReader(reader, "Fecha")).ToString("dd/MM/yyyy");
            eventoConFechaDTO.Hora = Convert.ToDateTime(OleDbUtiles.GetStringFromReader(reader, "Hora")).ToString("HH:mm");
            eventoConFechaDTO.Evento = OleDbUtiles.GetStringFromReader(reader, "Evento");
            eventoConFechaDTO.Comentarios = OleDbUtiles.GetStringFromReader(reader, "Comentarios");
            eventoConFechaDTO.Pendiente = OleDbUtiles.GetStringFromReader(reader, "Pendiente");

            return eventoConFechaDTO;
        }

    }
}
