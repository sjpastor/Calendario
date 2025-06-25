
namespace TasksBook.Clases.DTO.HistorialTareas
{
    public class HistorialTareaDTO
    {

        private int id;
        private int idTarea;
        private string fecha;
        private string notas;

        public int Id { get => id; set => id = value; }
        public int IdTarea { get => idTarea; set => idTarea = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string Notas { get => notas; set => notas = value; }

    }
}
