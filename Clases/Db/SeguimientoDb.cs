using System.Data.OleDb;
using Cuadernotas.Clases.Db;

namespace Cuadernotas.Clases.Comunes
{
    public class SeguimientoDb
    {

        // Configuración de la base de datos
        private static OleDbConnection con;
        public static string nombreBd = "Seguimiento.accdb";
        public const string cadcon = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=";
        public static string baseDatos = AppDir.GetDirDatos() + nombreBd;

        public static OleDbConnection GetConexion()
        {
            if (SeguimientoDb.con != null)
                return SeguimientoDb.con;
            Globales.logger.WriteLog("Conectando con: Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + baseDatos);
            SeguimientoDb.con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + baseDatos);
            return Conexion.GetConexion(baseDatos);

        }
    }
}
