using TasksBook.Clases.Db;
using UtilesCs.Clases.Utilidades.Db;

namespace TasksBook.Clases.DAO.CiclosVida
{
    public class CiclosVidaDAO
    {

        public static int GetIdCicloVidaByCicloVida(string cicloVida)
        {
            return UtilesDb.GetIdPorDato(Conexion.GetConexion(), "CiclosVida", "CicloVida", cicloVida);
        }

        public static string GetCicloVidaById(int id)
        {
            return UtilesDb.GetDatoPorId(Conexion.GetConexion(), "CiclosVida", "CicloVida", id);
        }

    }
}
