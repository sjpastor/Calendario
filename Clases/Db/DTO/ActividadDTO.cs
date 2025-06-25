
namespace TasksBook.Clases.DTO
{
    public class ActividadDTO
    {

        private int idActividad;
        private int idPlataforma;
        private string plataforma;
        private int idProyecto;
        private string codProyecto;
        private string proyecto;
        private string tema;
        private string descripcion;
        private string etiquetas;
        private string fApertura; 
        private string fFinalizado;
        private string fHito;
        private int idResponsable;
        private string responsable;
        private int idEstadoTema;
        private string estadoTema;

        public int IdActividad { get => idActividad; set => idActividad = value; }
        public int IdPlataforma { get => idPlataforma; set => idPlataforma = value; }
        public string Plataforma { get => plataforma; set => plataforma = value; }
        public int IdProyecto { get => idProyecto; set => idProyecto = value; }
        public string Proyecto { get => proyecto; set => proyecto = value; }
        public string Tema { get => tema; set => tema = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string FApertura { get => fApertura; set => fApertura = value; }
        public string FFinalizado { get => fFinalizado; set => fFinalizado = value; }
        public string FHito { get => fHito; set => fHito = value; }
        public int IdEstadoTema { get => idEstadoTema; set => idEstadoTema = value; }
        public string EstadoTema { get => estadoTema; set => estadoTema = value; }
        public int IdResponsable { get => idResponsable; set => idResponsable = value; }
        public string Responsable { get => responsable; set => responsable = value; }
        public string CodProyecto { get => codProyecto; set => codProyecto = value; }
        public string Etiquetas { get => etiquetas; set => etiquetas = value; }
    }
}
