namespace TasksBook.Clases.DTO.Tareas
{
    public class TareaDTO
    {

        private int id;
        private int orden;
        private string fecha;
        private int idProyecto;
        private string proyecto;
        private int idSubproyecto;
        private string subproyecto;
        private string tema;
        private string tarea;
        private int idSituacion;
        private string situacion;
        private int idTipo;
        private string tipo;
        private string recordar;
        private string ultModificacion;
        private string tareaDetalles;
        private int idPrioridad;
        private string prioridad;

        public int Id { get => id; set => id = value; }
        public int Orden { get => orden; set => orden = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public int IdProyecto { get => idProyecto; set => idProyecto = value; }
        public string Proyecto { get => proyecto; set => proyecto = value; }
        public string Tarea { get => tarea; set => tarea = value; }
        public int IdSituacion { get => idSituacion; set => idSituacion = value; }
        public string Situacion { get => situacion; set => situacion = value; }
        public int IdTipo { get => idTipo; set => idTipo = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string Recordar { get => recordar; set => recordar = value; }
        public int IdPrioridad { get => idPrioridad; set => idPrioridad = value; }
        public string Prioridad { get => prioridad; set => prioridad = value; }
        public string TareaDetalles { get => tareaDetalles; set => tareaDetalles = value; }
        public string UltModificacion { get => ultModificacion; set => ultModificacion = value; }
        public int IdSubproyecto { get => idSubproyecto; set => idSubproyecto = value; }
        public string Subproyecto { get => subproyecto; set => subproyecto = value; }
        public string Tema { get => tema; set => tema = value; }
    }
}
