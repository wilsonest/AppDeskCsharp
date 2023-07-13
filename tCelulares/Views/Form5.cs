using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tCelulares.Controllers;
using tCelulares.datos;

namespace tCelulares.Views
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            llenarGrid();
        }

        public void llenarGrid() // metodo para mostrar los datos en el grid
        {
            DataTable datos = AccesoRepuestos.listar(); // llamamos el metodo de accesoRepuestos
            if (datos == null)
            {
                MessageBox.Show("No se logro acceder a los datos");
            }
            else
            {
                dgRepuestos.DataSource = datos.DefaultView;
            }
        }
    }
}
