using TasksBook.Clases.Comunes;
using UtilesCs.Clases.Utilidades.Db;

namespace TasksBook.Clases.DAO.EstadosTareas
{
    public class EstadosTareasDAO
    {

        public static int GetIdEstadoByEstado(string estado)
        {
            return UtilesDb.GetIdPorDato(MerakiDb.GetConexion(), "EstadosTareas", "EstadoTarea", estado);
        }

        public static string GetEstadoById(int id)
        {
            return UtilesDb.GetDatoPorId(MerakiDb.GetConexion(), "EstadosTareas", "EstadoTarea", id);
        }


    }
}
