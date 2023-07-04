using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace negocio
{
    public class AccesoSQL
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        private SqlTransaction transaccion;

        public SqlDataReader Lector
        {
            get { return lector; }
        }
        public SqlCommand Comando
        {
            get { return comando; }
        }

        public AccesoSQL()
        {
            conexion = new SqlConnection("server =.\\SQLEXPRESS; database = ProyectoEditorial; integrated security=true");
            comando = new SqlCommand();
        }

        public void Consulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void EjecutarLectura()
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
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int EjecutarScalar()
        {
            comando.Connection = conexion;
            int idEjecucion;
            try
            {
                conexion.Open();
                idEjecucion =  (int)comando.ExecuteScalar();
                return idEjecucion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void IniciarTransaccion()
        {
            conexion.Open();
            transaccion = conexion.BeginTransaction();
        }

        public void CompletarTransaccion()
        {
            transaccion.Commit();
        }

        public void RevertirTransaccion()
        {
            transaccion.Rollback();
        }

        public void SetParametros(string Nombre, object Valor)
        {
            comando.Parameters.AddWithValue(Nombre, Valor);
        }

        public void setearProcedimiento(string sp)
        {
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = sp;
        }
        public void CerrarConexion()
        {
            if (lector != null && !lector.IsClosed)
                lector.Close();
            if (conexion.State != ConnectionState.Closed)
                conexion.Close();
        }
    }
}
