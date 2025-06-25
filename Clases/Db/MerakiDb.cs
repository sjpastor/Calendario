using System.Data.OleDb;
using Cuadernotas.Clases.Db;

namespace Cuadernotas.Clases.Comunes
{
    public class Cuadernotas
    {

        // Configuración de la base de datos
        private static OleDbConnection con;
        public static string nombreBd = "Cuadernotas.accdb";
        public const string cadcon = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=";
        public static string baseDatos = AppDir.GetDirDatos() + nombreBd;

        public static OleDbConnection GetConexion()
        {
            if (Cuadernotas.con != null)
                return Cuadernotas.con;
            Globales.logger.WriteLog("Conectando con: Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + baseDatos);
            Cuadernotas.con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + baseDatos);
            return Conexion.GetConexion(baseDatos);
        }
    }
}
