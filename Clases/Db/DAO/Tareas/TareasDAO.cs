using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Reflection;
using System.Windows.Forms;
using TasksBook.Clases.Comunes;
using TasksBook.Clases.Comunes.Rendimiento;
using TasksBook.Clases.DAO.Notas;
using TasksBook.Clases.DAO.Prioridades;
using TasksBook.Clases.DAO.Proyectos;
using TasksBook.Clases.DAO.Subproyectos;
using TasksBook.Clases.DAO.Tipos;
using TasksBook.Clases.Db;
using TasksBook.Clases.DTO.Notas;
using TasksBook.Clases.DTO.Tareas;
using UtilesCs.Clases.Utilidades.AccessDb;
using UtilesCs.Clases.Utilidades.Db;

namespace TasksBook.Clases.DAO.Tareas
{
    public class TareasDAO
    {
        public static List<TareaDTO> GetAllTareas(string texto, string proyecto, string subproyecto, bool ocultarTerminadas)
        {

            Logger.Entrando(MethodBase.GetCurrentMethod().Name);

            string sql;
            List<TareaDTO> listado = new List<TareaDTO>();

            string[] palabras = texto.Split(',');

            sql = "";
            sql += "SELECT * ";
            sql += "  FROM Tareas ";
            //sql += " WHERE p.Id = sp.IdProyecto";
            //sql += "   AND sp.Id = t.IdSubproyecto";

            //if (!proyecto.Equals(""))
            //{
            //    sql += " AND p.Id = " + ProyectosDAO.GetIdProyectoByProyecto(proyecto).ToString() + " ";
            //}
            //if (!subproyecto.Equals(""))
            //{
            //    sql += " AND sp.Id = " + SubproyectosDAO.GetIdSubproyectoBySubproyecto(subproyecto).ToString() + " ";
            //}
            if (ocultarTerminadas)
            {
                sql += OleDbUtiles.SqlWhereAnd(sql) + "  IdSituacion <> " + Globales.ID_TAREA_TERMINADA.ToString();
            }
            if (palabras.Length > 0 & !palabras[0].Equals(""))
            {
                sql += OleDbUtiles.SqlWhereAnd(sql) + "(";
                foreach (string palabra in palabras)
                {
                    sql += " TareaDetalles Like '%" + palabra.Trim() + "%' OR";
                }
                sql = sql.Substring(0, sql.Length - 3);
                sql += ")";
            }
            sql += " ORDER BY Orden";

            Globales.logger.WriteLog(sql);
            OleDbDataReader reader = UtilesDb.GetOleDbDataReader(Conexion.GetConexion(), sql);
            if (reader == null)
                return null;

            if (!reader.HasRows)
                return null;

            while (reader.Read())
            {
                TareaDTO dto = ReaderToDTO(reader);
                listado.Add(dto);
            }
            reader.Close();

            Logger.Saliendo(MethodBase.GetCurrentMethod().Name);

            return listado;

        }

        public static TareaDTO GetTareaDTOById(int id)
        {

            Logger.Entrando(MethodBase.GetCurrentMethod().Name);

            string sql;
            TareaDTO tareaDto = new TareaDTO();

            sql = "";
            sql += "SELECT * ";
            sql += "  FROM Tareas ";
            sql += " WHERE Id = " + id.ToString() + " ";

            Globales.logger.WriteLog(sql);
            OleDbDataReader reader = UtilesDb.GetOleDbDataReader(Conexion.GetConexion(), sql);
            if (reader == null)
                return null;

            if (!reader.HasRows)
                return null;

            while (reader.Read())
            {
                tareaDto = ReaderToDTO(reader);
            }
            reader.Close();

            Logger.Saliendo(MethodBase.GetCurrentMethod().Name);

            return tareaDto;

        }

        public static bool GuardarTareaDetalles(int id, string notas)
        {
            Logger.Entrando(MethodBase.GetCurrentMethod().Name);

            string sql = "";
            bool retorno;

            sql = "";
            sql += "UPDATE Tareas";
            sql += "   SET TareaDetalles = '" + notas + "'";
            sql += " WHERE Id = " + id.ToString();

            Console.WriteLine(sql);

            try
            {
                UtilesDb.EjecutaQuery(Conexion.GetConexion(), sql, true);
                retorno = true;
            }
            catch (Exception ex)
            {
                Globales.logger.WriteLog(ex.Message);
                MessageBox.Show(ex.Message);
                retorno = false;
            }

            Logger.Saliendo(MethodBase.GetCurrentMethod().Name);

            return retorno;
        }

