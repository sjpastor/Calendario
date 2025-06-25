
namespace TasksBook.Clases.DTO
{
    public class ProyectoDTO
    {

        private int id;
        private string codProyecto;
        private string proyecto; 
        private string vProv;
        private string descripcion;
        private int idEstado;

        public int Id { get => id; set => id = value; }
        public string CodProyecto { get => codProyecto; set => codProyecto = value; }
        public string Proyecto { get => proyecto; set => proyecto = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int IdEstado { get => idEstado; set => idEstado = value; }
        public string VProv { get => vProv; set => vProv = value; }
    }
}
