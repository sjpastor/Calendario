namespace TasksBook.Clases.DTO.Notas
{
    public class NotaDTO
    {

        private int id;
        private string fecha;
        private int idProyecto;
        private string proyecto;
        private int idSubproyecto;
        private string subproyecto;
        private string tema;
        private string notas;
        private string origen;
        private string adjuntos;
        private int idEntorno;
        private string entorno;
        private int idCicloVida;
        private string cicloVida;

        public int Id { get => id; set => id = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public int IdProyecto { get => idProyecto; set => idProyecto = value; }
        public string Proyecto { get => proyecto; set => proyecto = value; }
        public string Notas { get => notas; set => notas = value; }
        public string Origen { get => origen; set => origen = value; }
        public string Adjuntos { get => adjuntos; set => adjuntos = value; }
        public int IdSubproyecto { get => idSubproyecto; set => idSubproyecto = value; }
        public string Subproyecto { get => subproyecto; set => subproyecto = value; }
        public string Tema { get => tema; set => tema = value; }
        public int IdEntorno { get => idEntorno; set => idEntorno = value; }
        public string Entorno { get => entorno; set => entorno = value; }
        public int IdCicloVida { get => idCicloVida; set => idCicloVida = value; }
        public string CicloVida { get => cicloVida; set => cicloVida = value; }
    }
}
