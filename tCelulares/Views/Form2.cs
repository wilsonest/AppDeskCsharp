using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tCelulares.datos;
using tCelulares.modelo;

namespace tCelulares
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e) //boton de cerrar
        {
            form1.openForm3();
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            llenarGrid();
        }

        public void llenarGrid() // metodo para mostrar los datos en el grid
        {
            DataTable datos = AccesoDatos.listar(); // llamamos el metodo de accesodatos
            if (datos == null)
            {
                MessageBox.Show("No se logro acceder a los datos");
            }
            else
            {
                dgDatos.DataSource = datos.DefaultView;
            }
        }

        private void dgLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
       
        Form1 form1 = new Form1();
        private void button3_Click(object sender, EventArgs e) //boton ir al menu de datos
        {
            this.Close();
            form1.openForm3();
            
        }
    }
}
