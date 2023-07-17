using System.Data;
using tCelulares.Controllers;
using tCelulares.datos;
using tCelulares.modelo;

namespace tCelulares
{
    public partial class Form3 : Form
    {
        private object dgLista;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            llenarname();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        } //boton cerrar
       
        
        private void button3_Click(object sender, EventArgs e)
        {
            if (txtTelefono.Text.Trim() == "")  //validacion de campo vacio
            {

                MessageBox.Show("Debe igresar un numero de contacto");
            }
            else if (txtNombre.Text.Trim().Length < 5)  //validacion de tamaño de texto
            {
                MessageBox.Show("Debe ingresar un nombre mas largo");
            }
            else
            {
                try
                {
                    ingresos ing = new ingresos(); //instanciamos la clase ingresos
                    ing.Apellido = txtApellido.Text.Trim().ToUpper();
                    ing.Nombre = txtNombre.Text.Trim().ToUpper();
                    ing.Telefono = txtTelefono.Text.Trim().ToUpper();  // igualamos los atributos de la clase Empleado
                    ing.Cedula = Convert.ToInt32(txtCedula.Text.Trim());
                    ing.Modelo = txtModelo.Text.Trim().ToUpper();  // con lo ingresado en los campor txt
                    ing.Marca = txtMarca.Text.Trim().ToUpper();
                    ing.Estado = cbEstado.Text.Trim().ToUpper();
                    ing.Comentarios = txtComentarios.Text.Trim().ToUpper();
                    ing.Fechai = txtFechai.Value.Year + "-" + txtFechai.Value.Month + "-" + txtFechai.Value.Day;
                    if (AccesoDatos.guardar(ing))
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
            }
        } //boton guardar

        bool consultado = false;
        private void button2_Click_1(object sender, EventArgs e)
        {
            llenarname();
            //if (txtCedula.Text.Trim() == "")  //validacion de campo vacio
            //{

            //    MessageBox.Show("Para consultar debe igresar un documento");
            //}
            //else
            //{
            //    ingresos ingre = AccesoDatos.consultar(txtCedula.Text.Trim()); //Instanciamos la clase  y llamamos el metodo consultar

            //    if (ingre == null)
            //    {
            //        MessageBox.Show("No existe el dato con documento " + txtCedula.Text);
            //        limpiarCampos();
            //        consultado = false;
            //    }
            //    else
            //    {
            //        txtNombre.Text = ingre.Nombre;
            //        txtApellido.Text = ingre.Apellido;
            //        txtTelefono.Text = ingre.Telefono;
            //        txtModelo.Text = ingre.Modelo;        //aqui actualizamos los campos de texto con las variables de los atributos
            //        txtMarca.Text = ingre.Marca;
            //        cbEstado.Text = ingre.Estado;
            //        txtComentarios.Text = ingre.Comentarios;
            //        txtFechai.Text = ingre.Fechai;


            //        consultado = true;
            //    }
            //}
        }  //boton consultar

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            if (consultado == false)
            {

                MessageBox.Show("Debe consultar el cliente");
            }
            else if (txtCedula.Text.Trim() == "")  //validacion de campo vacio
            {

                MessageBox.Show("Debe igresar un documento valido");
            }
            else if (txtNombre.Text.Trim().Length < 5)  //validacion de tama�o de texto
            {
                MessageBox.Show("Debe ingresar un nombre mas largo");
            }
            else
            {
                try
                {
                    ingresos ing = new ingresos(); //instanciamos la clase empleado
                    ing.Apellido = txtApellido.Text.Trim().ToUpper();
                    ing.Nombre = txtNombre.Text.Trim().ToUpper();
                    ing.Cedula = Convert.ToInt32(txtCedula.Text.Trim()); 
                    ing.Telefono = txtTelefono.Text.Trim().ToUpper();  // igualamos los atributos de la clase Empleado
                    ing.Modelo = txtModelo.Text.Trim().ToUpper();  // con lo ingresado en los campor txt
                    ing.Marca = txtMarca.Text.Trim().ToUpper();
                    ing.Estado = cbEstado.Text.Trim().ToUpper();
                    ing.Comentarios = txtComentarios.Text.Trim().ToUpper();
                    ing.Fechai = txtFechai.Value.Year + "-" + txtFechai.Value.Month + "-" + txtFechai.Value.Day;
                    
                    if (AccesoDatos.actualizar(ing))
                    {
                        form2.llenarGrid(); // llamamos el metodo
                        limpiarCampos();
                        MessageBox.Show("Registro actualizado correctamente");
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
        }  // boton actualizar

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            if (consultado == false)
            {

                MessageBox.Show("Debe consultar primero");
            }
            else if (txtCedula.Text.Trim() == "")  //validacion de campo vacio
            {

                MessageBox.Show("Debe igresar un documento valido");
            }
            else if (DialogResult.Yes == MessageBox.Show(null, "Realmente desea eliminar el registro?", "Confirmacion", MessageBoxButtons.YesNo))
            {

                try
                {

                    if (AccesoDatos.eliminar(txtCedula.Text.Trim()))
                    {
                        form2.llenarGrid(); // llamamos el metodo
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
        }    //boton eliminar

        //-------------------METODOS-------------------------
        public void limpiarCampos() // metodo para limpiar campos
        {
            txtCedula.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtTelefono.Text = "";
            txtCedula.Text = "";
            txtMarca.Text = "";
            txtModelo.Text = "";
            cbEstado.Text = "";
            txtComentarios.Text = "";

        }

        //----------------------------------------------------------------------
        private void txtFechai_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        public void txtCedula_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbNombre_SelectedIndexChanged(object sender, EventArgs e)
        {
            //llenarname();
        }



        public void llenarname()
        {
            List<string> nombres = AccesoDatos.consultarname();
            if (nombres == null || nombres.Count == 0)
            {
                MessageBox.Show("No se logró acceder a los datos");
            }
            else
            {
                cbNombre.DataSource = nombres;
            }
        }



    }

}
