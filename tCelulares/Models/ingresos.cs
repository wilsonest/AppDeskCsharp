using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tCelulares.modelo
{
    public class ingresos
    {
        private int cedula;
        public string nombre;
        private string apellido;
        private string telefono;
        private string modelo;                          //atributos
        private string marca;
        private string estado;
        private string comentarios;
        private string fechai;


        public ingresos()
        {
            this.cedula = 0;
            this.nombre = "";
            this.apellido = "";
            this.telefono = "";                        //constructor para iniciliazar atributos
            this.modelo = "";
            this.marca = "";
            this.estado = "";
            this.comentarios = "";
            this.fechai = "";
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Modelo { get => modelo; set => modelo = value; }            //encapsulamiento
        public string Marca { get => marca; set => marca = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Comentarios { get => comentarios; set => comentarios = value; }
        public string Fechai { get => fechai; set => fechai = value; }
        public int Cedula { get => cedula; set => cedula = value; }
    }
}
