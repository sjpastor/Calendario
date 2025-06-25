using TasksBook.Clases.Db;
using UtilesCs.Clases.Utilidades.Db;

namespace TasksBook.Clases.DAO.Tipos
{
    public class TiposDAO
    {

        public static int GetIdTipoByTipo(string tipo)
        {
            return UtilesDb.GetIdPorDato(Conexion.GetConexion(), "Tipos", "Tipo", tipo);
        }

        public static string GetTipoById(int id)
        {
            return UtilesDb.GetDatoPorId(Conexion.GetConexion(), "Tipos", "Tipo", id);
        }

    }
}
