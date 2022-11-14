using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_final
{
    public class Class_Pedido
    {
        public string? producto { get; set; }
        public float precio { get; set; }
        public float largo { get; set; }
        public float ancho { get; set; }
        public float alto { get; set; }
        public int volumen { get; set; }
        public int peso { get; set; }
        public int prioridad { get; set; }
        public string? barrio { get; set; }
        public DateTime fecha { get; set; }
        public int ID { get; set; }
        public static int maxID { get; set; }

        public bool cargado;


    }
}
