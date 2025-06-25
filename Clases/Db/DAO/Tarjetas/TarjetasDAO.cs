using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TasksBook.Clases.Comunes.Rendimiento;
using TasksBook.Clases.Comunes;
using TasksBook.Clases.Db;
using TasksBook.Clases.DTO.Tarjetas;
using UtilesCs.Clases.Utilidades.Db;
using TasksBook.Clases.DTO.Tareas;
using System.Data.OleDb;
using TasksBook.Clases.DAO.Tareas;

namespace TasksBook.Clases.DAO.Tarjetas
{
    public class TarjetasDAO
    {

        public static int Insertar(TarjetaDTO tarjetaDTO)
        {

            string sql = "";
            int retorno;

            sql = "";
            sql += "INSERT INTO Tarjetas (Tarea, Tema, Proyecto, IdPanel, Orden)";
            sql += "VALUES ('" + tarjetaDTO.Tarea + "',";
            sql += "        '" + tarjetaDTO.Tema + "',";
            sql += "        '" + tarjetaDTO.Proyecto + "',";
            sql += "         " + tarjetaDTO.IdPanel.ToString() + ",";
            sql += "         " + tarjetaDTO.Orden.ToString() + ")";

            Globales.logger.WriteLog(sql);

            retorno = -1;

            try
            {
                if (UtilesDb.EjecutaQuery(Conexion.GetConexion(), sql, true))
                {
                    retorno = Convert.ToInt32(UtilesDb.GetMaxId(Conexion.GetConexion(), "Tarjetas"));
                }
            }
            catch (Exception ex)
            {
                Globales.logger.WriteLog(ex.Message);
                MessageBox.Show(ex.Message);
            }

            Logger.Saliendo(MethodBase.GetCurrentMethod().Name);

            return retorno;

        }

        public static bool Update(TarjetaDTO tarjetaDTO)
        {

            string sql = "";
            bool retorno;

            sql = "";
            sql += "UPDATE Tarjetas";
            sql += "   SET Tarea = '" + tarjetaDTO.Tarea + "',";
            sql += "       Tema = '" + tarjetaDTO.Tema + "',";
            sql += "       Proyecto = '" + tarjetaDTO.Proyecto + "',";
            sql += "       IdPanel = " + tarjetaDTO.IdPanel.ToString() + ",";
            sql += "       Orden = " + tarjetaDTO.Orden.ToString() + " ";
            sql += "  WHERE Id = " + tarjetaDTO.Id.ToString();

            Globales.logger.WriteLog(sql);

            retorno = false;

            try
            {
                UtilesDb.EjecutaQuery(Conexion.GetConexion(), sql, true);
                retorno = true;
            }
            catch (Exception ex)
            {
                Globales.logger.WriteLog(ex.Message);
                MessageBox.Show(ex.Message);
            }

            Logger.Saliendo(MethodBase.GetCurrentMethod().Name);

            return retorno;

        }

        public static int GetMaxOrden(int idPanel)
        {
            string sql = "";
            int retorno;

            sql = "";
            sql += "SELECT MAX(Orden) AS MaxOrden ";
            sql += "  FROM Tarjetas ";
            sql += " WHERE IdPanel = " + idPanel;

            Globales.logger.WriteLog(sql);

            retorno = 1;

            try
            {

                OleDbDataReader reader = UtilesDb.GetOleDbDataReader(Conexion.GetConexion(), sql);
                if (reader == null)
                    return retorno;

                if (!reader.HasRows)
                    return retorno;

                while (reader.Read())
                {
                    retorno = OleDbUtiles.GetIntFromReader(reader, "MaxOrden");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Globales.logger.WriteLog(ex.Message);
                MessageBox.Show(ex.Message);
            }

            Logger.Saliendo(MethodBase.GetCurrentMethod().Name);

            return retorno;
        }

        public static TarjetaDTO GetTarjetaById(int id)
        {
            string sql = "";

            sql = "";
            sql += "SELECT * ";
            sql += "  FROM Tarjetas ";
            sql += " WHERE Id = " + id;

            Globales.logger.WriteLog(sql);

            try
            {

                OleDbDataReader reader = UtilesDb.GetOleDbDataReader(Conexion.GetConexion(), sql);
                if (reader == null)
                    return null;

                if (!reader.HasRows)
                    return null;

                reader.Read();
                TarjetaDTO dto = ReaderToDTO(reader);
                reader.Close();
                return dto;
            }
            catch (Exception ex)
            {
                Globales.logger.WriteLog(ex.Message);
                MessageBox.Show(ex.Message);
            }

            Logger.Saliendo(MethodBase.GetCurrentMethod().Name);

            return null;
        }

        private static TarjetaDTO ReaderToDTO(OleDbDataReader reader) 
        {
            TarjetaDTO dto = new TarjetaDTO();
            dto.Id = OleDbUtiles.GetIntFromReader(reader, "Id");
            dto.Tarea = OleDbUtiles.GetStringFromReader(reader, "Tarea");
            dto.Tema = OleDbUtiles.GetStringFromReader(reader, "Tema");
            dto.Proyecto = OleDbUtiles.GetStringFromReader(reader, "Proyecto");
            dto.Orden = OleDbUtiles.GetIntFromReader(reader, "Orden");
            dto.IdPanel = OleDbUtiles.GetIntFromReader(reader, "IdPanel");
            return dto;
        }

    }

}
