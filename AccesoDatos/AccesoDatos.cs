using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AccesoDatos
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        private SqlTransaction transaccion;

        public SqlDataReader Lector
        {
            get { return lector; }
        }
        public AccesoDatos()
        {
            conexion = new SqlConnection("server=localhost\\SQLEXPRESS; database=libreria_escolar; integrated security=true");
            comando = new SqlCommand();
        }

        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
            comando.Parameters.Clear();
        }

        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void EjecutarAccion()
        {
            comando.Connection = conexion; 
            try
            {
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int ejecutarAccionScalar()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                return Convert.ToInt32(comando.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void setearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        public void setearProcedimiento(string procedimiento)
        {
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = procedimiento;
            comando.Parameters.Clear();
        }

        public void cerrarConexion()
        {
            if (lector != null)
            {
                lector.Close();
            }
            conexion.Close();
        }
        public void iniciarTransaccion()
        {
            conexion.Open();
            transaccion = conexion.BeginTransaction();
        }

        public void confirmarTransaccion()
        {
            transaccion.Commit();
            conexion.Close();
        }

        public void cancelarTransaccion()
        {
            try { transaccion.Rollback(); } catch { }
            if (conexion.State == System.Data.ConnectionState.Open)
                conexion.Close();
        }

        public int ejecutarAccionScalarTransaccion()
        {
            comando.Connection = conexion;
            comando.Transaction = transaccion;
            return (int)comando.ExecuteScalar();
        }

        public void ejecutarAccionTransaccion()
        {
            comando.Connection = conexion;
            comando.Transaction = transaccion;
            comando.ExecuteNonQuery();
        }
    }
}
