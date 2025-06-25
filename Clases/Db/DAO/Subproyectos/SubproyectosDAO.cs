using TasksBook.Clases.Db;
using UtilesCs.Clases.Utilidades.Db;

namespace TasksBook.Clases.DAO.Subproyectos
{
    public class SubproyectosDAO
    {

        public static int GetIdSubproyectoBySubproyecto(string subproyecto)
        {
            return UtilesDb.GetIdPorDato(Conexion.GetConexion(), "Subproyectos", "Subproyecto", subproyecto);
        }

        public static string GetSubproyectoById(int id)
        {
            return UtilesDb.GetDatoPorId(Conexion.GetConexion(), "Subproyectos", "Subproyecto", id);
        }


    }
}
