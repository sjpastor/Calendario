using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksBook.Clases.DTO.Grupos
{
    public class GrupoDTO
    {

        private int id;
        private string grupo;

        public int Id { get => id; set => id = value; }
        public string Grupo { get => grupo; set => grupo = value; }
    }
}
