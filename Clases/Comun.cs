using UtilesCs.Clases.Utilidades.Directorios;

namespace Calendario.Clases
{
    public class Comun
    {

        public static Logger logger = new Logger(UtilesDir.GetAppRootDir() + "calendario.log");

    }
}
