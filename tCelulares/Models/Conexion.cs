using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tCelulares.Models
{
    public class Conexion
    {
        SqlConnection con;

        // contructor para conexion
        public Conexion()
        {
            //cadena de conexion
            con = new SqlConnection("server=ZIBOR-64517; database=reparaciones; integrated security = true"); ;  // cadena de conexion
        }

        // metodo para conectar a la bd
        public SqlConnection conectar()
        {
            try
            {
                con.Open();
                return con;
            }
            catch (Exception e)
            {

                throw;
            }

        }
        //metodo para desconectar
        public bool desconectar()
        {
            try
            {
                con.Close();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }

        }
    }
}
