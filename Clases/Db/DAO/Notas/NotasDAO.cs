using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Reflection;
using System.Windows.Forms;
using TasksBook.Clases.Comunes;
using TasksBook.Clases.Comunes.Rendimiento;
using TasksBook.Clases.DAO.CiclosVida;
using TasksBook.Clases.DAO.Entornos;
using TasksBook.Clases.DAO.Proyectos;
using TasksBook.Clases.DAO.Subproyectos;
using TasksBook.Clases.Db;
using TasksBook.Clases.DTO.Notas;
using UtilesCs.Clases.Utilidades.AccessDb;
using UtilesCs.Clases.Utilidades.Db;

namespace TasksBook.Clases.DAO.Notas
{
    public class NotasDAO
    {

        public static List<NotaDTO> GetAllNotas(string texto = "", string proyecto = "", string fDesde = "", string fHasta = "")
        {

            Logger.Entrando(MethodBase.GetCurrentMethod().Name);

            string sql;
            List<NotaDTO> listado = new List<NotaDTO>();

            string[] palabras = texto.Split(',');

            sql = "";
            sql += "SELECT * ";
            sql += "  FROM Notas ";
            if (!proyecto.Equals(""))
            {
                sql += " WHERE IdProyecto = " + ProyectosDAO.GetIdProyectoByProyecto(proyecto).ToString() + " ";
            }
            if (palabras.Length > 0 & !palabras[0].Equals(""))
            {
                sql += OleDbUtiles.SqlWhereAnd(sql) + "(";
                foreach (string palabra in palabras)
                {
                    sql += " Notas Like '%" + palabra.Trim() + "%' OR";
                    sql += " Tema Like '%" + palabra.Trim() + "%' OR";
                }
                sql = sql.Substring(0, sql.Length - 3);
                sql += ")";
            }
            if (!fDesde.Equals(""))
            {
                sql += OleDbUtiles.SqlWhereAnd(sql) + " Fecha >= " + UtilesAccessDb.GetFechaAccess(fDesde);
            }
            if (!fHasta.Equals(""))
            {
                sql += OleDbUtiles.SqlWhereAnd(sql) + " Fecha <= " + UtilesAccessDb.GetFechaAccess(fHasta);
            }
            sql += " ORDER BY Fecha, Id";

            Globales.logger.WriteLog(sql);
            OleDbDataReader reader = UtilesDb.GetOleDbDataReader(Conexion.GetConexion(), sql);
            if (reader == null)
                return null;

            if (!reader.HasRows)
                return null;

            while (reader.Read())
            {
                NotaDTO dto = ReaderToDTO(reader);
                listado.Add(dto);
            }
            reader.Close();

            Logger.Saliendo(MethodBase.GetCurrentMethod().Name);

            return listado;

        }

        public static string GetNotasById(int id)
        {

            Logger.Entrando(MethodBase.GetCurrentMethod().Name);

            string sql;
            string notas;

            sql = "";
            sql += "SELECT Notas ";
            sql += "  FROM Notas ";
            sql += " WHERE Id = " + id.ToString() + " ";

            Globales.logger.WriteLog(sql);
            OleDbDataReader reader = UtilesDb.GetOleDbDataReader(Conexion.GetConexion(), sql);
            if (reader == null)
                return String.Empty;

            if (!reader.HasRows)
                return String.Empty;

            reader.Read();
            notas = OleDbUtiles.GetDatoAsString(reader, "notas");
            reader.Close();

            Logger.Saliendo(MethodBase.GetCurrentMethod().Name);

            return notas;
        }

        public static bool Guardar(NotaDTO dto)
        {
            if (dto.Id == 0)
                return Insertar(dto);
            else
                return Update(dto);
        }

        private static bool Insertar(NotaDTO dto)
        {

            bool retorno;
            Logger.Entrando(MethodBase.GetCurrentMethod().Name);

            string sql = "";

            sql = "";
            sql += "INSERT INTO Notas (Fecha, IdProyecto, IdSubproyecto, IdEntorno, IdCicloVida, Tema,  Notas, Origen)";
            sql += " VALUES (" + UtilesAccessDb.GetFechaAccess(dto.Fecha) + ",";
            sql += "         " + dto.IdProyecto.ToString() + ",";
            sql += "         " + dto.IdSubproyecto.ToString() + ",";
            sql += "         " + dto.IdEntorno.ToString() + ",";
            sql += "         " + dto.IdCicloVida.ToString() + ",";
            sql += "        '" + dto.Tema + "',";
            sql += "        '" + dto.Notas + "',";
            sql += "        '" + dto.Origen + "')";

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

        private static bool Update(NotaDTO dto)
        {
            Logger.Entrando(MethodBase.GetCurrentMethod().Name);

            bool retorno;
            string sql = "";

            sql = "";
            sql += "UPDATE Notas ";
            sql += "   SET Fecha = " + UtilesAccessDb.GetFechaAccess(dto.Fecha) + ",";
            sql += "       IdProyecto = " + dto.IdProyecto + ",";
            sql += "       IdSubproyecto = " + dto.IdSubproyecto + ",";
            sql += "       IdEntorno = " + dto.IdEntorno + ",";
            sql += "       IdCicloVida = " + dto.IdCicloVida + ",";
            sql += "       Tema = '" + dto.Tema + "',";
            sql += "       Notas = '" + dto.Notas + "',";
            sql += "       Origen = '" + dto.Origen + "' ";
            sql += " WHERE Id = " + dto.Id.ToString();

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

        private static NotaDTO ReaderToDTO(OleDbDataReader reader)
        {

            Logger.Entrando(MethodBase.GetCurrentMethod().Name);

            NotaDTO notaDTO = new NotaDTO();
            notaDTO.Id = OleDbUtiles.GetIntFromReader(reader, "Id");
            notaDTO.Fecha = OleDbUtiles.GetStringFromReader(reader, "Fecha");
            notaDTO.IdProyecto = OleDbUtiles.GetIntFromReader(reader, "IdProyecto");
            notaDTO.Proyecto = ProyectosDAO.GetProyectoById(notaDTO.IdProyecto);
            notaDTO.IdSubproyecto = OleDbUtiles.GetIntFromReader(reader, "IdSubproyecto");
            notaDTO.Subproyecto = SubproyectosDAO.GetSubproyectoById(notaDTO.IdSubproyecto);
            notaDTO.IdEntorno = OleDbUtiles.GetIntFromReader(reader, "IdEntorno");
            notaDTO.Entorno = EntornosDAO.GetEntornoById(notaDTO.IdEntorno);
            notaDTO.IdCicloVida = OleDbUtiles.GetIntFromReader(reader, "IdCicloVida");
            notaDTO.CicloVida = CiclosVidaDAO.GetCicloVidaById(notaDTO.IdCicloVida);
            notaDTO.Tema = OleDbUtiles.GetStringFromReader(reader, "Tema");
            notaDTO.Notas = OleDbUtiles.GetStringFromReader(reader, "Notas");
            notaDTO.Origen = OleDbUtiles.GetStringFromReader(reader, "Origen");
            //notaDTO.Adjuntos = OleDbUtiles.GetStringFromReader(reader, "Adjuntos");

            Logger.Saliendo(MethodBase.GetCurrentMethod().Name);

            return notaDTO;
        }
    }
}
