
namespace TasksBook.Clases.DTO
{
    public class SeguimientoTareaDTO
    {

        private int id;
        private int idTarea;
        private string fecha;
        private string comentarios;
        private string abreTarea;

        public int Id { get => id; set => id = value; }
        public int IdTarea { get => idTarea; set => idTarea = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string Comentarios { get => comentarios; set => comentarios = value; }
        public string AbreTarea { get => abreTarea; set => abreTarea = value; }
    }
}
