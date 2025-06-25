using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TasksBook.Clases.DTO.Tarjetas
{
    public class TarjetaDTO
    {

        private int id;
        private string tarea;
        private string tema;
        private string proyecto;
        private int idPanel;
        private int orden;

        public int Id { get => id; set => id = value; }
        public string Tarea { get => tarea; set => tarea = value; }
        public string Tema { get => tema; set => tema = value; }
        public string Proyecto { get => proyecto; set => proyecto = value; }
        public int IdPanel { get => idPanel; set => idPanel = value; }
        public int Orden { get => orden; set => orden = value; }
    }
}
