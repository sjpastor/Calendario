namespace TasksBook.Clases.DTO.Hitos
{
    public class HitoDTO
    {

        private int id;
        private string fecha;
        private string hito;
        private string comentarios;

        public int Id { get => id; set => id = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string Hito { get => hito; set => hito = value; }
        public string Comentarios { get => comentarios; set => comentarios = value; }

    }
}
