using Calendario.Clases;
using System;
using System.Configuration;
using System.Data.OleDb;

namespace TasksBook.Clases.Db
{
    public class Conexion
    {

        private static OleDbConnection con;

        public static OleDbConnection GetConexion()
        {

            if (con != null)
                return con;

            string cadenaConexion = ConfigurationManager.AppSettings["CadenaConexion"];

            Comun.logger.WriteLog("Conectando con: " + cadenaConexion);
            con = new OleDbConnection(cadenaConexion);
            try
            {
                con.Open();
                Comun.logger.WriteLog("Conectado a " + cadenaConexion);
                return con;
            }
            catch (Exception ex)
            {
                Comun.logger.WriteLog(ex.Message);
                con = null;
                return (OleDbConnection)null;
            }
        }

    }
}