        public static bool Guardar(TareaDTO dto, bool actualizarUltimaModificacion = true)
        {
            if (dto.Id == 0)
                return Insertar(dto);
            else
            {
                if (Update(dto, actualizarUltimaModificacion))
                {
                    if (dto.Situacion.Equals(Globales.ID_TAREA_TERMINADA.ToString()) && MessageBox.Show("¿Desea almacenar las notas de esta tarea en 'Notas'?", "Atención", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        NotaDTO notaDto = new NotaDTO();
                        notaDto.IdProyecto = dto.IdProyecto;
                        notaDto.IdSubproyecto = dto.IdSubproyecto;
                        notaDto.Tema = dto.Tema;
                        notaDto.Notas = Convert.ToDateTime(dto.Fecha).ToString("dd/MM/yyyy") + "\r\n";
                        notaDto.Notas += dto.Tarea + "\r\n";
                        notaDto.Notas += dto.TareaDetalles;
                        NotasDAO.Guardar(notaDto);
                    }
                }
                return true;
            }
        }

        private static bool Insertar(TareaDTO dato)
        {
            Logger.Entrando(MethodBase.GetCurrentMethod().Name);

            bool retorno;
            string sql = "";

            sql = "";
            sql += "INSERT INTO Tareas (Orden, Fecha, IdProyecto, IdSubproyecto, Tema, Tarea, TareaDetalles, IdSituacion, IdTipo, Recordar, IdPrioridad, UltModificacion)";
            sql += " VALUES (" + dato.Orden.ToString() + ",";
            sql += "         " + UtilesAccessDb.GetFechaAccess(dato.Fecha) + ",";
            sql += "         " + dato.IdProyecto.ToString() + ",";
            sql += "         " + dato.IdSubproyecto.ToString() + ",";
            sql += "        '" + dato.Tema + "',";
            sql += "        '" + dato.Tarea + "',";
            sql += "        '" + dato.TareaDetalles + "',";
            sql += "         " + dato.IdSituacion.ToString() + ",";
            sql += "         " + dato.IdTipo.ToString() + ",";
            sql += "         " + UtilesAccessDb.GetFechaAccess(dato.Recordar) + ",";
            sql += "         " + dato.IdPrioridad.ToString() + ",";
            sql += "        #" + DateTime.Now.ToString("MM/dd/yyyy") + "#)";

            Console.WriteLine(sql);

            try
            {
                UtilesDb.EjecutaQuery(Conexion.GetConexion(), sql, true);
                retorno = true;
            }
            catch (Exception ex)
            {
                Globales.logger.WriteLog(ex.Message);
                MessageBox.Show(ex.Message);
                retorno = false;
            }

            Logger.Saliendo(MethodBase.GetCurrentMethod().Name);

            return retorno;

        }

        private static bool Update(TareaDTO dato, bool actualizarUltimaModificacion = true)
        {

            Logger.Entrando(MethodBase.GetCurrentMethod().Name);

            bool retorno;
            string sql = "";

            sql = "";
            sql += "UPDATE Tareas";
            sql += "   SET Orden = " + dato.Orden + ",";
            sql += "       Fecha = " + UtilesAccessDb.GetFechaAccess(dato.Fecha) + ",";
            sql += "       IdProyecto = " + dato.IdProyecto + ",";
            sql += "       IdSubproyecto = " + dato.IdSubproyecto + ",";
            sql += "       Tema = '" + dato.Tema + "',";
            sql += "       Tarea = '" + dato.Tarea + "',";
            sql += "       TareaDetalles = '" + dato.TareaDetalles + "',";
            sql += "       IdSituacion = " + dato.IdSituacion + ", ";
            sql += "       IdTipo = " + dato.IdTipo + ", ";
            if (dato.IdSituacion == Globales.ID_TAREA_TERMINADA)
                sql += "       Recordar = NULL,";
            else
                sql += "       Recordar = " + UtilesAccessDb.GetFechaAccess(dato.Recordar) + ",";
            if (actualizarUltimaModificacion)
                sql += "       UltModificacion = #" + DateTime.Now.ToString("MM/dd/yyyy") + "#, ";
            sql += "       IdPrioridad = " + dato.IdPrioridad + " ";
            sql += " WHERE Id = " + dato.Id.ToString();

            Console.WriteLine(sql);

            try
            {
                UtilesDb.EjecutaQuery(Conexion.GetConexion(), sql, true);
                retorno = true;
            }
            catch (Exception ex)
            {
                Globales.logger.WriteLog(ex.Message);
                MessageBox.Show(ex.Message);
                retorno = false;
            }

            Logger.Saliendo(MethodBase.GetCurrentMethod().Name);

            return retorno;

        }

        public static void Reordenar()
        {

            Logger.Entrando(MethodBase.GetCurrentMethod().Name);

            TareaDTO tareaDto = new TareaDTO();

            string sql = "";
            int orden = 1;

            sql = "";
            sql += "SELECT * ";
            sql += "  FROM Tareas ";
            sql += " WHERE IdSituacion <> " + Globales.ID_TAREA_TERMINADA.ToString();
            sql += " ORDER BY Orden, Fecha";

            Globales.logger.WriteLog(sql);
            OleDbDataReader reader = UtilesDb.GetOleDbDataReader(Conexion.GetConexion(), sql);
            if (reader == null)
                return;

            if (!reader.HasRows)
                return;

            while (reader.Read())
            {
                tareaDto = ReaderToDTO(reader);
                tareaDto.Orden = orden;
                Guardar(tareaDto, false);
                orden++;
            }
            reader.Close();

            Logger.Saliendo(MethodBase.GetCurrentMethod().Name);

            return;

        }

        public static bool DeleteTareaById(int id)
        {
            string sql = "";

            sql = "";
            sql += "DELETE FROM Tareas WHERE ID=" + id.ToString();

            Console.WriteLine(sql);

            try
            {
                UtilesDb.EjecutaQuery(Conexion.GetConexion(), sql, true);
                return true;
            }
            catch (Exception ex)
            {
                Globales.logger.WriteLog(ex.Message);
                MessageBox.Show(ex.Message);
                return false;
            }
        }


        private static TareaDTO ReaderToDTO(OleDbDataReader reader)
        {
            Logger.Entrando(MethodBase.GetCurrentMethod().Name);

            TareaDTO TareaDTO = new TareaDTO();
            TareaDTO.Id = OleDbUtiles.GetIntFromReader(reader, "Id");
            TareaDTO.Orden = OleDbUtiles.GetIntFromReader(reader, "Orden");
            TareaDTO.Fecha = OleDbUtiles.GetStringFromReader(reader, "Fecha");
            TareaDTO.IdProyecto = OleDbUtiles.GetIntFromReader(reader, "IdProyecto");
            TareaDTO.Proyecto = ProyectosDAO.GetProyectoById(TareaDTO.IdProyecto);
            TareaDTO.IdSubproyecto = OleDbUtiles.GetIntFromReader(reader, "IdSubproyecto");
            TareaDTO.Subproyecto = SubproyectosDAO.GetSubproyectoById(TareaDTO.IdSubproyecto);
            TareaDTO.Tema = OleDbUtiles.GetStringFromReader(reader, "Tema");
            TareaDTO.Tarea = OleDbUtiles.GetStringFromReader(reader, "Tarea");
            TareaDTO.IdSituacion = OleDbUtiles.GetIntFromReader(reader, "IdSituacion");
            TareaDTO.Situacion = SituacionesDAO.GetSituacionById(TareaDTO.IdSituacion);
            TareaDTO.IdTipo = OleDbUtiles.GetIntFromReader(reader, "IdTipo");
            TareaDTO.Tipo = TiposDAO.GetTipoById(TareaDTO.IdTipo);
            TareaDTO.Recordar = OleDbUtiles.GetStringFromReader(reader, "Recordar");
            TareaDTO.UltModificacion = OleDbUtiles.GetStringFromReader(reader, "UltModificacion");
            TareaDTO.TareaDetalles = OleDbUtiles.GetStringFromReader(reader, "TareaDetalles");
            TareaDTO.IdPrioridad = OleDbUtiles.GetIntFromReader(reader, "IdPrioridad");
            TareaDTO.Prioridad = PrioridadesDAO.GetPrioridadById(TareaDTO.IdPrioridad);

            Logger.Saliendo(MethodBase.GetCurrentMethod().Name);

            return TareaDTO;
        }
    }
}
