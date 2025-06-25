using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;
using TasksBook.Clases.Comunes;
using TasksBook.Clases.Db;
using TasksBook.Clases.DTO.Hitos;
using UtilesCs.Clases.Utilidades.AccessDb;
using UtilesCs.Clases.Utilidades.Db;

namespace TasksBook.Clases.DAO.Hitos
{
    public class HitosDAO
    {

        public static List<HitoDTO> GetAllHitos(string texto, bool ocultarTerminados, string fDesde = "", string fHasta = "")
        {
            string sql;
            List<HitoDTO> listado = new List<HitoDTO>();

            string[] palabras = texto.Split(',');

            sql = "";
            sql += "SELECT * ";
            sql += "  FROM Hitos";
            if (ocultarTerminados)
            {
                sql += " WHERE Fecha >= #" + DateTime.Now.ToString("MM/dd/yyyy") + "#";
            }
            if (!fDesde.Equals(""))
            {
                sql += OleDbUtiles.SqlWhereAnd(sql) + " Fecha >= #" + Convert.ToDateTime(fDesde).ToString("MM/dd/yyyy") + "#";
            }
            if (!fHasta.Equals(""))
            {
                sql += OleDbUtiles.SqlWhereAnd(sql) + " Fecha <= #" + Convert.ToDateTime(fHasta).ToString("MM/dd/yyyy") + "#";
            }
            if (palabras.Length > 0 & !palabras[0].Equals(""))
            {
                sql += OleDbUtiles.SqlWhereAnd(sql) + "(";
                foreach (string palabra in palabras)
                {
                    sql += " Hitos Like '%" + palabra.Trim() + "%' OR";
                }
                sql = sql.Substring(0, sql.Length - 3);
                sql += ")";
            }
            sql += " ORDER BY Fecha";

            Globales.logger.WriteLog(sql);
            OleDbDataReader reader = UtilesDb.GetOleDbDataReader(Conexion.GetConexion(), sql);
            if (reader == null)
                return null;

            if (!reader.HasRows)
                return null;

            while (reader.Read())
            {
                HitoDTO dto = ReaderToDTO(reader);
                listado.Add(dto);
            }
            reader.Close();

            return listado;


        }

        public static bool Guardar(HitoDTO dto)
        {
            if (dto.Id == 0)
                return Insertar(dto);
            else
                return Update(dto);
        }

        private static bool Insertar(HitoDTO dato)
        {

            string sql = "";

            sql = "";
            sql += "INSERT INTO Hitos (Fecha, Hito, Comentarios)";
            sql += " VALUES (" + UtilesAccessDb.GetFechaAccess(dato.Fecha) + ",";
            sql += "        '" + dato.Hito + "',";
            sql += "        '" + dato.Comentarios + "')";

            Console.WriteLine(sql);

            try
            {
                UtilesDb.EjecutaQuery(Conexion.GetConexion(), sql, true);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }

        private static bool Update(HitoDTO dato)
        {
            string sql = "";

            sql = "";
            sql += "UPDATE Hitos";
            sql += "   SET Fecha = " + UtilesAccessDb.GetFechaAccess(dato.Fecha) + ",";
            sql += "       Hito = '" + dato.Hito + "',";
            sql += "       Comentarios = '" + dato.Comentarios + "'";
            sql += " WHERE Id = " + dato.Id.ToString();

            Console.WriteLine(sql);

            try
            {
                UtilesDb.EjecutaQuery(Conexion.GetConexion(), sql, true);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }

        private static HitoDTO ReaderToDTO(OleDbDataReader reader)
        {
            HitoDTO HitoDTO = new HitoDTO();
            HitoDTO.Id = OleDbUtiles.GetIntFromReader(reader, "Id");
            HitoDTO.Fecha = OleDbUtiles.GetStringFromReader(reader, "Fecha");
            HitoDTO.Hito = OleDbUtiles.GetStringFromReader(reader, "Hito");
            HitoDTO.Comentarios = OleDbUtiles.GetStringFromReader(reader, "Comentarios");
            return HitoDTO;
        }
    }
}
