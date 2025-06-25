
namespace TasksBook.Clases.DTO
{
    public class SeguimientoTareaDTO
    {

        private int id;
        private int idTarea;
        private string fecha;
        private string notas;
        private string etiquetas;
        private string abreTarea;

        public int Id { get => id; set => id = value; }
        public int IdTarea { get => idTarea; set => idTarea = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string Notas { get => notas; set => notas = value; }
        public string AbreTarea { get => abreTarea; set => abreTarea = value; }
        public string Etiquetas { get => etiquetas; set => etiquetas = value; }
    }
}
