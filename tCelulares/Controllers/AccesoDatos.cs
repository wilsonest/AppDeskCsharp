using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tCelulares.modelo;
using tCelulares.Models;

namespace tCelulares.datos
{
    public class AccesoDatos
    {
        //metodo para listar o consultar los datos
        public static DataTable listar()
        {
            try
            {
                Conexion con = new Conexion();  //instaciamos la conexion
                string sql = "SELECT * FROM usuarios;"; //consulta
                SqlCommand comando = new SqlCommand(sql, con.conectar());
                SqlDataReader dr = comando.ExecuteReader(CommandBehavior.CloseConnection);
                DataTable dt = new DataTable();
                dt.Load(dr);

                con.desconectar();
                return dt;

            }
            catch (Exception ex)
            {

                return null;
            }
        }

        //metodo insertar datos o guardar
        public static bool guardar(ingresos e)
        {
            try
            {
                Conexion con = new Conexion();  //instaciamos la conexion
                string sql = "insert into usuarios values('" + e.Cedula + "','" + e.Nombre + "','" + e.Apellido + "','" + e.Telefono + "','" + e.Modelo + "','" + e.Marca + "','" + e.Estado + "','" + e.Comentarios + "','" + e.Fechai + "')";
                SqlCommand comando = new SqlCommand(sql, con.conectar());
                int cant = comando.ExecuteNonQuery();
                con.desconectar();
                if (cant == 1)
                {

                    return true;
                }
                else
                {

                    return false;
                }

            }
            catch (Exception ex)
            {

                return false;
            }
        }

        //metodo para consultar por id
        public static ingresos consultar(string cedula)
        {
            try
            {
                Conexion con = new Conexion();  //instaciamos la conexion
                string sql = "SELECT * FROM usuarios WHERE cedula = '" + cedula + "';";
                SqlCommand comando = new SqlCommand(sql, con.conectar());
                SqlDataReader dr = comando.ExecuteReader();

                ingresos em = new ingresos();
                if (dr.Read())
                {
                    em.Cedula = Convert.ToInt32(dr["cedula"].ToString());
                    em.Nombre = dr["nombre"].ToString();
                    em.Apellido = dr["apellido"].ToString();
                    em.Telefono = dr["telefono"].ToString();
                    em.Modelo = dr["modelo"].ToString();
                    em.Marca = dr["marca"].ToString();
                    em.Comentarios = dr["comentarios"].ToString();
                    em.Estado = dr["estado"].ToString();
                    em.Fechai = dr["fechai"].ToString();

                    con.desconectar();
                    return em;
                }
                else
                {
                    con.desconectar();
                    return null;
                }




            }
            catch (Exception ex)
            {

                return null;
            }
        }

        //metodo para actualizar
        public static bool actualizar(ingresos e)
        {
            try
            {
                Conexion con = new Conexion();  //instaciamos la conexion
                string sql = "UPDATE usuarios SET nombre='" + e.Nombre + "',apellido='" + e.Apellido + "',telefono='" + e.Telefono + "',modelo='" + e.Modelo + "',marca='" + e.Marca + "',estado='" + e.Estado + "',comentarios='" + e.Comentarios + "',fechai='" + e.Fechai + "' where cedula='" + e.Cedula + "'";
                SqlCommand comando = new SqlCommand(sql, con.conectar());
                int cantidad = comando.ExecuteNonQuery();

                if (cantidad == 1)
                {
                    con.desconectar();
                    return true;
                }
                else
                {
                    con.desconectar();
                    return false;
                }

            }
            catch (Exception ex)
            {

                return false;
            }
        }

        //metodo eliminar
        public static bool eliminar(string cedula)
        {
            try
            {
                Conexion con = new Conexion();  //instaciamos la conexion
                string sql = "DELETE FROM usuarios  where cedula='" + cedula + "'"; //hacemos la consulta
                SqlCommand comando = new SqlCommand(sql, con.conectar());
                int cantidad = comando.ExecuteNonQuery();

                if (cantidad == 1)
                {
                    con.desconectar();
                    return true;
                }
                else
                {
                    con.desconectar();
                    return false;
                }

            }
            catch (Exception ex)
            {

                return false;
            }
        }

        //public static DataTable listarnombre()
        //{
        //    try
        //    {
        //        Conexion con = new Conexion();  //instaciamos la conexion
        //        string sql = "SELECT * FROM usuarios;"; //consulta
        //        SqlCommand comando = new SqlCommand(sql, con.conectar());
        //        SqlDataReader dr = comando.ExecuteReader(CommandBehavior.CloseConnection);
        //        DataTable dt = new DataTable();
        //        dt.Load(dr);

        //        con.desconectar();
        //        return dt;

        //    }
        //    catch (Exception ex)
        //    {

        //        return null;
        //    }
        //}

        public static List<string> consultarname()
        {
            try
            {
                Conexion con = new Conexion(); //instanciamos la conexión
                string sql = "SELECT nombre FROM usuarios";
                SqlCommand comando = new SqlCommand(sql, con.conectar());
                SqlDataReader dr = comando.ExecuteReader();

                List<string> nombres = new List<string>(); // Crear una lista para almacenar los nombres

                while (dr.Read())
                {
                    string nombre = dr["nombre"].ToString();
                    nombres.Add(nombre); // Agregar el nombre a la lista
                }

                con.desconectar();
                return nombres;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}


