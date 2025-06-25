using TasksBook.Clases.Db;
using UtilesCs.Clases.Utilidades.Db;

namespace TasksBook.Clases.DAO.Prioridades
{
    public class PrioridadesDAO
    {

        public static int GetIdPrioridadByPrioridad(string prioridad)
        {
            return UtilesDb.GetIdPorDato(Conexion.GetConexion(), "Prioridades", "Prioridad", prioridad);
        }

        public static string GetPrioridadById(int id)
        {
            return UtilesDb.GetDatoPorId(Conexion.GetConexion(), "Prioridades", "Prioridad", id);
        }


    }
}
