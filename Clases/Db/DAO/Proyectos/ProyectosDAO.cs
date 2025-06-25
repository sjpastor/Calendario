using TasksBook.Clases.Db;
using UtilesCs.Clases.Utilidades.Db;

namespace TasksBook.Clases.DAO.Proyectos
{
    public class ProyectosDAO
    {

        public static int GetIdProyectoByProyecto(string proyecto)
        {
            return UtilesDb.GetIdPorDato(Conexion.GetConexion(), "Proyectos", "Proyecto", proyecto);
        }

        public static string GetProyectoById(int id)
        {
            return UtilesDb.GetDatoPorId(Conexion.GetConexion(), "Proyectos", "Proyecto", id);
        }

        public static bool ExisteProyectoByProyecto(string proyecto)
        {
            int idProyecto = 0;

            idProyecto = UtilesDb.GetIdPorDato(Conexion.GetConexion(), "Proyectos", "Proyecto", proyecto, "Id", -1);

            return idProyecto == -1 ? false : true;

        }

        public static bool ExisteProyectoByIdProyecto(int idProyecto)
        {
            int id = 0;

            id = UtilesDb.GetIdPorDato(Conexion.GetConexion(), "Proyectos", "IdProyecto", idProyecto.ToString(), "Id", -1);

            return idProyecto == -1 ? false : true;

        }


    }
}
