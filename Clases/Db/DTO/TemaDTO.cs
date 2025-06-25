
namespace TasksBook.Clases.DTO
{
    public class TareaDTO
    {

        private int id;
        private int idPlataforma;
        private string plataforma;
        private int idProyecto;
        private string codProyecto;
        private string proyecto;
        private string Tarea;
        private string descripcion;
        private string etiquetas;
        private string fApertura; 
        private string fFinalizado;
        private string fHito;
        private int idResponsable;
        private string responsable;
        private int idEstadoTarea;
        private string estadoTarea;

        public int Id { get => id; set => id = value; }
        public int IdPlataforma { get => idPlataforma; set => idPlataforma = value; }
        public string Plataforma { get => plataforma; set => plataforma = value; }
        public int IdProyecto { get => idProyecto; set => idProyecto = value; }
        public string Proyecto { get => proyecto; set => proyecto = value; }
        public string Tarea { get => Tarea; set => Tarea = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string FApertura { get => fApertura; set => fApertura = value; }
        public string FFinalizado { get => fFinalizado; set => fFinalizado = value; }
        public string FHito { get => fHito; set => fHito = value; }
        public int IdEstadoTarea { get => idEstadoTarea; set => idEstadoTarea = value; }
        public string EstadoTarea { get => estadoTarea; set => estadoTarea = value; }
        public int IdResponsable { get => idResponsable; set => idResponsable = value; }
        public string Responsable { get => responsable; set => responsable = value; }
        public string CodProyecto { get => codProyecto; set => codProyecto = value; }
        public string Etiquetas { get => etiquetas; set => etiquetas = value; }
    }
}
