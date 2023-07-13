using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tCelulares.Models;

namespace tCelulares.Controllers
{
    internal class AccesoRepuestos
    {
        //metodo para listar o consultar los datos
        public static DataTable listar()
        {
            try
            {
                Conexion con = new Conexion();  //instaciamos la conexion
                string sql = "SELECT * FROM repuestos;"; //consulta
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
        public static bool guardar(repuestos e)
        {
            try
            {
                Conexion con = new Conexion();  //instaciamos la conexion
                string sql = "insert into repuestos values('" + e.referencia + "','" + e.nombre + "','" + e.cantidad + "','" + e.disponibilidad + "','" + e.fechai + "')";
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
        public static repuestos consultar(string referencia)
        {
            try
            {
                Conexion con = new Conexion();  //instaciamos la conexion
                string sql = "SELECT * FROM repuestos WHERE referencia = '" + referencia + "';";
                SqlCommand comando = new SqlCommand(sql, con.conectar());
                SqlDataReader dr = comando.ExecuteReader();

                repuestos rep = new repuestos();
                if (dr.Read())
                {
                    
                    rep.referencia = dr["referencia"].ToString();
                    rep.nombre = dr["nombre"].ToString();
                    rep.cantidad = Convert.ToInt32(dr["cantidad"].ToString());
                    rep.disponibilidad = dr["disponible"].ToString();
                    rep.fechai = dr["fechai"].ToString();

                    con.desconectar();
                    return rep;
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
        public static bool actualizar(repuestos e)
        {
            try
            {
                Conexion con = new Conexion();  //instaciamos la conexion
                string sql = "UPDATE repuestos SET nombre='" + e.nombre + "',cantidad='" + e.cantidad + "',disponible='" + e.disponibilidad + "',fechai='" + e.fechai + "' where referencia='" + e.referencia + "'";
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

        public static bool eliminar(string referencia)
        {
            try
            {
                Conexion con = new Conexion();  //instaciamos la conexion
                string sql = "DELETE FROM repuestos  where referencia='" + referencia + "'"; //hacemos la consulta
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
    }
}
