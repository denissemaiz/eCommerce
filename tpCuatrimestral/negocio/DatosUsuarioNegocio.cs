using Clases;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexiones
{
    internal class DatosUsuarioNegocio
    {
        public List<DatosUsuario> Listar()
        {
            List<DatosUsuario> lista = new List<DatosUsuario>();
            AccesoSQL Datos = new AccesoSQL();

            try
            {
                Datos.Consulta("Select...");
                Datos.EjecutarLectura();

                while (Datos.Lector.Read())
                {
                    DatosUsuario aux = new DatosUsuario();
                    aux.Nombres = (string)Datos.Lector["Nombre"];
                    aux.Apellidos = (string)Datos.Lector["Apellidos"];
                    aux.Telefono = (string)Datos.Lector["Telefono"];
                    //aux.DatosUsuario = (DatosUsuario)Datos.Lector[""];                   
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Datos.CerrarConexion();
            }
        }
    }
}
