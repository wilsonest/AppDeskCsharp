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
using tCelulares.Models;

namespace tCelulares.Views
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool consultado = false;
        private void button2_Click(object sender, EventArgs e)
        {
            if (txtReferencia.Text.Trim() == "")  //validacion de campo vacio
            {

                MessageBox.Show("Para consultar debe igresar una referencia");
            }
            else
            {
                repuestos rep = AccesoRepuestos.consultar(txtReferencia.Text.Trim()); //Instanciamos la clase  y llamamos el metodo consultar

                if (rep == null)
                {
                    MessageBox.Show("No existe el producto con referencia " + txtReferencia.Text);
                    limpiarCampos();
                    consultado = false;
                }
                else
                {
                    txtNombre.Text = rep.nombre;  //aqui actualizamos los campos de texto con las variables de los atributos
                    txtCantidad.Text = rep.cantidad.ToString();
                    cbDisponible.Text = rep.disponibilidad;
                    txtFechai.Text = rep.fechai;


                    consultado = true;
                }
            }
        }  //boton consultar

        private void button3_Click(object sender, EventArgs e) 
        {
            try
            {
                repuestos rep = new repuestos(); //instanciamos la clase ingresos
                rep.referencia = txtReferencia.Text.Trim().ToUpper();
                rep.nombre = txtNombre.Text.Trim().ToUpper();  // igualamos los atributos de la clase Empleado
                rep.cantidad = Convert.ToInt32(txtCantidad.Text.Trim());  // con lo ingresado en los campor txt
                rep.disponibilidad = cbDisponible.Text.Trim().ToUpper();
                rep.fechai = txtFechai.Value.Year + "-" + txtFechai.Value.Month + "-" + txtFechai.Value.Day;
                if (AccesoRepuestos.guardar(rep))
                {
                    // llamamos el metodo
                    limpiarCampos();
                    MessageBox.Show("Ingreso Exitoso");
                }
                else
                {
                    MessageBox.Show("YA EXISTE EL USUARIO");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }  //boton guardar

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            if (consultado == false)
            {

                MessageBox.Show("Debe consultar primero");
            }
            else if (txtReferencia.Text.Trim() == "")  //validacion de campo vacio
            {

                MessageBox.Show("Debe igresar una referencia valida");
            }
            else if (txtNombre.Text.Trim().Length < 5)  //validacion de tama�o de texto
            {
                MessageBox.Show("Debe ingresar un nombre mas largo");
            }
            else
            {
                try
                {
                    repuestos rep = new repuestos(); //instanciamos la clase empleado

                    rep.referencia= txtReferencia.Text.Trim().ToUpper();
                    rep.nombre = txtNombre.Text.Trim().ToUpper();
                    rep.cantidad = Convert.ToInt32(txtCantidad.Text.Trim());// igualamos los atributos de la clase Empleado
                    rep.disponibilidad = cbDisponible.Text.Trim().ToUpper();// con lo ingresado en los campor txt  
                    rep.fechai = txtFechai.Value.Year + "-" + txtFechai.Value.Month + "-" + txtFechai.Value.Day;

                    if (AccesoRepuestos.actualizar(rep))
                    {
                        form5.llenarGrid(); // llamamos el metodo
                        limpiarCampos();
                        MessageBox.Show("El producto se actualizado correctamente");
                        consultado = false;
                    }
                    else
                    {
                        MessageBox.Show("No se actualizo");
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        } //boton actualizar

        private void button5_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            if (consultado == false)
            {

                MessageBox.Show("Debe consultar primero");
            }
            else if (txtReferencia.Text.Trim() == "")  //validacion de campo vacio
            {

                MessageBox.Show("Debe igresar un documento valido");
            }
            else if (DialogResult.Yes == MessageBox.Show(null, "Realmente desea eliminar el registro?", "Confirmacion", MessageBoxButtons.YesNo))
            {

                try
                {

                    if (AccesoRepuestos.eliminar(txtReferencia.Text.Trim()))
                    {
                        form5.llenarGrid(); // llamamos el metodo
                        limpiarCampos();
                        MessageBox.Show("Registro eliminado correctamente");
                        consultado = false;
                    }
                    else
                    {
                        MessageBox.Show("No se elimino");
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        } //boton eliminar

        //--------------------------------------METODOS-----------------------------

        public void limpiarCampos() // metodo para limpiar campos
        {
            txtReferencia.Text = "";
            txtNombre.Text = "";
            txtCantidad.Text = "";
            cbDisponible.Text = "";
         
        }

 
    }
    
}
