namespace Calendario.Clases.Db.DTO
{
    public class EventoConFechaDTO
    {

        private int id;
        private string fecha;
        private string hora;
        private string evento;
        private string comentarios;
        private string pendiente;

        public int Id { get => id; set => id = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string Hora { get => hora; set => hora = value; }
        public string Evento { get => evento; set => evento = value; }
        public string Comentarios { get => comentarios; set => comentarios = value; }
        public string Pendiente { get => pendiente; set => pendiente = value; }
    }
}
