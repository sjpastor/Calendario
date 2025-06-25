using System.Collections.Generic;
using System.Data.OleDb;
using UtilesCs.Clases.Utilidades.Db;
using System.Windows.Forms;
using UtilesCs.Clases.Utilidades.AccessDb;
using TasksBook.Clases.DTO;
using TasksBook.Clases.Comunes;
using TasksBook.Clases.DAO.EstadosTareas;
using System;
using TasksBook.Clases.DAO.Responsables;

namespace TasksBook.Clases.DAO.Actividades
{
    public class ActividadesDAO
    {

        public static List<ActividadDTO> GetAllTemas(string proyecto="", string palabras = "", bool mostrarTerminadas = true)
        {

            List<ActividadDTO> lista = new List<ActividadDTO>();
            string sql = "";

            sql = "";
            sql += "SELECT *";
            sql += "  FROM Plataformas pt, Proyectos p, Temas t, EstadosTemas et";
            sql += " WHERE pt.Id = p.IdPlataforma";
            sql += "   AND p.Id = t.IdProyecto";
            sql += "   AND t.IdEstadoTema = et.Id";
            if (!proyecto.Equals(""))
                sql += " AND proyecto = '" + proyecto + "'";
            if (!mostrarTerminadas)
                sql += " AND t.F <> 4 AND t.IdEstadoTema <> 5";
            sql += " ORDER BY Proyecto, Tema";

            Globales.logger.WriteLog(sql);
            OleDbDataReader reader = UtilesDb.GetOleDbDataReader(Conexion.GetConexion(), sql);
            if (reader == null)
                return null;
            while (reader.Read())
            {
                ActividadDTO dto = new ActividadDTO();
                dto = ReaderToDTO(reader);
                lista.Add(dto);
            }
            reader.Close();

            return lista;

        }

        public static ActividadDTO GetTemaDTOById(int id)
        {

            ActividadDTO dto = new ActividadDTO();
            string sql = "";

            sql = "";
            sql += "SELECT *";
            sql += "  FROM Proyectos p, Temas t, EstadosTareas et";
            sql += " WHERE p.Id = t.IdProyecto";
            sql += "   AND t.IdEstadoTema = et.Id";
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

        //public static bool ReordenarTareas(int idFijo = 0, int ordenFijo = 0)
        //{

        //    RevisarTareasByOrdenSubtarea();

        //    ReordenarTareasFinal(idFijo, ordenFijo);

        //    return true;

        //}

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
                    ActividadDTO dto = ActividadesDAO.GetTemaDTOById(idTarea);
                    if (orden < ordenAnterior)
                    {
                        orden = ordenAnterior;
                        ordenAnterior = orden;
                        modificadoOrden=true;
                    }
                    ActividadesDAO.Update(dto, false);
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

            ActividadDTO dto = new ActividadDTO();
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

        private static ActividadDTO ReaderToDTO(OleDbDataReader reader)
        {

            ActividadDTO dto = new ActividadDTO();

            dto.Id = reader.GetInt32(reader.GetOrdinal("t.Id"));
            dto.IdPlataforma = reader.GetInt32(reader.GetOrdinal("IdPlataforma"));
            dto.Plataforma = OleDbUtiles.GetDatoAsString(reader, "Plataforma");
            dto.IdProyecto = reader.GetInt32(reader.GetOrdinal("IdProyecto"));
            dto.CodProyecto = OleDbUtiles.GetDatoAsString(reader, "CodProyecto");
            dto.Proyecto = OleDbUtiles.GetDatoAsString(reader, "Proyecto");
            dto.FApertura = OleDbUtiles.GetDatoAsString(reader, "FApertura");
            dto.Tema = OleDbUtiles.GetDatoAsString(reader, "Tema");
            dto.Descripcion = OleDbUtiles.GetDatoAsString(reader, "Descripcion");
            dto.Etiquetas = OleDbUtiles.GetDatoAsString(reader, "Etiquetas");
            dto.FHito = OleDbUtiles.GetDatoAsString(reader, "FHito");
            dto.IdResponsable = reader.GetInt32(reader.GetOrdinal("IdResponsable"));
            dto.Responsable = ResponsablesDAO.GetResponsableById(dto.IdResponsable);
            dto.IdEstadoTema = reader.GetInt32(reader.GetOrdinal("IdEstadoTema"));
            dto.EstadoTema = EstadosTemasDAO.GetEstadoById(dto.IdEstadoTema);
            dto.FFinalizado = OleDbUtiles.GetDatoAsString(reader, "FFinalizado");

            return dto;

        }

        public static bool Insert(ActividadDTO dto)
        {

            string sql = "";
            string fApertura = DateTime.Now.ToString("dd/MM/yyyy");

            if (dto.FApertura != null)
                fApertura = dto.FApertura;

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = Conexion.GetConexion();

            sql  = "";
            sql += "INSERT INTO Temas (IdProyecto, FApertura, Tema, Descripcion, Etiquetas, IdResponsable, IdEstadoTema, FHito, FFinalizado)";
            sql += "VALUES (" + dto.IdProyecto.ToString() + ",";
            sql += "        " + UtilesAccessDb.GetFechaAccess(fApertura) + ",";
            sql += "       '" + dto.Tema + "',";
            sql += "       '" + dto.Descripcion + "',";
            sql += "       '" + dto.Etiquetas + "',";
            sql += "        " + dto.IdResponsable.ToString() + ",";
            sql += "        " + dto.IdEstadoTema.ToString() + ",";
            sql += "        " + UtilesAccessDb.GetFechaAccess(dto.FHito.ToString()) + ",";
            sql += "        " + UtilesAccessDb.GetFechaAccess(dto.FFinalizado.ToString()) + ")";
            //if (dto.FFinalizado == null)
            //    sql += "        NULL) ";
            //else
            //    sql += "        " + UtilesAccessDb.GetFechaAccess(dto.FFinalizado.ToString()) + ")";

            Globales.logger.WriteLog(sql);

            UtilesDb.EjecutaQuery(Conexion.GetConexion(), sql, true);

            //int id = Convert.ToInt32(UtilesDb.GetMaxId(Conexion.GetConexion(), "Tareas"));

            return true;

        }

        public static bool Update(ActividadDTO dto, bool reordenar=true)
        {

            string sql = "";

            sql = "";
            sql += "UPDATE Temas ";
            sql += "   SET IdProyecto = " + dto.IdProyecto.ToString() + ", ";
            sql += "       FApertura = " + UtilesAccessDb.GetFechaAccess(dto.FApertura) + ", ";
            sql += "       Tema = '" + dto.Tema + "', ";
            sql += "       Descripcion = '" + dto.Descripcion + "', ";
            sql += "       Etiquetas = '" + dto.Etiquetas + "', ";
            sql += "       FHito = " + UtilesAccessDb.GetFechaAccess(dto.FHito) + ", ";
            sql += "       IdResponsable = " + dto.IdResponsable.ToString() + ", ";
            sql += "       IdEstadoTema = " + dto.IdEstadoTema.ToString() + ", ";
            sql += "       FFinalizado = " + UtilesAccessDb.GetFechaAccess(dto.FFinalizado) + " ";
            sql += " WHERE Id = " + dto.Id;

            Globales.logger.WriteLog(sql);

            UtilesDb.EjecutaQuery(Conexion.GetConexion(), sql, true);

            return true;

        }


    }
}
