using System.Collections.Generic;
using System.Data.OleDb;
using UtilesCs.Clases.Utilidades.Db;
using System.Windows.Forms;
using UtilesCs.Clases.Utilidades.AccessDb;
using System.Reflection;
using UtilesCs.Clases.Utilidades.Numeros;
using TasksBook.Clases.DTO.Tareas;
using TasksBook.Clases.Comunes;
using TasksBook.Clases.DAO.EstadosTareas;
using System;

namespace TasksBook.Clases.DAO.Tareas
{
    public class TareasDAO
    {

        public static List<TareaDTO> GetAllTareas(string proyecto="", bool mostrarTerminadas = true)
        {

            List<TareaDTO> lista = new List<TareaDTO>();
            string sql = "";

            sql = "";
            sql += "SELECT *";
            sql += "  FROM Proyectos p, Tareas t, EstadosTareas et";
            sql += " WHERE p.Id = t.IdProyecto";
            sql += "   AND t.IdEstadoTarea = et.Id";
            if (!proyecto.Equals(""))
                sql += " AND proyecto = '" + proyecto + "'";
            if (!mostrarTerminadas)
                sql += " AND t.IdEstadoTarea <> 4 AND t.IdEstadoTarea <> 7";
            sql += " ORDER BY Orden, Suborden, PosicionTop, Tarea";

            Globales.logger.WriteLog(sql);
            OleDbDataReader reader = UtilesDb.GetOleDbDataReader(Conexion.GetConexion(), sql);
            if (reader == null)
                return null;
            while (reader.Read())
            {
                TareaDTO dto = new TareaDTO();
                dto = ReaderToDTO(reader);
                lista.Add(dto);
            }
            reader.Close();

            return lista;

        }

        public static TareaDTO GetTareaDTOById(int id)
        {

            TareaDTO dto = new TareaDTO();
            string sql = "";

            sql = "";
            sql += "SELECT *";
            sql += "  FROM Proyectos p, Tareas t, EstadosTareas et";
            sql += " WHERE p.Id = t.IdProyecto";
            sql += "   AND t.IdEstadoTarea = et.Id";
            sql += "   AND t.Id = " + id.ToString();

            Globales.logger.WriteLog(sql);
            OleDbDataReader reader = UtilesDb.GetOleDbDataReader(Conexion.GetConexion(), sql);
            if (reader == null)
                return null;

            while (reader.Read())
            {
                dto = ReaderToDTO(reader);
            }
            reader.Close();

            return dto;
        }

        public static bool ReordenarTareas(int idFijo = 0, int ordenFijo = 0)
        {

            RevisarTareasByOrdenSubtarea();

            ReordenarTareasFinal(idFijo, ordenFijo);

            return true;

        }

        // Recorremos las tareas proyecto a proyecto y si el orden de una subtarea es menor que el de otra del mismo proyecto, el orden debe ser también menor, si no, se cambia.
        private static bool RevisarTareasByOrdenSubtarea()
        {

            string sql = "";

            sql = "";
            sql += "SELECT DISTINCT(IdProyecto) as DIdProyecto";
            sql += "  FROM Tareas ";
            sql += " WHERE (IdEstadoTarea <> 4  AND IdEstadoTarea <> 7)";

            Globales.logger.WriteLog(sql);
            OleDbDataReader reader = UtilesDb.GetOleDbDataReader(Conexion.GetConexion(), sql);
            if (reader == null)
                return false;

            while (reader.Read())
            {
                RevisarTareasByOrdenSubtareaByIdProyecto(OleDbUtiles.GetIntFromReader(reader, "DIdProyecto", 0));
            }

            reader.Close();

            return true;

        }

