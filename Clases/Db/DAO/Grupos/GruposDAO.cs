using TasksBook.Clases.Comunes;
using UtilesCs.Clases.Utilidades.Db;

namespace TasksBook.Clases.DAO.Grupos
{
    public class GruposDAO
    {

        public static int GetIdGrupoByGrupo(string grupo)
        {
            return UtilesDb.GetIdPorDato(MerakiDb.GetConexion(), "Grupos", "Grupo", grupo);
        }

        public static string GetGrupoById(int id)
        {
            return UtilesDb.GetDatoPorId(MerakiDb.GetConexion(), "Grupos", "Grupo", id);
        }

    }
}
