using TasksBook.Clases.Db;
using UtilesCs.Clases.Utilidades.Db;

namespace TasksBook.Clases.DAO.Tipos
{
    public class SituacionesDAO
    {

        public static int GetIdSituacionBySituacion(string situacion)
        {
            return UtilesDb.GetIdPorDato(Conexion.GetConexion(), "Situaciones", "Situacion", situacion);
        }

        public static string GetSituacionById(int id)
        {
            return UtilesDb.GetDatoPorId(Conexion.GetConexion(), "Situaciones", "Situacion", id);
        }

    }
}