        // Recorremos las tareas de un proyecto revisando orden y suborden.
        private static bool RevisarTareasByOrdenSubtareaByIdProyecto(int id)
        {

            string sql = "";
            int idTarea = 0;
            int orden = 0;
            int suborden = 0;
            int ordenAnterior = 0;
            bool modificadoOrden = true;

            sql = "";
            sql += "SELECT Id, Orden ";
            sql += "  FROM Tareas ";
            sql += " WHERE (IdEstadoTarea <> 4  AND IdEstadoTarea <> 7)";
            sql += "   AND IdProyecto = " + id.ToString();
            sql += " ORDER BY Suborden";

            Globales.logger.WriteLog(sql);
            OleDbDataReader reader = UtilesDb.GetOleDbDataReader(Conexion.GetConexion(), sql);
            if (reader == null)
                return false;

            while (modificadoOrden)
            {
                modificadoOrden = false;
                suborden = 0;
                while (reader.Read())
                {
                    idTarea = OleDbUtiles.GetIntFromReader(reader, "Id", 0);
                    orden = OleDbUtiles.GetIntFromReader(reader, "Orden", 0);
                    suborden++;
                    TareaDTO dto = TareasDAO.GetTareaDTOById(idTarea);
                    if (orden < ordenAnterior)
                    {
                        orden = ordenAnterior;
                        ordenAnterior = orden;
                        modificadoOrden=true;
                    }
                    dto.Orden = orden;
                    dto.Suborden = suborden;
                    TareasDAO.Update(dto, false);
                    ordenAnterior = orden;
                }
                Application.DoEvents();
            }

            reader.Close();

            return true;

        }

        private static bool ReordenarTareasFinal(int idFijo = 0, int ordenFijo = 0) 
        { 


            string sql = "";
            int orden = 0;
            List<int> IDs = new List<int>();
            bool actualizar = false;

            sql = "";
            sql += "SELECT Id";
            sql += "  FROM Tareas ";
            sql += " WHERE (IdEstadoTarea <> 4  AND IdEstadoTarea <> 7)";
            sql += " ORDER BY Orden, Suborden, PosicionTop ";

            Globales.logger.WriteLog(sql);
            OleDbDataReader reader = UtilesDb.GetOleDbDataReader(Conexion.GetConexion(), sql);
            if (reader == null)
                return false;

            // Cargamos los IDs en una lista
            while (reader.Read())
            {
                IDs.Add(reader.GetInt32(0));
            }

            reader.Close();

            // Actualizamos los IDs
            foreach (int id in IDs) { 

                orden++;
                actualizar = true;

                if (orden == ordenFijo && id != idFijo)
                    orden++;
                else if (orden == ordenFijo && id == idFijo)
                {
                    actualizar = false;
                }

                sql = "";
                sql += "UPDATE Tareas SET Orden = " + orden.ToString();
                sql += " WHERE Id = " +id.ToString();
                Globales.logger.WriteLog(sql);
                UtilesDb.EjecutaQuery(Conexion.GetConexion(), sql, true);

            }

            return true;


        }

        public static bool ReordenarTop(int topTop, int distanciaEntreTops)
        {

            TareaDTO dto = new TareaDTO();
            string sql = "";
            int top = -1;

            sql = "";
            sql += "SELECT Id, PosicionTop";
            sql += "  FROM Tareas ";
            sql += " ORDER BY PosicionTop";

            Globales.logger.WriteLog(sql);
            OleDbDataReader reader = UtilesDb.GetOleDbDataReader(Conexion.GetConexion(), sql);
            if (reader == null)
                return false;

            while (reader.Read())
            {
                if (top == -1)
                    top = topTop;
                else
                    top += distanciaEntreTops;

                sql = "";
                sql += "UPDATE Tareas SET PosicionTop = " + top.ToString();
                sql += " WHERE Id = " + OleDbUtiles.GetIntFromReader(reader, "Id");

                UtilesDb.EjecutaQuery(Conexion.GetConexion(), sql, true);

            }
            reader.Close();

            return true;

        }

