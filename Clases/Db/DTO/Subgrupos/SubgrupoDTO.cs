
namespace TasksBook.Clases.DTO.Subgrupos
{
    public class SubgrupoDTO
    {

        private int id;
        private int idGrupo;
        private string subgrupo;

        public int Id { get => id; set => id = value; }
        public int IdGrupo { get => idGrupo; set => idGrupo = value; }
        public string Subgrupo { get => subgrupo; set => subgrupo = value; }
    }
}
