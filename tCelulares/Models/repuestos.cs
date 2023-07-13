using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tCelulares.Models
{
    internal class repuestos
    {
        public string referencia { get; set; }

        public string nombre { get; set; }

        public int cantidad { get; set; }    ////atributos y encapsulameiento

        public string disponibilidad { get; set; }

        public string fechai { get; set; }


        public repuestos()
        {
            this.referencia = "";
            this.nombre = "";
            this.cantidad = 0;
            this.disponibilidad = "";                        //constructor para iniciliazar atributos
            this.fechai = "";
        }


    }
}
