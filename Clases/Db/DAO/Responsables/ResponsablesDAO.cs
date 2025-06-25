using TasksBook.Clases.Comunes;
using UtilesCs.Clases.Utilidades.Db;

namespace TasksBook.Clases.DAO.Responsables
{
    public class ResponsablesDAO
    {

        public static int GetIdResponsableByResponsable(string estado)
        {
            return UtilesDb.GetIdPorDato(Conexion.GetConexion(), "Responsables", "Responsable", estado);
        }

        public static string GetResponsableById(int id)
        {
            return UtilesDb.GetDatoPorId(Conexion.GetConexion(), "Responsables", "Responsable", id);
        }


    }
}
