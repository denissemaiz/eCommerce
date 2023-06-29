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
                Datos.Consulta("SELECT DU.ID_Usuario, DU.Nombre, DU.Apellido, D.Calle, D.Altura, D.Localidad, D.CP, D.Provincia, DU.Telefono " +
                                   "FROM Datos_Usuario DU INNER JOIN Direccion D ON DU.ID_Direccion = D.ID_Direccion");
                Datos.EjecutarLectura();

                while (Datos.Lector.Read())
                {
                    Direccion auxDir = new Direccion();
                    DatosUsuario aux = new DatosUsuario();
                    aux.id = (int)Datos.Lector["ID_Usuario"];
                    aux.Nombres = (string)Datos.Lector["Nombre"];
                    aux.Apellidos = (string)Datos.Lector["Apellido"];
                    aux.Telefono = (string)Datos.Lector["Telefono"];
                    
                    auxDir.Calle = (string)Datos.Lector["Calle"];
                    auxDir.Altura = (int)Datos.Lector["Altura"];
                    auxDir.Localidad = (string)Datos.Lector["Localidad"];
                    auxDir.Cp = (int)Datos.Lector["CP"];
                    auxDir.Provincia = (string)Datos.Lector["Provincia"];

                    aux.Direccion = auxDir;

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
