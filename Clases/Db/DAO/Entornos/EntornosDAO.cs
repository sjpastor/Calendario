using TasksBook.Clases.Db;
using UtilesCs.Clases.Utilidades.Db;

namespace TasksBook.Clases.DAO.Entornos
{
    public class EntornosDAO
    {

        public static int GetIdEntornoByEntorno(string entorno)
        {
            return UtilesDb.GetIdPorDato(Conexion.GetConexion(), "Entornos", "Entorno", entorno);
        }

        public static string GetEntornoById(int id)
        {
            return UtilesDb.GetDatoPorId(Conexion.GetConexion(), "Entornos", "Entorno", id);
        }

    }
}
