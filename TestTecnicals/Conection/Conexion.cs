using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TestTecnicals.Conection
{
    public class Conexion
    {

        public string cadena = "Server=.\\;DataBase=BD;User ID=sa;Password=123456;";

        public DataTable Listar_clientes()
        {
            SqlConnection con = new SqlConnection(cadena);
            DataTable dt = new DataTable();
            try
            {
                string sql = "Select * From dbo.Cliente";
                SqlCommand comando = new SqlCommand(sql, con);
                comando.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(comando);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public string InsertarCliente(string nombre, string direccion)
        {
            object id;
            SqlConnection con = new SqlConnection(cadena);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Clientes.InsertarCliente", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@NombreCliente", nombre.ToUpper());
                cmd.Parameters.AddWithValue("@DireccionCliente", direccion.ToUpper());
                var returnParameter = cmd.Parameters.Add("@Existente", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();
                id = returnParameter.Value;
                con.Close();
                cmd.Dispose();
                return id.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public string UpdateCliente(int idCliente, string nombre, string direccion)
        {
            object id;
            SqlConnection con = new SqlConnection(cadena);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Clientes.ModificarCliente", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@IdCliente", idCliente);
                cmd.Parameters.AddWithValue("@NombreCliente", nombre.ToUpper());
                cmd.Parameters.AddWithValue("@DireccionCliente", direccion.ToUpper());
                var returnParameter = cmd.Parameters.Add("@Existente", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();
                id = returnParameter.Value;
                con.Close();
                cmd.Dispose();
                return id.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public string DeleteCliente(int idCliente)
        {
            object id;
            SqlConnection con = new SqlConnection(cadena);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Clientes.deleteCliente", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@IdCliente", idCliente);
                var returnParameter = cmd.Parameters.Add("@Existente", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();
                id = returnParameter.Value;
                con.Close();
                cmd.Dispose();
                return id.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

    }
}
