using TasksBook.Clases.Comunes;
using UtilesCs.Clases.Utilidades.Db;

namespace TasksBook.Clases.DAO.EstadosTareas
{
    public class EstadosTareasDAO
    {

        public static int GetIdEstadoByEstado(string estado)
        {
            return UtilesDb.GetIdPorDato(Conexion.GetConexion(), "EstadosTareas", "EstadoTarea", estado);
        }

        public static string GetEstadoById(int id)
        {
            return UtilesDb.GetDatoPorId(Conexion.GetConexion(), "EstadosTareas", "EstadoTarea", id);
        }


    }
}