        private static TareaDTO ReaderToDTO(OleDbDataReader reader)
        {

            TareaDTO dto = new TareaDTO();
            string posicion = "";

            dto.Id = reader.GetInt32(reader.GetOrdinal("t.Id"));
            dto.IdProyecto = reader.GetInt32(reader.GetOrdinal("IdProyecto"));
            dto.Proyecto = OleDbUtiles.GetDatoAsString(reader, "Proyecto");
            dto.FApertura = OleDbUtiles.GetDatoAsString(reader, "FApertura");
            posicion = OleDbUtiles.GetDatoAsString(reader, "PosicionTop", "");
            if (posicion == null)
                posicion = "99";
            else if (posicion.Equals(""))
                posicion = "99";
            dto.PosicionTop = Convert.ToInt32(posicion);
            dto.Orden = reader.GetInt32(reader.GetOrdinal("Orden"));
            dto.Suborden = OleDbUtiles.GetIntFromReader(reader, "Suborden", 0);
            dto.Tarea = OleDbUtiles.GetDatoAsString(reader, "Tarea");
            dto.Descripcion = OleDbUtiles.GetDatoAsString(reader, "t.Descripcion");
            dto.FHito = OleDbUtiles.GetDatoAsString(reader, "FHito");
            dto.IdEstadoTarea = reader.GetInt32(reader.GetOrdinal("IdEstadoTarea"));
            dto.EstadoTarea = EstadosTareasDAO.GetEstadoById(dto.IdEstadoTarea);
            dto.FCierre = OleDbUtiles.GetDatoAsString(reader, "FCierre");

            return dto;

        }

        public static bool Insert(TareaDTO dto)
        {

            string sql = "";
            string fApertura = DateTime.Now.ToString("dd/MM/yyyy");

            if (dto.FApertura != null)
                fApertura = dto.FApertura;

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = Conexion.GetConexion();

            sql  = "";
            sql += "INSERT INTO Tareas (IdProyecto, FApertura, Tarea, PosicionTop, Orden, Suborden, Descripcion, FHito, IdEstadoTarea, FCierre)";
            sql += "VALUES (" + dto.IdProyecto.ToString() + ",";
            sql += "        " + UtilesAccessDb.GetFechaAccess(fApertura) + ",";
            sql += "       '" + dto.Tarea + "',";
            sql += "        " + dto.PosicionTop.ToString() + ",";
            sql += "        " + dto.Orden.ToString() + ",";
            sql += "        " + dto.Suborden.ToString() + ",";
            sql += "       '" + dto.Descripcion + "',";
            sql += "        " + UtilesAccessDb.GetFechaAccess(dto.FHito.ToString()) + ",";
            sql += "        " + dto.IdEstadoTarea.ToString() + ",";
            if (dto.FCierre == null)
                sql += "        NULL) ";
            else
                sql += "        " + UtilesAccessDb.GetFechaAccess(dto.FCierre.ToString()) + ")";

            Globales.logger.WriteLog(sql);

            UtilesDb.EjecutaQuery(Conexion.GetConexion(), sql, true);

            int id = Convert.ToInt32(UtilesDb.GetMaxId(Conexion.GetConexion(), "Tareas"));

            ReordenarTareas(id, dto.Orden);

            return true;

        }

        public static bool Update(TareaDTO dto, bool reordenar=true)
        {

            string sql = "";

            sql = "";
            sql += "UPDATE Tareas ";
            sql += "   SET IdProyecto = " + dto.IdProyecto.ToString() + ", ";
            sql += "       FApertura = " + UtilesAccessDb.GetFechaAccess(dto.FApertura) + ", ";
            sql += "       Tarea = '" + dto.Tarea + "', ";
            sql += "       PosicionTop = " + dto.PosicionTop.ToString() + ", ";
            sql += "       Orden = " + dto.Orden.ToString() + ", ";
            sql += "       Suborden = " + dto.Suborden.ToString() + ", ";
            sql += "       Descripcion = '" + dto.Descripcion + "', ";
            sql += "       FHito = " + UtilesAccessDb.GetFechaAccess(dto.FHito) + ", ";
            sql += "       IdEstadoTarea = " + dto.IdEstadoTarea.ToString() + ", ";
            sql += "       FCierre = " + UtilesAccessDb.GetFechaAccess(dto.FCierre) + " ";
            sql += " WHERE Id = " + dto.Id;

            Globales.logger.WriteLog(sql);

            UtilesDb.EjecutaQuery(Conexion.GetConexion(), sql, true);

            if(reordenar)
                ReordenarTareas(dto.Id, dto.Orden);

            return true;

        }


    }
}
